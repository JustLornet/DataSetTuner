using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ImageResizeService.Domain.CloudDto
{
    public class YandexFolderContentInfo
    {
        public string Path { get; set; } = string.Empty;

        [JsonPropertyName("_embedded.items")]
        public IEnumerable<YandexElementInfo> Items { get; set; } = Enumerable.Empty<YandexElementInfo>();
    }
}
