using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaSprzetu.Models.Equipments
{
    public class Projector : Equipment
    {
        public string Resolution { get; set; }
        public int Lumens { get; set; }
        public bool HasHDMI { get; set; }
        public bool HasVGA { get; set; }
        public Projector(string name) : base(name)
        {
        }
    }
}
