﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedGroup.Domains
{
    public class Locais
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [BsonElement("latitude")]
        [BsonRequired]
        public string Latitude { get; set; }
        [BsonElement("longitude")]
        public string Longitude { get; set; }
    }
}
