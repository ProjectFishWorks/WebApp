namespace ProjectFishWorksWebApp.Models.DeviceModels
{
    public class LeakSensorDevice : Device
    {
        private int nodeID;
        private bool _LeakDetected;
        private bool _HighWaterLevel;
        private bool _LowWaterLevel;
        private int _LeakSensorSensitivity;


        public LeakSensorDevice(MQTTnet.ClientLib.MqttService mqttService, int systemID, int basestationID, int nodeID) : base(mqttService, systemID, basestationID)
        {
            this.nodeID = nodeID;
        }

        public int LeakSensorSensitivity
        {
            get 
            {
                _LeakSensorSensitivity = (int)(int?)getMessagePayload(nodeID, 2559).data;
                return _LeakSensorSensitivity;
            }
            set
            {
                _LeakSensorSensitivity = value;
                sendMessageData(nodeID, 2559, (ulong)_LeakSensorSensitivity);
            }
        }

        public bool Leak1Detected
        {
            get
            {
                _LeakDetected = getMessagePayload(nodeID, 2561).data == 1;
                return _LeakDetected;
            }
            set
            {
                _LeakDetected = value;
                sendMessageData(nodeID, 2560, (ulong)(_LeakDetected ? 1 : 0));
            }
        }
        public bool Leak2Detected
        {
            get
            {
                _LeakDetected = getMessagePayload(nodeID, 2562).data == 1;
                return _LeakDetected;
            }
            set
            {
                _LeakDetected = value;
                sendMessageData(nodeID, 2560, (ulong)(_LeakDetected ? 1 : 0));
            }
        }
        public bool Leak3Detected
        {
            get
            {
                _LeakDetected = getMessagePayload(nodeID, 2563).data == 1;
                return _LeakDetected;
            }
            set
            {
                _LeakDetected = value;
                sendMessageData(nodeID, 2560, (ulong)(_LeakDetected ? 1 : 0));
            }
        }
        public bool Leak4Detected
        {
            get
            {
                _LeakDetected = getMessagePayload(nodeID, 2564).data == 1;
                return _LeakDetected;
            }
            set
            {
                _LeakDetected = value;
                sendMessageData(nodeID, 2560, (ulong)(_LeakDetected ? 1 : 0));
            }
        }


        public bool HighWaterLevel1
        {
            get
            {
                _HighWaterLevel = getMessagePayload(nodeID, 2817).data == 1;
                return _HighWaterLevel;
            }
            set
            {
                _HighWaterLevel = value;
                sendMessageData(nodeID, 2817, (ulong)(_HighWaterLevel ? 1 : 0));
            }
        }
        public bool HighWaterLevel2
        {
            get
            {
                _HighWaterLevel = getMessagePayload(nodeID, 2818).data == 1;
                return _HighWaterLevel;
            }
            set
            {
                _HighWaterLevel = value;
                sendMessageData(nodeID, 2818, (ulong)(_HighWaterLevel ? 1 : 0));
            }
        }
        public bool HighWaterLevel3
        {
            get
            {
                _HighWaterLevel = getMessagePayload(nodeID, 2819).data == 1;
                return _HighWaterLevel;
            }
            set
            {
                _HighWaterLevel = value;
                sendMessageData(nodeID, 2819, (ulong)(_HighWaterLevel ? 1 : 0));
            }
        }
        public bool HighWaterLevel4
        {
            get
            {
                _HighWaterLevel = getMessagePayload(nodeID, 2820).data == 1;
                return _HighWaterLevel;
            }
            set
            {
                _HighWaterLevel = value;
                sendMessageData(nodeID, 2820, (ulong)(_HighWaterLevel ? 1 : 0));
            }
        }


    }
}
