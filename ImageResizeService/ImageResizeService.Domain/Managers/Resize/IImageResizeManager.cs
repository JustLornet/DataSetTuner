using ImageResizeService.Domain.Models.Models;

namespace ImageResizeService.Domain.Services.Contracts.Managers.Resize
{
    public interface IImageResizeManager
    {
        /// <summary>
        /// На основе исходного изображения делаем изображение, соответствующее требуемым размерам.
        /// </summary>
        /// <param name="catalogImage">Исходное изображение.</param>
        /// <param name="destWidth">Ширина, которую должно иметь новое изображение.</param>
        /// <param name="destHeight">Высота, которую должно иметь новое изображение.</param>
        /// <returns>Изображение.</returns>
        Task<CatalogImage> GetResizedImage(CatalogImage catalogImage, int destWidth, int destHeight);
    }
}
