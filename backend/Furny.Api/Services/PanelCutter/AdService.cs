using AutoMapper;
using Furny.Data;
using Furny.Models;
using Furny.ServiceInterfaces;
using Microsoft.Extensions.Configuration;

namespace Furny.Services
{
    public class AdService : SingleElementBaseService<PanelCutter, Ad, AdCommand, AdTableCommand>, IAdService
    {
        public AdService(
            IMapper mapper, 
            IConfiguration configuration, 
            string collectionName = "applicationUsers") : base(mapper, configuration, collectionName)
        { }
    }
}
