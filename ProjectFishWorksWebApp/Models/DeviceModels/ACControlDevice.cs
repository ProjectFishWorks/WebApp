namespace ProjectFishWorksWebApp.Models.DeviceModels
{
    public class ACControlDevice : Device
    {
        private int nodeID;
        public ACControlDevice(MQTTnet.ClientLib.MqttService mqttService, int systemID, int basestationID, int nodeID) : base(mqttService, systemID, basestationID)
        {
            this.nodeID = nodeID;
        }
        public bool Relay1Control
        {
            get
            {
                return getMessagePayload(nodeID, 2560).data == 1;
            }
            set
            {
                sendMessageData(nodeID,2560,value ?  (ulong)1 : (ulong)0);
            }
        }

        public bool Relay2Control
        {
            get
            {
                return getMessagePayload(nodeID, 2561).data == 1;
            }
            set
            {
                sendMessageData(nodeID, 2561, value ? (ulong)1 : (ulong)0);
            }
        }
    }
}
