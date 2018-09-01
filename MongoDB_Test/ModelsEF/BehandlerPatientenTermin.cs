using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB_Test.Models.EF
{
    public class BehandlerPatientenTermin
    {
       
        public Guid Id { get; set; }
    
        public DateTime Datum { get; set; }
    
        public DateTime Uhrzeit { get; set; }

     
        public int BehandlerID { get; set; }

      
        public int PatientenID { get; set; }

        public string PatientenName { get; set; }

       
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
