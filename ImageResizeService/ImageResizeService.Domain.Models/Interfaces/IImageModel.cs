namespace ImageResizeService.Domain.Models.Interfaces
{
    public interface IImageModel : IEntity
    {
        int WOut { get; protected set; }

        int HOut { get; protected set; }

        byte[] Data { get; protected set; }
    }
}
