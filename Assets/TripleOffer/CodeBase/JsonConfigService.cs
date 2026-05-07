using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using UnityEngine;


namespace TripleOffer.CodeBase
{
    //без учета расположения в .asmdef
    
    /*public class JsonConfigService : IConfigService
    {
        private const string CONFIG_PATH = "Configs/OfferDatabase";

        public List<OfferConfig> LoadOffers()
        {
            TextAsset jsonFile = Resources.Load<TextAsset>(CONFIG_PATH);

            if (jsonFile == null)
            {
                Debug.LogError("Offer config not found");

                return new List<OfferConfig>();
            }

            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            OfferDatabaseConfig database =
                JsonConvert.DeserializeObject<OfferDatabaseConfig>(
                    jsonFile.text,
                    settings
                );

            return database.Offers;
        }
    }*/
    public class JsonConfigService : IConfigService
    {
        private const string CONFIG_PATH = "Configs/OfferDatabase";

        // Внутренний класс для маппинга имен
        public class KnownTypesBinder : DefaultSerializationBinder
        {
            public override Type BindToType(string assemblyName, string typeName)
            {
                // Если Newtonsoft видит тип без точки (короткое имя), 
                // мы принудительно ищем его в нашем неймспейсе.
                if (!typeName.Contains("."))
                {
                    return Type.GetType($"TripleOffer.CodeBase.{typeName}, Assembly-CSharp");
                }
                return base.BindToType(assemblyName, typeName);
            }
        }

        public List<OfferConfig> LoadOffers()
        {
            TextAsset jsonFile = Resources.Load<TextAsset>(CONFIG_PATH);
            if (jsonFile == null) return new List<OfferConfig>();

            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                SerializationBinder = new KnownTypesBinder() // Применяем наш биндер
            };

            var database = JsonConvert.DeserializeObject<OfferDatabaseConfig>(jsonFile.text, settings);
            return database.Offers;
        }
    }
    
}