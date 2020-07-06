using Furny.Common;
using Furny.Models;
using Furny.ServiceInterfaces;
using Furny.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using static Furny.Common.Enums;

namespace Furny.Test
{
    public class ExportTest : MongoDbTest
    {
        private readonly IExportService _exportService;

        public ExportTest()
        {
            _exportService = new ExportService(new ExcelService());
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
                        Bottom = new ComponentClosing()
                        {
                            IsClosed = true
                        },
                        Top = new ComponentClosing()
                        {
                            IsClosed = false
                        },
                        Left = new ComponentClosing()
                        {
                            IsClosed = true
                        },
                        Right = new ComponentClosing()
                        {
                            IsClosed = false
                        }
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
                        Bottom = new ComponentClosing()
                        {
                            IsClosed = false
                        },
                        Top = new ComponentClosing()
                        {
                            IsClosed = false
                        },
                        Left = new ComponentClosing()
                        {
                            IsClosed = true
                        },
                        Right = new ComponentClosing()
                        {
                            IsClosed = true
                        }
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
