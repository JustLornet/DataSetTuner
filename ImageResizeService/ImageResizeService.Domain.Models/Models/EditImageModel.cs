using ImageResizeService.Domain.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageResizeService.Domain.Models.Interfaces;

namespace ImageResizeService.Domain.Models.Models
{
    public class EditImageModel : IEntity
    {
        private Guid _guid;
        private bool _isImageAsSource = true;
        private byte[] _currentData;
        private byte[] _initData;
        private int _maskVertTopOffset;
        private int _maskVertBottomOffset;
        private int _maskHorizontalLeftOffset;
        private int _maskHorizontalRightOffset;

        private EditImageModel() {}
        
        public Guid Guid => _guid;

        public byte[] Data => _currentData;

        public byte[] InitData => _initData;

        /// <summary>
        /// Менялись ли данные изображения относительно исходного.
        /// </summary>
        public bool IsImageAsSource => _isImageAsSource;

        public void SetImageData(byte[] imageData)
        {
            _initData = _currentData;
            _isImageAsSource = false;

            ImageChanged?.Invoke(imageData);
        }

        public event Action<IEnumerable<byte>> ImageChanged;

        public static EditImageModel Init(byte[] data)
        {
            if (data.Length <= 0) throw new ArgumentException();

            var image = new EditImageModel();
            image._currentData = data;
            image._guid = Guid.NewGuid();

            return image;
        }
    }
}
