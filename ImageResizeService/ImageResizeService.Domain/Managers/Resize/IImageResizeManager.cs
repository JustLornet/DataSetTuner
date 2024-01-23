using System.Drawing;
using ImageResizeService.Domain.Models.Aggregates;

namespace ImageResizeService.Domain.Services.Contracts.Managers.Resize
{
    public interface IImageResizeManager
    {
        /// <summary>
        /// На основе исходного изображения делаем изображение, соответствующее требуемым размерам.
        /// </summary>
        /// <param name="resizeModel">Модель с исходными данными для формирования результирующего деформированного изображения.</param>
        /// <param name="destWidth">Ширина, которую должно иметь новое изображение.</param>
        /// <param name="destHeight">Высота, которую должно иметь новое изображение.</param>
        /// <returns>Изображение.</returns>
        Task FormResizedInitImage(ResizeImageModel resizeModel, int destWidth, int destHeight);
    }
}
