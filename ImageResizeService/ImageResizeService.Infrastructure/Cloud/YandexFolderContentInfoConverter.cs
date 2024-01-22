using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using ImageResizeService.Domain.CloudDto;

namespace ImageResizeService.Infrastructure.Cloud
{
    public class YandexFolderContentInfoConverter : System.Text.Json.Serialization.JsonConverter<YandexFolderContentInfo>
    {
        public override YandexFolderContentInfo Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
        {
            using var jsonDoc = JsonDocument.ParseValue(ref reader);
            var readerString = jsonDoc.RootElement.GetRawText();

            var jo = JsonNode.Parse(readerString).AsObject();
            var yandexFolderContentInfoObj = new YandexFolderContentInfo();

            var isPathGot = jo.TryGetPropertyValue("path", out var path);

            if (isPathGot)
            {
                yandexFolderContentInfoObj.Path = path!.ToString();
            }

            var isItemsGot = jo.TryGetPropertyValue("_embedded", out var items);

            if (isItemsGot)
            {
                var jsonItems = items!["items"];
                yandexFolderContentInfoObj.Items =
                    JsonSerializer.Deserialize<IEnumerable<YandexElementInfo>>(jsonItems);
            }

            //object targetObj = Activator.CreateInstance(type);

            //foreach (PropertyInfo prop in type.GetProperties()
            //             .Where(p => p.CanRead && p.CanWrite))
            //{
            //    JsonPropertyNameAttribute att = prop.GetCustomAttributes(true)
            //        .OfType<JsonPropertyNameAttribute>()
            //        .FirstOrDefault();

            //    string jsonPath = (att != null ? att.Name : prop.Name);
            //    var isValueGot = jo.TryGetPropertyValue(jsonPath, out var node);

            //    if (isValueGot && node is not null)
            //    {
            //        var value = node.AsObject();
            //        //object value = token.ToObject(prop.PropertyType, serializer);
            //        prop.SetValue(targetObj, value, null);
            //    }
            //}

            return yandexFolderContentInfoObj;
        }

        public override void Write(Utf8JsonWriter writer, YandexFolderContentInfo value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
