using MongoDB.Driver;
using MongoDB_Test.Models.EF;
using System.Collections.Generic;
using System.Linq;

namespace MongoDB_Test.Repositories
{
    public class TerminRepositoriyEF
    {
        TerminModel db;

        public TerminRepositoriyEF()
        {
            db = new TerminModel();
        }

        public void addTermin(Termin t, List<BehandlerPatientenTermin> bptermine)
        {

            db.Termine.Add(t);

        }

        public void addTermine(List<Termin> termine)
        {
            db.Termine.AddRange(termine);
           
        }

        public List<Termin> GetAllTermine()
        {
            List<Termin> list = new List<Termin>(db.Termine);

            return list;
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }


    }
}
