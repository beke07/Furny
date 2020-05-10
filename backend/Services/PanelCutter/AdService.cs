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
    public class AdService : SingleElementBaseService<PanelCutter, Ad, AdDto, AdTableDto>, IAdService
    {
        public AdService(
            IMapper mapper, 
            IConfiguration configuration, 
            string collectionName = "applicationUsers") : base(mapper, configuration, collectionName)
        { }
    }
}
