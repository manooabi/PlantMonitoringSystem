using Microsoft.VisualBasic;
using System.Collections.ObjectModel;

namespace PlantMonitoringSystem.Models
{
    public class Plants_Monitoring_App
    {
        public int Growth { get; set; }
        public int Humidity { get; set; }
        public int Light_Level { get; set; }

        public int Tempurature { get; set; }
        public virtual Collection<Soil_Moisture> sol_moisture { get; set; }

    }
    public class Soil_Moisture
    {
        public int LastState { get; set; }
        public int SensorState { get; set; }
    }

}
