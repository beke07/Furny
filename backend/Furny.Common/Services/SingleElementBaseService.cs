using AutoMapper;
using Furny.Common.Commands;
using Furny.Common.Models;
using Furny.Common.ServiceInterfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.Common.Services
{
    public class SingleElementBaseService<B, T, D, TD> : BaseService<B>, ISingleElementService<D, TD>
        where B : IMongoEntityBase
        where T : MongoEntityBase
        where D : class
        where TD : TableBaseCommand
    {
        private readonly string propertyName = $"{typeof(T).Name}s";
        private readonly IMapper _mapper;

        public SingleElementBaseService(
            IMapper mapper,
            IConfiguration configuration,
            string collectionName = "applicationUsers") : base(configuration, collectionName)
        {
            _mapper = mapper;
        }

        private async Task<B> SetPropertyAsync(string id, IList<T> elements)
        {
            var baseElement = await FindByIdAsync(id);
            baseElement.GetType().GetProperty(propertyName).SetValue(baseElement, elements, null);
            return baseElement;
        }

        private async Task<SingleElement<T>> GetPropertyAsync(string id)
        {
            var baseElement = await FindByIdAsync(id);
            return (SingleElement<T>)baseElement.GetType().GetProperty(propertyName).GetValue(baseElement, null);
        }

        public async Task<IList<TD>> GetAsync(string id)
        {
            var elements = await GetPropertyAsync(id);
            return _mapper.Map<IList<TD>>(elements);
        }

        public async Task<T> FindByIdAsync(string id, string cid)
        {
            var elements = await GetPropertyAsync(id);
            return elements.GetById(cid);
        }

        protected async Task ReplaceByIdAsync(string id, T element)
        {
            var elements = await GetPropertyAsync(id);

            elements.RemoveById(element.Id.ToString());
            elements.Add(element);

            await UpdateAsync(await SetPropertyAsync(id, elements));
        }

        public async Task<D> GetByIdAsync(string id, string cid)
        {
            var elements = await GetPropertyAsync(id);
            return _mapper.Map<D>(elements.GetById(cid));
        }

        public async Task UpdateAsync(JsonPatchDocument<D> jsonPatch, string id, string elementId)
        {
            var elements = await GetPropertyAsync(id);
            var element = elements.GetById(elementId);

            var elementDto = _mapper.Map<D>(element);
            jsonPatch.ApplyTo(elementDto);

            elements.Update(_mapper.Map(elementDto, element), elementId);

            await UpdateAsync(await SetPropertyAsync(id, elements));
        }

        public async Task RemoveAsync(string id, string elementId)
        {
            var elements = await GetPropertyAsync(id);
            elements.RemoveById(elementId);

            await UpdateAsync(await SetPropertyAsync(id, elements));
        }

        public virtual async Task CreateAsync(D element, string id)
        {
            var elements = await GetPropertyAsync(id);
            elements.Add(_mapper.Map<T>(element));

            await UpdateAsync(await SetPropertyAsync(id, elements));
        }

        public async Task<IList<TD>> QuickSearchAsync(string id, string term, string propertyName)
        {
            var elements = await GetPropertyAsync(id);

            return _mapper.Map<IList<TD>>(elements.Where(e => e
                .GetType()
                .GetProperty(propertyName)
                .GetValue(e, null)
                .ToString()
                .ToLower()
                .Contains(term.ToLower())));
        }
    }
}
