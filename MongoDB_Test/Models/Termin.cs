using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB_Test.Models
{
   public class Termin
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("datum")]
        public DateTime Datum { get; set; }
        [BsonElement("uhrzeit")]
        public DateTime Uhrzeit { get; set; }
        [BsonElement("behandlerPatientenTermine")]
        public List<BehandlerPatientenTermin> BehandlerPatientenTermine { get; set; }

        public Termin(DateTime datum, DateTime uhrzeit)
        {
            Datum = datum;
            Uhrzeit = uhrzeit;
        }

        public Termin(DateTime datum, DateTime uhrzeit,List<BehandlerPatientenTermin> termine)
        {
            if (BehandlerPatientenTermine==null)
            {
                BehandlerPatientenTermine = new List<BehandlerPatientenTermin>();
            }
            Datum = datum;
            Uhrzeit = uhrzeit;
            BehandlerPatientenTermine = termine;
        }


    }
}
