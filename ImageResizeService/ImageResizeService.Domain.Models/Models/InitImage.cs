using System;
using ImageResizeService.Domain.Models.Abstractions;

namespace ImageResizeService.Domain.Models.Models
{
    /// <summary>
    /// Модель исходного изображения.
    /// </summary>
    public class InitImage : ImageModel
    {
        internal InitImage(Guid guid)
        {
            Guid = guid;
        }
    }
}
