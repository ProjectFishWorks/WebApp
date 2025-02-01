namespace ProjectFishWorksWebApp.Models.DeviceModels
{
    public class TerraruimSensorsDevice : Device
    {
        private int nodeID;

        public TerraruimSensorsDevice(MQTTnet.ClientLib.MqttService mqttService, string clientID, int systemID, int basestationID, int nodeID) : base(mqttService, clientID, systemID, basestationID)
        {
            this.nodeID = nodeID;
        }

        public List<HistoryDataRow>? TerraruimSensorsHistory { get; set; }

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
