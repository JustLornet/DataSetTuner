using System.Drawing;
using ImageResizeService.Domain.Services.Contracts.Managers.Resize;

namespace ImageResizeService.Domain.CoreManagers.Resize
{
    internal class ResizeManagerViaFullWidth : IImageResizeManager
    {
        private readonly IFullDimensionResizerViaRect _fullDimensionResizerViaRect;

        internal ResizeManagerViaFullWidth(IFullDimensionResizerViaRect fullDimensionResizerViaRect)
        {
            _fullDimensionResizerViaRect = fullDimensionResizerViaRect;
        }

        public Bitmap GetResizedImage(Image image, int destWidth, int destHeight)
        {
            var proportionalHeight = destWidth * image.Height / image.Width;
            var heightAddTop = (destHeight - proportionalHeight) / 2;

            if (heightAddTop < 0) throw new OperationCanceledException("Error 1");

            var destRect = new Rectangle(0, heightAddTop, destWidth, proportionalHeight);
            
            return _fullDimensionResizerViaRect.GetDestinationImageViaRectangle(image, destWidth, destHeight, destRect);
        }
    }
}
