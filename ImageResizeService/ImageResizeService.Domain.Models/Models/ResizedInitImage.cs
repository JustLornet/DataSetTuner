using System;
using ImageResizeService.Domain.Models.Abstractions;
using ImageResizeService.Domain.Models.ValueObjects;

namespace ImageResizeService.Domain.Models.Models
{
    /// <summary>
    /// Модель результирующего деформированного изображения.
    /// </summary>
    public class ResizedInitImage : ImageModel, IHasOffsets
    {
        internal ResizedInitImage()
        {
            Guid = Guid.NewGuid();
        }

        public OffsetSet Offsets => throw new NotImplementedException();
    }
}
