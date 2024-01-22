namespace ImageResizeService.Domain.Models.ValueObjects
{
    public struct OffsetSet(int xLeft, int xRight, int yTop, int yBottom)
    {
        public int XLeft { get; private set; } = xLeft;
        public int XRight { get; private set; } = xRight;

        public int YTop { get; private set; } = yTop;
        public int YBottom { get; private set; } = yBottom;
    }
}
