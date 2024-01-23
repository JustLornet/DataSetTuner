using System;
using System.Drawing;
using ImageResizeService.Domain.Models.Abstractions;

namespace ImageResizeService.Domain.Models.Abstractions
{
    /// <summary>
    /// Любое изображение.
    /// </summary>
    public abstract class ImageModel : IEntity
    {
        /// <summary>
        /// Изображение.
        /// </summary>
        protected Image? Image { get; private set; }

        public Guid Guid { get; protected set; }

        /// <summary>
        /// Внешняя ширина изображения.
        /// </summary>
        public int WOut => Image?.Width ?? 0;

        /// <summary>
        /// Внешняя высота изображения.
        /// </summary>
        public int HOut => Image?.Height ?? 0;

        public bool IsImageSet => Image is not null;

        internal void SetImage(Image image)
        {
            if (image.Height <= 0 || image.Width <= 0) throw new ArgumentException();

            Image = image;
        }
    }
}
