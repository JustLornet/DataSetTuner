namespace ImageResizeService.Domain.CloudDto
{
    /// <summary>
    /// Тип элемента в Яндекс.Диск
    /// </summary>
    public enum YandexElementType
    {
        /// <summary>
        /// Тип пока еще не определен
        /// </summary>
        Undefined = 0,

        Directory = 1,

        File = 2,

        /// <summary>
        /// Ошибка при определении типа
        /// </summary>
        Error = 3,
    }
}
