using ImageResizeService.Domain.Models.ValueObjects;

namespace ImageResizeService.Domain.Models.Abstractions
{
    public interface IHasOffsets
    {
        OffsetSet Offsets { get; }
    }
}
