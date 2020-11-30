using Furny.Common.Enums;
using Furny.ExportFeature.ServiceInterfaces;
using Furny.Model;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Furny.Test
{
    public class ExportTest : TestBase
    {
        private readonly IExportService _exportService;

        public ExportTest()
        {
            _exportService = serviceProvider.GetService<IExportService>();
        }

        [Fact]
        public async Task ExportExcelTest()
        {
            var componentList1 = new List<Component>(){
                new Component()
                {
                    Name = "Component1",
                    Height = 1000,
                    Width = 2000,
                    Closings = new Closings(){
                        Bottom = true,
                        Top = false,
                        Left = true,
                        Right = false
                    }
                }
            };

            var componentList2 = new List<Component>(){
                new Component()
                {
                    Name = "Component2",
                    Height = 500,
                    Width = 1520,
                    Closings = new Closings(){
                        Bottom = false,
                        Top = false,
                        Left = true,
                        Right = true
                    }
                }
            };

            var components = new List<List<Component>>() { componentList1, componentList2 };
            var result = await _exportService.ExportAsync(ExcelType.ErFa, components);

            Assert.NotNull(result.Item1);
            Assert.NotNull(result.Item2);
            Assert.Contains(ExcelType.ErFa.GetDescription(), result.Item2);
            Assert.True(result.Item1.Length > 0);
        }
    }
}
