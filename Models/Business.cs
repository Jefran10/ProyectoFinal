using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Models
{
    internal class Business
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string category { get; set; }
        public decimal latitude { get; set; }
        public decimal lingitude { get; set; }
        public string description { get; set; }
    }
}
