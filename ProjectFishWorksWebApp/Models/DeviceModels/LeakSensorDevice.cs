namespace ProjectFishWorksWebApp.Models.DeviceModels
{
    public class LeakSensorDevice : Device
    {
        private int nodeID;
        private bool _LeakDetected;
        private bool _HighWaterLevel;
        private bool _LowWaterLevel;


        public LeakSensorDevice(MQTTnet.ClientLib.MqttService mqttService, int systemID, int basestationID, int nodeID) : base(mqttService, systemID, basestationID)
        {
            this.nodeID = nodeID;
        }


        public bool LeakDetected
        {
            get
            {
                _LeakDetected = getMessagePayload(nodeID, 2560).data == 1;
                return _LeakDetected;
            }
            set
            {
                _LeakDetected = value;
                sendMessageData(nodeID, 2560, (ulong)(_LeakDetected ? 1 : 0));
            }
        }


        public bool HighWaterLevel
        {
            get
            {
                _HighWaterLevel = getMessagePayload(nodeID, 2561).data == 1;
                return _HighWaterLevel;
            }
            set
            {
                _HighWaterLevel = value;
                sendMessageData(nodeID, 2561, (ulong)(_HighWaterLevel ? 1 : 0));
            }
        }

        public bool LowWaterLevel
        {
            get
            {
                _LowWaterLevel = getMessagePayload(nodeID, 2562).data == 1;
                return _LowWaterLevel;
            }
            set
            {
                _LowWaterLevel = value;
                sendMessageData(nodeID, 2562, (ulong)(_LowWaterLevel ? 1 : 0));
            }
        }
        /*#define NODE_ID 0xB2              // 178
#define LEAK_DETECTED_MESSAGE_ID 0x0A00    // 2560
#define HIGH_WATER_LEVEL_MESSAGE_ID 0x0A01   // 2561
        */
    }
}
