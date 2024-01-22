using ImageResizeService.Domain.Models.Interfaces;
using ImageResizeService.Domain.Models.ValueObjects;

namespace ImageResizeService.Domain.Models.ModelsImplementations
{
    /// <summary>
    /// Директория каталога как отдельный элемент каталога, без учета того, что в ней находится.
    /// </summary>
    public class Folder : ICloudCatalogElement
    {
        internal Folder()
        {
            
        }

        public HID HID { get; }
        public Path PathInfo { get; }
        public CatalogType CatalogElementType { get; }
        public LeafType ElementType { get; }
        public void SetCatalogElementType(CatalogType type)
        {
            throw new System.NotImplementedException();
        }

        public void SetElementType(LeafType type)
        {
            throw new System.NotImplementedException();
        }
    }
}
