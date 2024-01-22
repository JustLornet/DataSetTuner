namespace ImageResizeService.Domain.Models.ValueObjects
{
    public enum LeafType
    {
        /// <summary>
        /// Тип пока что неизвестен. Определение типа элемента не проводилось.
        /// </summary>
        NotDefined = 0,

        /// <summary>
        /// Директория в каталоге.
        /// </summary>
        Image = 1,

        /// <summary>
        /// Файл - конечный элемент каталога.
        /// </summary>
        TextFile = 2,

        /// <summary>
        /// Не получилось определить тип элемента / ошибка при определении.
        /// </summary>
        Unknown = 3
    }
}
