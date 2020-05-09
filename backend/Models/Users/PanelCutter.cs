using AspNetCore.Identity.MongoDbCore.Models;
using Furny.Data;
using Furny.Filters;
using Microsoft.AspNetCore.JsonPatch;
using MongoDB.Bson;
using MongoDbGenericRepository.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Furny.Models
{
    public class PanelCutter : ApplicationUser
    {
        public PanelCutter() : base()
        { }

        public PanelCutter(string userName, string email) : base(userName, email)
        { }

        public string Opened { get; set; }

        public string Facebook { get; set; }

        public IList<string> Extras { get; set; }

        public IList<Material> Materials { get; set; } = new List<Material>();

        internal void AddMaterial(Material material)
        {
            if(Materials.Select(e => e.Name).Contains(material.Name))
            {
                throw new HttpResponseException("Ilyen nevű anyag már van felvéve!", HttpStatusCode.BadRequest);
            }

            Materials.Add(material);
        }

        internal void RemoveMaterial(string id)
        {
            var material = GetMaterial(id);
            Materials.Remove(material);
        }

        internal Material GetMaterial(string id)
        {
            var material = Materials.SingleOrDefault(e => e.Id == ObjectId.Parse(id));

            if (material == null)
            {
                throw new HttpResponseException("Alapanyag nem található!", HttpStatusCode.BadRequest);
            }

            return material;
        }

        internal void UpdateMaterial(Material material, string mid)
        {
            RemoveMaterial(mid);
            AddMaterial(material);
        }
    }
}