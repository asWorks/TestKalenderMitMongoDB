﻿using MongoDB.Driver;
using MongoDB_Test.Models;
using System.Collections.Generic;
using System.Linq;

namespace MongoDB_Test.Repositories
{
    public class TerminRepositoriyEF
    {
        private static MongoClient client = new MongoClient();
        private static IMongoDatabase db = client.GetDatabase("TerminTestDB");
        private static IMongoCollection<Termin> collection = db.GetCollection<Termin>("Termine");

        public void addTermin(Termin t, List<BehandlerPatientenTermin> bptermine)
        {

            collection.InsertOne(t);

        }

        public void addTermine(List<Termin> termine)
        {
            collection.InsertMany(termine);
        }

        public List<Termin> GetAllTermine()
        {
            List<Termin> list = collection.AsQueryable().ToList<Termin>();
            return list;
        }


    }
}
