using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaSprzetu.Models.Equipments
{
    public class Camera : Equipment
    {
        public string Resolution { get; set; }
        public string OpticalZoom { get; set; }
        public bool WiFi { get; set; }
        public bool TouchScreen { get; set; }
        public Camera(string name) : base(name)
        {
            
        }

        public Camera(string name, string resolution, string opticalZoom, bool wiFi, bool touchScreen) : base(name)
        {
            OpticalZoom = opticalZoom;
            WiFi = wiFi;
            TouchScreen = touchScreen;
        }
    }
}
