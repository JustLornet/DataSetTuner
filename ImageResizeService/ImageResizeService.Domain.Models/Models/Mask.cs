using System;
using ImageResizeService.Domain.Models.Abstractions;
using ImageResizeService.Domain.Models.ValueObjects;

namespace ImageResizeService.Domain.Models.Models
{
    /// <summary>
    /// Модель маски с содержащимся исходным пропорциональным изображением.
    /// </summary>
    public class Mask : ImageModel, IHasOffsets
    {
        internal Mask(Guid guid)
        {
            Guid = guid;
        }

        ///// <summary>
        ///// Набор отступов исзодного пропорционального изображения от внешних границ маски.
        ///// </summary>
        public OffsetSet Offsets { get; }

        ///// <summary>
        ///// Исходное пропорциональное изображение.
        ///// WOut для него - WProp, HOut - HProp.
        ///// </summary>
        protected ImageModel? InitProportionalImage { get; private set; }

        internal void SetInitProportionalImage(ImageModel image)
        {
            InitProportionalImage = image;
        }
    }
}
