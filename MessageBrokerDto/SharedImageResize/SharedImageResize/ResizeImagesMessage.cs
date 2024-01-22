namespace SharedImageResize
{
    /// <summary>
    /// Сообщение, содержащее информацию о работе по изменениям размера изображений.
    /// </summary>
    public class ResizeImagesMessage
    {
        /// <summary>
        /// Путь к изображениям, которые необходимо обработать.
        /// </summary>
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// Паттерн, по которому выбираются изображения к обработке.
        /// </summary>
        public string RegexPattern { get; set; } = string.Empty;

        /// <summary>
        /// Ширина, которая должна получиться у выбранных изображений.
        /// </summary>
        public double DestWidth { get; set; }

        /// <summary>
        /// Высота, которая должна получиться у выбранных изображений.
        /// </summary>
        public double DestHeight { get; set; }
    }
}
