using ImageResizeService.Domain.Models.ValueObjects;

namespace ImageResizeService.Domain.Models.Interfaces
{
    public abstract class CloudCatalogElement
    {
        HID HID { get; }

        Path PathInfo { get; }

        CatalogType CatalogElementType { get; }

        LeafType ElementType { get; }

        //abstract internal void SetCatalogElementType(CatalogType type);

        //abstract internal void SetElementType(LeafType type);

        public override int GetHashCode() => HID.Value.GetHashCode();
    }
}
