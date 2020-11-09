﻿using Furny.Common.Filters;
using Furny.Common.Models;
using Furny.Common.ServiceInterfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Furny.Common.Services
{
    public class BaseService<T> : IBaseService<T>
        where T : IMongoEntityBase
    {
        protected IMongoDatabase _database { get; set; }

        protected IMongoCollection<T> _collection;

        public BaseService(IConfiguration configuration, string collectionName)
        {
            var dbName = configuration.GetValue<string>("DbName");
            var client = new MongoClient(configuration.GetConnectionString(dbName));
            _database = client.GetDatabase(dbName);
            _collection = _database.GetCollection<T>(collectionName);
        }

        public async Task<T> FindByIdAsync(string id)
        {
            var entity = await _collection.Find(e => e.Id == ObjectId.Parse(id) && !e.IsDeleted).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new HttpResponseException("Elem nem található!", HttpStatusCode.BadRequest);
            }

            return entity;
        }

        public virtual async Task<IList<T>> Get()
        {
            var entities = await _collection.Find(e => !e.IsDeleted).ToListAsync();
            return entities;
        }

        public async Task UpdateAsync(T entity)
        {
            await _collection.ReplaceOneAsync(e => e.Id == entity.Id, entity);
        }
    }
}
