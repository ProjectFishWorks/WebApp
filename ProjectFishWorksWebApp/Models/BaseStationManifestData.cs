namespace ProjectFishWorksWebApp.Models
{
    public class BaseStationManifestData
    {
        public int SystemID { get; set; }
        public int BaseStationID { get; set; }
        public string BaseStationName { get; set; }

        public List<DeviceData> Devices { get; set; }

        public class DeviceData
        {
            public int NodeID { get; set; }
            public string DeviceType { get; set; }
            public string DeviceName { get; set; }
        }

    }
}
