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

        public IList<Ad> Ads { get; set; } = new List<Ad>();

        internal void AddMaterial(Material material)
        {
            if(Materials.Select(e => e.Name).Contains(material.Name))
            {
                throw new HttpResponseException("Ilyen nevű anyag már van felvéve!", HttpStatusCode.BadRequest);
            }

            Materials.Add(material);
        }

        internal void RemoveAd(string id)
        {
            var ad = GetAd(id);
            Ads.Remove(ad);
        }

        internal Ad GetAd(string id)
        {
            var ad = Ads.SingleOrDefault(e => e.Id == ObjectId.Parse(id));

            if (ad == null)
            {
                throw new HttpResponseException("Hirdetés nem található!", HttpStatusCode.BadRequest);
            }

            return ad;
        }

        internal void AddAd(Ad ad)
        {
            Ads.Add(ad);
        }

        internal void UpdateAd(Ad ad, string id)
        {
            RemoveAd(id);
            AddAd(ad);
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

        internal void UpdateMaterial(Material material, string id)
        {
            RemoveMaterial(id);
            AddMaterial(material);
        }
    }
}