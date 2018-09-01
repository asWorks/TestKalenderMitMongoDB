using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB_Test.Models.EF
{
    public class BehandlerPatientenTermin:INotifyPropertyChanged
    {
       
        public int Id { get; set; }
    
        public DateTime Datum { get; set; }
    
        public DateTime Uhrzeit { get; set; }

     
        public int BehandlerID { get; set; }


        //public int PatientenID { get; set; }

        //public string PatientenName { get; set; }


        private int _PatientenID;
        public int PatientenID
        {
            get { return _PatientenID; }
            set
            {
                if (value != _PatientenID)
                {
                    _PatientenID = value;
                    OnPropertyChanged("PatientenID");
                    //  isDirty = true;
                }
            }
        }

        private string _PatientenName;
        public string PatientenName
        {
            get { return _PatientenName; }
            set
            {
                if (value != _PatientenName)
                {
                    _PatientenName = value;
                    OnPropertyChanged("PatientenName");
                    //  isDirty = true;
                }
            }
        }


        public string BehandlerName { get; set; }


        public BehandlerPatientenTermin()
        {

        }

        public BehandlerPatientenTermin(DateTime datum,DateTime uhrzeit,int behandlerID,
                                        int patientenID, string behandlerName, string patientenName)
        {
            
            Datum = datum;
            Uhrzeit = uhrzeit;
            BehandlerID = behandlerID;
            PatientenID = patientenID;
            BehandlerName = behandlerName;
            PatientenName = patientenName;
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }


    }
}
