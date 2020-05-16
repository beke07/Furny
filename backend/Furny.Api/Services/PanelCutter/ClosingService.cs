using AutoMapper;
using Furny.Data;
using Furny.Models;
using Furny.ServiceInterfaces;
using Microsoft.Extensions.Configuration;

namespace Furny.Services
{
    public class ClosingService : SingleElementBaseService<PanelCutter, Closing, ClosingDto, ClosingTableDto>, IClosingService
    {
        public ClosingService(
            IMapper mapper,
            IConfiguration configuration,
            string collectionName = "applicationUsers") : base(mapper, configuration, collectionName)
        { }
    }
}