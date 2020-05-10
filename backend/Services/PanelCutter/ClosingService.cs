using AutoMapper;
using Furny.Data;
using Furny.Models;
using Furny.ServiceInterfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

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