using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaSprzetu.Models.Equipments
{
    public class Laptop : Equipment
    {
        public string ScreenSize { get; set; }
        public string Processor { get; set; }
        public bool HasDedicatedGraphicsCard { get; set; }
        public string GraphicsCardModel { get; set; }
        public int RAM { get; set; }
        public Laptop(string name) : base(name)
        {
        }
        public Laptop(string name, string screenSize, string processor, bool hasDedicatedGraphicsCard, string graphicsCardModel, int ram) : base(name)
        {
            Processor = processor;
            HasDedicatedGraphicsCard = hasDedicatedGraphicsCard;
            GraphicsCardModel = graphicsCardModel;
            RAM = ram;
        }
    }
}
