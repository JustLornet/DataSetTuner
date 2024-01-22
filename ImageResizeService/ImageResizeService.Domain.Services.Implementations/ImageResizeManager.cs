using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageResizeService.Domain.Models.Models;
using ImageResizeService.Domain.Services.Contracts.Managers.Resize;

namespace ImageResizeService.Domain.Services.Implementations
{
    public class ImageResizeManager : IImageResizeManager
    {
        public async Task<CatalogImage> GetResizedImage(CatalogImage catalogImage, int destWidth, int destHeight)
        {
            CatalogImage resultCatalogImage = null;
            using (var ms = new MemoryStream(catalogImage.Data))
            {
                var bmImage = new Bitmap(ms);
            }

            return resultCatalogImage;
        }
    }
}
