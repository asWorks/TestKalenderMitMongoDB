using MongoDB_Test.Models.EF;
using System.Collections.Generic;

namespace MongoDB_Test.Repositories
{
    public class TerminRepositoriyEF
    {
        private TerminModel db;

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

        public void ClearTermine()
        {
            db.Database.ExecuteSqlCommand("delete from dbo.BehandlerPatientenTermins");
            db.Database.ExecuteSqlCommand("delete from dbo.Termins");


        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }


    }
}
