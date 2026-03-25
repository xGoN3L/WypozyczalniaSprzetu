using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaSprzetu.Models.Equipments
{
    public abstract class Equipment
    {
        private static int _nextId = 1;
        public int Id { get; }
        public String Name { get; set; }
        public EquipmentStatus Status { get; set; }

        public Equipment(string name)
        {
            Id = _nextId++;
            Name = name;
            Status = EquipmentStatus.Available;
        }
        public override string ToString()
        {
            return $"Nazwa: {Name}, Status: {Status.ToString()}";
        }
    }
}
