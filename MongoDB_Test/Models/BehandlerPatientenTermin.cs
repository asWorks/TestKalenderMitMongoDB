using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB_Test.Models
{
    public class BehandlerPatientenTermin
    {
        [BsonId]
        public Guid Id { get; set; }
        [BsonElement("datum")]
        public DateTime Datum { get; set; }
        [BsonElement("uhrzeit")]
        public DateTime Uhrzeit { get; set; }

        [BsonElement("behandlerID")]
        public int BehandlerID { get; set; }

        [BsonElement("patientenID")]
        public int PatientenID { get; set; }

        [BsonElement("patientenName")]
        public string PatientenName { get; set; }

        [BsonElement("behandlerName")]
        public string BehandlerName { get; set; }


        public BehandlerPatientenTermin(DateTime datum,DateTime uhrzeit,int behandlerID,
                                        int patientenID, string behandlerName, string patientenName)
        {
            Id = Guid.NewGuid();
            Datum = datum;
            Uhrzeit = uhrzeit;
            BehandlerID = behandlerID;
            PatientenID = patientenID;
            BehandlerName = behandlerName;
            PatientenName = patientenName;
        }


    }
}
