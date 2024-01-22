using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ImageResizeService.Domain.Services.Contracts.Managers.Resize
{
    public class FullDimensionResizerViaRect : IFullDimensionResizerViaRect
    {
        public Bitmap GetDestinationImageViaRectangle(Image image, int destWidth, int destHeight, Rectangle destinationRectangle)
        {
            var resultImage = new Bitmap(destWidth, destHeight);
            resultImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using var graphics = Graphics.FromImage(resultImage);
            graphics.CompositingMode = CompositingMode.SourceCopy;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            using var wrapMode = new ImageAttributes();
            wrapMode.SetWrapMode(WrapMode.TileFlipXY);
            graphics.DrawImage(image, destinationRectangle, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);

            return resultImage;
        }
    }

    public interface IFullDimensionResizerViaRect
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="image">Изображение, которое необходимо привести к заданному состоянию.</param>
        /// <param name="destWidth">Ширина, которая должна быть у изображения на выходе.</param>
        /// <param name="destHeight">Высота, которая должна быть у изображения на выходе.</param>
        /// <param name="destinationRectangle">Прямоугольник, по которому строится итоговое изображение.</param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        Bitmap GetDestinationImageViaRectangle(Image image, int destWidth, int destHeight,
            Rectangle destinationRectangle);
    }
}
