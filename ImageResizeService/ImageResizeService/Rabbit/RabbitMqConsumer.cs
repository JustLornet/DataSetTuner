using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using ImageResizeMessages;
using ImageResizeService.Domain.CloudDto;
using ImageResizeService.Infrastructure.Cloud;

namespace ImageResizeService.Rabbit
{
    public class RabbitMqConsumer : IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqConsumer()
        {
            var factory = new ConnectionFactory { HostName = "localhost", UserName="user", Password="password" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            StartConsuming();
        }

        private void StartConsuming ()
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (ch, ea) =>
            {
                var bytes = Encoding.UTF8.GetString(ea.Body.ToArray());
                var content = JsonSerializer.Deserialize<ResizeInfoMessage>(bytes);

                try
                {
                    var proc = new Process();
                    proc.StartInfo.FileName =
                        "https://oauth.yandex.ru/authorize?response_type=token&client_id=81c3db622f0b47d7ac4207a1665e263a";
                    proc.StartInfo.UseShellExecute = true;
                    proc.Start();
                    proc.Dispose();

                    var httpClient = new HttpClient();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("OAuth", "");
                    var oauthTokenResponse = await httpClient.GetAsync(
                        ",_embedded.items.path,_embedded.items.type");
                    var convertOptions = new JsonSerializerOptions();
                    convertOptions.Converters.Add(new YandexFolderContentInfoConverter());
                    var parsedContent = await oauthTokenResponse.Content.ReadFromJsonAsync<YandexFolderContentInfo>(convertOptions);

                    foreach (var item in parsedContent.Items)
                    {
                        var itemPath = item.Path;

                        var getItem = await httpClient.GetAsync($"https://cloud-api.yandex.net/v1/disk/resources/download?path={itemPath}");
                        var answerToDownload = await getItem.Content.ReadAsStringAsync();
                        var urlToDownload = JsonNode.Parse(answerToDownload)["href"].ToString();

                        var imageResponse = await httpClient.GetAsync(urlToDownload);
                        await using var responseStream = await imageResponse.Content.ReadAsStreamAsync();
                        var image = Image.FromStream(responseStream);
                        image.Save(Path.Combine(Path.GetTempPath(), "test.jpg"), ImageFormat.Jpeg);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }

                _channel.BasicAck(ea.DeliveryTag, false);
            };

            _channel.BasicConsume("MyTestQueue", false, consumer);
        }

        public void Dispose()
        {
            _channel.Close();
            _connection.Close();
        }
    }
}
