using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB_Test.Models.EF
{
   public class Termin
    {
       
        public int Id { get; set; }
       
        public DateTime Datum { get; set; }
      
        public DateTime Uhrzeit { get; set; }
       
        public virtual ICollection<BehandlerPatientenTermin> BehandlerPatientenTermine { get; set; }

        public Termin(DateTime datum, DateTime uhrzeit)
        {
            Datum = datum;
            Uhrzeit = uhrzeit;
        }

        public Termin()
        {

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
