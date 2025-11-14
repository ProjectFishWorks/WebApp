namespace ProjectFishWorksWebApp.Models.DeviceModels
{
    public class TerrariumSensorsDevice : Device
    {
        private int nodeID;

        public TerrariumSensorsDevice(MQTTnet.ClientLib.MqttService mqttService, string userID, int systemID, int basestationID, int nodeID) : base(mqttService, userID, systemID, basestationID)
        {
            this.nodeID = nodeID;
        }

        public List<HistoryDataRow>? TerrariumSensorsHistory { get; set; }

        public float? Temp
        {
            get
            {
                return (float?)Math.Round((decimal)getMessagePayload(nodeID, 2560).dataFloat, 2);
            }

        }

        public float? Humidity
        {
            get
            {
                return (float?)Math.Round((decimal)getMessagePayload(nodeID, 2561).dataFloat, 2);
            }
        }

        public float? SoilTemp
        {
            get
            {
                return (float?)Math.Round((decimal)getMessagePayload(nodeID, 2562).dataFloat, 2);
            }
        }

        public float? SoilMoisture
        {
            get
            {
                return (float?)Math.Round((decimal)getMessagePayload(nodeID, 2563).dataFloat, 0);
            }
        }

    }
}
