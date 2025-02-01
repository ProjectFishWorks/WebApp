namespace ProjectFishWorksWebApp.Models.DeviceModels
{
    public class LeakSensorDevice : Device
    {
        private int nodeID;
        private bool _LeakDetected;
        private bool _HighWaterLevel;
        private bool _LowWaterLevel;
        private int? _LeakSensor1Sensitivity;
        private int? _LeakSensor2Sensitivity;
        private int? _LeakSensor3Sensitivity;
        private int? _LeakSensor4Sensitivity;


        public LeakSensorDevice(MQTTnet.ClientLib.MqttService mqttService, string userID,int systemID, int basestationID, int nodeID) : base(mqttService,userID ,systemID, basestationID)
        {
            this.nodeID = nodeID;
        }

        public int LeakSensor1Sensitivity
        {
            get 
            {
                _LeakSensor1Sensitivity = (int?)getMessagePayload(nodeID, 2556).data;
                if (_LeakSensor1Sensitivity.HasValue)
                {
                    return _LeakSensor1Sensitivity.Value;
                }
                else
                {
                    return 1;
                }
            }
            set
            {
                _LeakSensor1Sensitivity = value;
                sendMessageData(nodeID, 2556, (ulong)(_LeakSensor1Sensitivity));
            }
        }

        public int LeakSensor2Sensitivity
        {
            get
            {
                _LeakSensor2Sensitivity = (int?)getMessagePayload(nodeID, 2557).data;
                if (_LeakSensor2Sensitivity.HasValue)
                {
                    return _LeakSensor2Sensitivity.Value;
                }
                else
                {
                    return 1;
                }
            }
            set
            {
                _LeakSensor2Sensitivity = value;
                sendMessageData(nodeID, 2557, (ulong)_LeakSensor2Sensitivity);
            }
        }

        public int LeakSensor3Sensitivity
        {
            get
            {
                _LeakSensor3Sensitivity = (int?)getMessagePayload(nodeID, 2558).data;
                if (_LeakSensor3Sensitivity.HasValue)
                {
                    return _LeakSensor3Sensitivity.Value;
                }
                else
                {
                    return 1;
                }
            }
            set
            {
                _LeakSensor3Sensitivity = value;
                sendMessageData(nodeID, 2558, (ulong)_LeakSensor3Sensitivity);
            }
        }

        public int LeakSensor4Sensitivity
        {
            get
            {
                _LeakSensor4Sensitivity = (int?)getMessagePayload(nodeID, 2559).data;
                if (_LeakSensor4Sensitivity.HasValue)
                {
                    return _LeakSensor4Sensitivity.Value;
                }
                else
                {
                    return 1;
                }
            }
            set
            {
                _LeakSensor4Sensitivity = value;
                sendMessageData(nodeID, 2559, (ulong)_LeakSensor4Sensitivity);
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
