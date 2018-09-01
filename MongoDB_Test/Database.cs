using MongoDB_Test.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MongoDB_Test
{
    public static class Database
    {

        public static event Action<long> MessageTime;

        public static void onRaiseMessageTime(long msg)
        {
            if (MessageTime != null)
            {
                MessageTime(msg);
            }
        }
        public static List<Patient> GetPatienten()
        {
            List<Patient> liste = new List<Patient> { new Patient { Id = 1, Name = "Arpad Stöver" }, new Patient { Id = 2, Name = "Michael Stöver" } };
            return liste;
        }

        public static List<Behandler> GetBehandler()
        {
            List<Behandler> liste = new List<Behandler> { new Behandler { Id = 1, Name = "Mariann" }
                                                        , new Behandler { Id = 2, Name = "Maggie" }
                                                        , new Behandler {Id=3,Name="Alexander"}



                                                            };
            return liste;
        }

    


        public static List<Termin> GetTermine()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            List<Termin> liste = new List<Termin>();
            DateTime StartTi = new DateTime(2018, 09, 1, 8, 0, 0);
            DateTime CurrTi = StartTi;
            DateTime StartDat = new DateTime(2018, 9, 1, 0, 0, 0);
            List<BehandlerPatientenTermin> L;


            for (int i = 1; i < 31; i++)
            {
                CurrTi = StartTi;
                for (int j = 0; j < 24; j++)
                {


                    L = new List<BehandlerPatientenTermin>();
                    foreach (var item in GetBehandler())
                    {
                        L.Add(new BehandlerPatientenTermin(StartDat, CurrTi, item.Id, 1, item.Name, "Arpad Stöver"));
                    }

                    Termin t = new Termin(StartDat, CurrTi, L);
                    liste.Add(t);
                    CurrTi = CurrTi.AddMinutes(30);
                }

                StartDat = StartDat.AddDays(1);

            }

            var res = sw.ElapsedMilliseconds;
            onRaiseMessageTime(res);

            return liste;
        }

    }
}
