using System;
using ImageResizeService.Domain.Models.Interfaces;

namespace ImageResizeService.Domain.Models.Models
{
    public class InitImage : IImageModel
    {

        internal InitImage(Guid guid, byte[] data, int wOut, int hOut)
        {
            Guid = guid;
            WOut = wOut;
            HOut = hOut;
            Data = data;
        }

        public Guid Guid { get; set; }
        
        public int WOut { get; set; }
        
        public int HOut { get; set; }

        public byte[] Data { get; set; }
    }
}
