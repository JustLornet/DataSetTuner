using System;
using System.Collections.Generic;
using System.Linq;
using ImageResizeService.Domain.Models.Interfaces;
using ImageResizeService.Domain.Models.ValueObjects;

namespace ImageResizeService.Domain.Models.Models
{
    public class CatalogImage : CloudCatalogElement, IAggregateRoot
    {
        private HID _hid;
        private Path _pathInfo;
        private EditImageModel _editImageModel;

        private CatalogImage() { }

        public HID HID { get; }
        
        public Path PathInfo { get; }

        public CatalogType CatalogElementType => CatalogType.Leaf;

        public LeafType ElementType => LeafType.Image;

        public EditImageModel EditImageModel { get; }


        public static CatalogImage Init(HID hid, Path pathInfo, byte[] data)
        {
            var image = new CatalogImage();
            image._hid = hid;
            image._pathInfo = pathInfo;
            image._editImageModel = EditImageModel.Init(data);

            return image;
        }
    }
}
