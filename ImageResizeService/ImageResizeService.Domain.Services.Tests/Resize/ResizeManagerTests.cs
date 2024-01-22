using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageResizeService.Domain.Services.Implementations;

namespace ImageResizeService.Domain.Services.Tests.Resize
{
    [TestFixture]
    public class ResizeManagerTests
    {
        public void ResizeSimpleImage()
        {
            // Arrange
            var manager = new ImageResizeManager();
            var destWidth = 100;
            var destHeight = 100;

            // Action
            var newImage = manager
        }


        // отдельно проверить асинхронность
    }
}
