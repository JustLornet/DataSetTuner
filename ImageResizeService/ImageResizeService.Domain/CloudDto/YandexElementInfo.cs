using System.Text.Json.Serialization;

namespace ImageResizeService.Domain.CloudDto
{
    public class YandexElementInfo
    {
        [JsonPropertyName("path")]
        public string Path { get; set; } = string.Empty;

        public YandexElementType Type { get; set; } = YandexElementType.Undefined;
    }
}
