namespace ProjectFishWorksWebApp.Models
{
    public class BaseStationManifestData
    {
        public int BaseStationID { get; set; }
        public string BaseStationName { get; set; }

        public List<BaseStationManifestDeviceData> Devices { get; set; }

        public class BaseStationManifestDeviceData
        {
            public int NodeID { get; set; }
            public string DeviceType { get; set; }
            public string DeviceName { get; set; }
        }

    }
}
