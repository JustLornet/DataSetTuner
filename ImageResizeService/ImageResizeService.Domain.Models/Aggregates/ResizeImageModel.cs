using System;
using System.Drawing;
using ImageResizeService.Domain.Models.Abstractions;
using ImageResizeService.Domain.Models.Models;

namespace ImageResizeService.Domain.Models.Aggregates
{
    public class ResizeImageModel : IAggregateRoot
    {
        public Guid Guid
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        private InitImage? InitImage { get; set; }

        private Mask? Mask { get; set; }

        private ResizedInitImage? ResizedInitImage { get; set; }

        public void SetInitImage(Image image)
        {
            if (InitImage is null)
            {
                InitImage = new InitImage(Guid.NewGuid());
            }

            if (InitImage.IsImageSet) throw new ArgumentException();

            InitImage.SetImage(image);
        }

        public void SetMask(Image image)
        {
            if (Mask is null)
            {
                Mask = new Mask(Guid.NewGuid());
            }

            if (Mask.IsImageSet) throw new ArgumentException();

            Mask.SetImage(image);
        }

        public void SetResizedInitImage(Image image)
        {
            if (ResizedInitImage is null)
            {
                ResizedInitImage = new ResizedInitImage();
            }

            if (ResizedInitImage.IsImageSet) throw new ArgumentException();

            ResizedInitImage.SetImage(image);
        }
    }
}
