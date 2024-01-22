using System;

namespace ImageResizeService.Domain.Models.ValueObjects
{
    /// <summary>
    /// Отображает путь к файлу/каталогу в облаке.
    /// </summary>
    public sealed class Path
    {
        private string _fullPath = string.Empty;
        
        public string FullPath => _fullPath;

        /// <summary>
        /// Попытка установить новое значение полного пути для элемента.
        /// </summary>
        /// <param name="path">Новый полынй путь до элемента каталога.</param>
        /// <returns>True - получилось установить новый путь. False - путь не валиден.</returns>
        internal bool TrySetFullPath (string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return false;

            // TODO: проверить, что IsWellFormedUriString подходит для путей каталога в облаке
            var isPathValid = Uri.IsWellFormedUriString(path, UriKind.Absolute);
            
            if (isPathValid) _fullPath = FullPath;

            return isPathValid;
        }
    }
}
