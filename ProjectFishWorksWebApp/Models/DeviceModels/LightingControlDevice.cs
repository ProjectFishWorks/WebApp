namespace ProjectFishWorksWebApp.Models.DeviceModels
{
    public class LightingControlDevice : Device
    {
        private int nodeID;
        private int _DawnTime = 0;
        private int _DuskTime = 0;
        private int _SunriseTime = 0;
        private int _SunsetTime = 0;
        private int _HighNoon = 0;
        private int _NightTime = 0;
        private decimal _BlueOnlyMaxIntensity = 0;
        private int _CurrentWhiteIntensity = 0;
        private int _CurrentBlueIntensity = 0;
        private bool _ManualLEDControlOverrideSwitch;
        private int _OverrideWhiteIntensity = 0;
        private int _OverrideBlueIntensity = 0;
        public LightingControlDevice(MQTTnet.ClientLib.MqttService mqttService, int systemID, int basestationID, int nodeID) : base(mqttService, systemID, basestationID)
        {
            this.nodeID = nodeID;
        }


        public int DawnTime
        {
            get
            {
                _DawnTime = ((int)getMessagePayload(nodeID, 2562).data);
                return _DawnTime / 1000;
            }
            set
            {
                _DawnTime = value;
                sendMessageData(nodeID, 2562, (ulong)_DawnTime * 1000);
            }
        }

        public int DuskTime
        {
            get
            {
                _DuskTime = ((int)getMessagePayload(nodeID, 2563).data);
                return _DuskTime / 1000;
            }
            set
            {
                _DuskTime = value;
                sendMessageData(nodeID, 2563, (ulong)_DuskTime * 1000);
            }
        }

        public int SunriseTime
        {
            get
            {
                _SunriseTime = ((int)getMessagePayload(nodeID, 2564).data);
                return _SunriseTime / 1000;
            }
            set
            {
                _SunriseTime = value;
                sendMessageData(nodeID, 2564, (ulong)_SunriseTime * 1000);
            }
        }

        public int SunsetTime
        {
            get
            {
                _SunsetTime = ((int)getMessagePayload(nodeID, 2565).data);
                return _SunsetTime / 1000;
            }
            set
            {
                _SunsetTime = value;
                sendMessageData(nodeID, 2565, (ulong)_SunsetTime * 1000);
            }
        }

        public int HighNoon
        {
            get
            {
                _HighNoon = ((int)getMessagePayload(nodeID, 2566).data);
                return _HighNoon / 1000;
            }
            set
            {
                _HighNoon = value;
                sendMessageData(nodeID, 2566, (ulong)_HighNoon * 1000);
            }
        }

        public int NightTime
        {
            get
            {
                _NightTime = ((int)getMessagePayload(nodeID, 2567).data);
                return _NightTime / 1000;
            }
            set
            {
                _NightTime = value;
                sendMessageData(nodeID, 2567, (ulong)_NightTime * 1000);
            }
        }

        public decimal BlueOnlyMaxIntensity
        {
            get
            {
                _BlueOnlyMaxIntensity = ((decimal)getMessagePayload(nodeID, 2568).data);
                return _BlueOnlyMaxIntensity;
            }
            set
            {
                _BlueOnlyMaxIntensity = value;
                sendMessageData(nodeID, 2568, (ulong)_BlueOnlyMaxIntensity);
            }
        }

        public int CurrentWhiteIntensity
        {
            get
            {
                return (int)getMessagePayload(nodeID, 2569).data;
            }
        }


        public int CurrentBlueIntensity
        {
            get
            {
                return (int)getMessagePayload(nodeID, 2570).data;
            }
        }

        public bool ManualLEDControlOverrideSwitch
        {
            get
            {
                {
                    if (getMessagePayload(nodeID, 2571).data == 1)
                    {
                        _ManualLEDControlOverrideSwitch = true;
                    }
                    else
                    {
                        _ManualLEDControlOverrideSwitch = false;
                    }
                    return _ManualLEDControlOverrideSwitch;
                }
            }
            set
            {
                _ManualLEDControlOverrideSwitch = value;
                sendMessageData(nodeID, 2571, (ulong)(_ManualLEDControlOverrideSwitch ? 1 : 0));
            }
        }

        public int OverrideWhiteIntensity
        {
            get
            {
                _OverrideWhiteIntensity = ((int)getMessagePayload(nodeID, 2573).data);
                return _OverrideWhiteIntensity;
            }
            set
            {
                _OverrideWhiteIntensity = value;
                sendMessageData(nodeID, 2572, (ulong)_OverrideWhiteIntensity);
            }
        }

        public int OverrideBlueIntensity
        {
            get
            {
                _OverrideBlueIntensity = ((int)getMessagePayload(nodeID, 2573).data);
                return _OverrideBlueIntensity;
            }
            set
            {
                _OverrideBlueIntensity = value;
                sendMessageData(nodeID, 2573, (ulong)_OverrideBlueIntensity);
            }
        }

    }
}
