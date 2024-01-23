using System;

namespace ImageResizeService.Domain.Models.Abstractions
{
    public interface IEntity
    {
        Guid Guid { get; }
    }
}
