namespace ProjectFishWorksWebApp.Models.DeviceModels
{
    public class LightingControlDevice : Device
    {
        private int nodeID;
        private int? _DawnTime = 0;
        private int? _DuskTime = 0;
        private int? _SunriseTime = 0;
        private int? _SunsetTime = 0;
        private int? _HighNoon = 0;
        private int? _NightTime = 0;
        private int? _BlueOnlyMaxIntensity = 0;
        private int? _CurrentWhiteIntensity = 0;
        private int? _CurrentBlueIntensity = 0;
        private bool _ManualLEDControlOverrideSwitch = false;
        private int? _OverrideWhiteIntensity = 0;
        private int? _OverrideBlueIntensity = 0;
        private int? _MaxWhiteIntensity = 0;
        private int? _MaxBlueIntensity = 0;

        public LightingControlDevice(MQTTnet.ClientLib.MqttService mqttService, int systemID, int basestationID, int nodeID) : base(mqttService, systemID, basestationID)
        {
            this.nodeID = nodeID;
        }


        public int DawnTime
        {
            get
            {
                _DawnTime = ((int?)getMessagePayload(nodeID, 2562).data);
                if( _DawnTime.HasValue)
                {

                    return _DawnTime.Value / 1000;

                }
                else
                {
                    return -1;
                }
            }
            set
            {
                Console.WriteLine("Setting Dawn Time");
                _DawnTime = value;
                sendMessageData(nodeID, 2562, (ulong)_DawnTime * 1000);
            }
        }

        public int DuskTime
        {
            get
            {
                _DuskTime = ((int?)getMessagePayload(nodeID, 2563).data);
                if (_DuskTime.HasValue)
                {
                    return _DuskTime.Value / 1000;
                }
                else
                {
                    return -1;
                }

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
                _SunriseTime = ((int?)getMessagePayload(nodeID, 2564).data);
                if (_SunriseTime.HasValue)
                {
                    return _SunriseTime.Value / 1000;
                }
                else
                {
                    return -1;
                }

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
                _SunsetTime = ((int?)getMessagePayload(nodeID, 2565).data);
                if (_SunsetTime.HasValue)
                {
                    return _SunsetTime.Value / 1000;
                }
                else
                {
                    return -1;
                }

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
                _HighNoon = ((int?)getMessagePayload(nodeID, 2566).data);
                if (_HighNoon.HasValue){
                    return _HighNoon.Value / 1000;
                }
                else
                {
                    return -1; 
                }
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
                _NightTime = ((int?)getMessagePayload(nodeID, 2567).data);
                if (_NightTime.HasValue)
                {
                    return _NightTime.Value / 1000;
                }
                else
                {
                    return -1;
                }

            }
            set
            {
                _NightTime = value;
                sendMessageData(nodeID, 2567, (ulong)_NightTime * 1000);
            }
        }

        public int BlueOnlyMaxIntensity
        {
            get
            {
                _BlueOnlyMaxIntensity = ((int?)getMessagePayload(nodeID, 2568).data);
                if (_BlueOnlyMaxIntensity.HasValue)
                {
                    return _BlueOnlyMaxIntensity.Value;
                }
                else
                {
                    return -1;
                }
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
                int? value = (int?)getMessagePayload(nodeID, 2569).data;

                if (value.HasValue)
                {
                    return value.Value;
                }
                else
                {
                    return -1;
                }

            }
        }


        public int CurrentBlueIntensity
        {
            get
            {
                int? value = (int?)getMessagePayload(nodeID, 2570).data;

                if (value.HasValue)
                {
                    return value.Value;
                }
                else
                {
                    return -1;
                }
            }
        }

        public bool ManualLEDControlOverrideSwitch
        {
            get
            {
                bool value = (getMessagePayload(nodeID, 2571).data == 1);
                return value;

            }
            set
            {
                sendMessageData(nodeID, 2571, (ulong)(value ? 1 : 0));
            }
        }

        public int OverrideWhiteIntensity
        {
            get
            {
                _OverrideWhiteIntensity = ((int?)getMessagePayload(nodeID, 2572).data);
                if( _OverrideWhiteIntensity != null)
                {
                    return _OverrideWhiteIntensity.Value;
                }
                else
                {
                    return 0;
                }

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
                _OverrideBlueIntensity = ((int?)getMessagePayload(nodeID, 2573).data);
                if (_OverrideBlueIntensity != null)
                { 
                    return _OverrideBlueIntensity.Value; 
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                _OverrideBlueIntensity = value;
                sendMessageData(nodeID, 2573, (ulong)_OverrideBlueIntensity);
            }
        }

        public int MaxWhiteIntensity
        {
            get
            {
                _MaxWhiteIntensity = ((int?)getMessagePayload(nodeID, 2574).data);
                if (_MaxWhiteIntensity.HasValue)
                {
                    return _MaxWhiteIntensity.Value;
                }
                else
                {
                    return 100;
                }
            }
            set
            {
                _MaxWhiteIntensity = value;
                sendMessageData(nodeID, 2574, (ulong)_MaxWhiteIntensity);
                Console.WriteLine("MaxWhiteIntensity: " + _MaxWhiteIntensity.Value);
            }
        }

        public int MaxBlueIntensity
        {
            get
            {
                _MaxBlueIntensity = ((int?)getMessagePayload(nodeID, 2575).data);
                if (_MaxBlueIntensity.HasValue)
                {
                    return _MaxBlueIntensity.Value;
                }
                else
                {
                    return 100;
                }
            }
            set
            {
                _MaxBlueIntensity = value;
                sendMessageData(nodeID, 2575, (ulong)_MaxBlueIntensity);
                Console.WriteLine("MaxBlueIntensity: " + _MaxBlueIntensity.Value);
            }
        }

    }
}
