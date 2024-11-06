namespace ProjectFishWorksWebApp.Models.DeviceModels
{
    public class ACControlDevice : Device
    {
        private int nodeID;
        public ACControlDevice(MQTTnet.ClientLib.MqttService mqttService, int systemID, int basestationID, int nodeID) : base(mqttService, systemID, basestationID)
        {
            this.nodeID = nodeID;
        }

        public List<HistoryDataRow>? CurrentHistory { get; set; }

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

        public float? LineCurrent
        {
            get
            {
                return (float)Math.Round((decimal)getMessagePayload(nodeID, 2562).dataFloat,3);
            }
        }
        public float? LineWattage
        {
            get
            {
                return (float)Math.Round((decimal)getMessagePayload(nodeID, 2562).dataFloat * 120, 2);
            }
        }
        public int RelayOneAlertNode
        {
            get
            {

                ulong? value = getMessagePayload(nodeID, 2563).data;
                if (value.HasValue)
                {
                    return (int)value.Value;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                sendMessageData(nodeID, 2563, (ulong)value);
            }
        }
        public int RelayTwoAlertNode
        {
            get
            {

                ulong? value = getMessagePayload(nodeID, 2564).data;
                if (value.HasValue)
                {
                    return (int)value.Value;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                sendMessageData(nodeID, 2564, (ulong)value);
            }
        }
        public bool RelayOneInAlert
        {
            get
            {
               return (getMessagePayload(RelayOneAlertNode, 901).data == 1 || getMessagePayload(RelayOneAlertNode, 900).data == 1);
            }
        }
        public bool RelayTwoInAlert
        {
            get
            {
                return (getMessagePayload(RelayTwoAlertNode, 901).data == 1 || getMessagePayload(RelayTwoAlertNode, 900).data == 1);
            }
        }
}
}
