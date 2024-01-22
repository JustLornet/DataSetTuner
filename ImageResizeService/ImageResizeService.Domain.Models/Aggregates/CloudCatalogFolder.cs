using System.Collections.Generic;
using ImageResizeService.Domain.Models.Interfaces;

namespace ImageResizeService.Domain.Models.Aggregates
{
    /// <summary>
    /// Директория каталога, содержащая внутри элементы.
    /// </summary>
    public class CloudCatalogFolder : IAggregateRoot
    {
        private ISet<CloudCatalogElement> _containingElements;

        public void AddCatalogElement(CloudCatalogElement element)
        {

        }

        public static void Init()
        {

        }
    }
}
