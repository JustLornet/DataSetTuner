using System.Drawing;
using ImageResizeService.Domain.Services.Contracts.Managers.Resize;

namespace ImageResizeService.Domain.CoreManagers.Resize
{
    internal class ResizeManagerViaFullHeight : IImageResizeManager
    {
        private readonly IFullDimensionResizerViaRect _fullDimensionResizerViaRect;

        internal ResizeManagerViaFullHeight(IFullDimensionResizerViaRect fullDimensionResizerViaRect)
        {
            _fullDimensionResizerViaRect = fullDimensionResizerViaRect;
        }

        public Bitmap GetResizedImage(Image image, int destWidth, int destHeight)
        {
            var proportionalWidth = destHeight * image.Width / image.Height;
            var widthAddTop = (destWidth - proportionalWidth) / 2;

            if (widthAddTop < 0) throw new OperationCanceledException("Error 1");

            var destRect = new Rectangle(widthAddTop, 0, proportionalWidth, destHeight);

            return _fullDimensionResizerViaRect.GetDestinationImageViaRectangle(image, destWidth, destHeight, destRect);
        }
    }
}
