using Furny.Common.Filters;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Furny.Common.Models
{
    public class SingleElement<T> : List<T>
        where T : IMongoEntityBase
    {
        public void RemoveById(string id)
        {
            var element = GetById(id);
            Remove(element);
        }

        public T GetById(string id)
        {
            var element = this.SingleOrDefault(e => e.Id == ObjectId.Parse(id));

            if (element == null)
            {
                throw new HttpResponseException("Elem nem található!", HttpStatusCode.BadRequest);
            }

            return element;
        }

        public void Update(T element, string id)
        {
            RemoveById(id);
            Add(element);
        }
    }
}
