using System;

namespace ImageResizeService.Domain.Models.Interfaces
{
    public interface IEntity
    {
        Guid Guid { get; protected set; }
    }
}
