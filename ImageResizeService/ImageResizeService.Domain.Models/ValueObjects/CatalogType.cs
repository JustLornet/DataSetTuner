namespace ImageResizeService.Domain.Models.ValueObjects
{
    public enum CatalogType
    {
        /// <summary>
        /// Тип пока что неизвестен. Определение типа элемента не проводилось.
        /// </summary>
        NotDefined = 0,

        /// <summary>
        /// Директория в каталоге.
        /// </summary>
        Node = 1,

        /// <summary>
        /// Файл - конечный элемент каталога.
        /// </summary>
        Leaf = 2,

        /// <summary>
        /// Не получилось определить тип элемента / ошибка при определении.
        /// </summary>
        Unknown = 3
    }
}
