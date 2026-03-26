using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaSprzetu.Models.Equipments
{
    public enum EquipmentStatus
    {
        [Description("Dostępny")]
        Available = 0,
        [Description("Wypożyczony")]
        Borrowed = 1,
        [Description("Niedostępny")]
        Unvailable = 2
    }
}
