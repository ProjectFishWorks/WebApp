using System;
using System.Timers;

namespace ProjectFishWorksWebApp.Models.DeviceModels
{
    public class LightingControlDevice : Device
    {
        private int nodeID;
        private int? _DawnTimeMins;
        private int? _DawnTimeHours;
        private int? _SunriseTimeMins;
        private int? _SunriseTimeHours;
        private int? _HighNoonMins;
        private int? _HighNoonHours;
        private int? _SunsetTimeMins;
        private int? _DuskTimeMins;
        private int? _DuskTimeHours;
        private int? _NightTimeMins;
        private int? _NightTimeHours;
        private int? _Blue_1_MaxIntensity;
        private int? _Blue_2_MaxIntensity;
        private int? _White_1_MaxIntensity;
        private int? _White_2_MaxIntensity;
        private int? _CurrentWhite_1_Intensity;
        private int? _CurrentWhite_2_Intensity;
        private int? _CurrentBlue_1_Intensity;
        private int? _CurrentBlue_2_Intensity;
        private bool _ManualOverrideSwitch = false;
        private int? _OverrideWhite_1_Intensity;
        private int? _OverrideWhite_2_Intensity;
        private int? _OverrideBlue_1_Intensity;
        private int? _OverrideBlue_2_Intensity;
        private int? _MinWhiteValue;
        private int? _inBlueValue;
        //private TimeSpan? _DawnTime = new TimeSpan();
        //private TimeSpan? _SunriseTime = new TimeSpan();
        //private TimeSpan? _DawnSunriseDifference = new TimeSpan();
        //public int? _DawnSunriseDifferenceSeconds = 0;

        public LightingControlDevice(MQTTnet.ClientLib.MqttService mqttService, int systemID, int basestationID, int nodeID) : base(mqttService, systemID, basestationID)
        {
            this.nodeID = nodeID;
        }


        /*public TimeSpan? DawnSunriseDifference
        {
            get
            {
                if (_SunriseTime.HasValue && _DawnTime.HasValue)
                {
                    _DawnSunriseDifference = _SunriseTime - _DawnTime;
                    _DawnSunriseDifferenceSeconds = (int)_DawnSunriseDifference.Value.TotalSeconds;

                    return _DawnSunriseDifference;
                }
                else
                {
                    return TimeSpan.Zero;
                }
            }
            set
            {
                _DawnSunriseDifference = _SunriseTime - _DawnTime;
                _DawnSunriseDifferenceSeconds = (int)_DawnSunriseDifference.Value.TotalSeconds;
                sendMessageData(nodeID, 2562, (ulong)_DawnSunriseDifferenceSeconds);
                Console.WriteLine("Difference in seconds: " + _DawnSunriseDifferenceSeconds);
            }
        }
        */

        public int DawnTimeMins
        {
            get
            {
                _DawnTimeMins = ((int?)getMessagePayload(nodeID, 2560).data);
                if (_DawnTimeMins.HasValue)
                {
                    return _DawnTimeMins.Value;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                _DawnTimeMins = value;
                sendMessageData(nodeID, 2560, (ulong)_DawnTimeMins);
            }
        }

        public int DawnTimeHours
        {
            get
            {
                _DawnTimeHours = ((int?)getMessagePayload(nodeID, 2561).data);
                if (_DawnTimeHours.HasValue)
                {
                    return _DawnTimeHours.Value;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                _DawnTimeHours = value;
                sendMessageData(nodeID, 2561, (ulong)_DawnTimeHours);
            }
        }

        public int DuskTimeMins
        {
            get
            {
                _DuskTimeMins = ((int?)getMessagePayload(nodeID, 2562).data);
                if (_DuskTimeMins.HasValue)
                {
                    return _DuskTimeMins.Value;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                _DuskTimeMins = value;
                sendMessageData(nodeID, 2562, (ulong)_DuskTimeMins);
            }
        }

        public int DuskTimeHours
        {
            get
            {
                _DuskTimeHours = ((int?)getMessagePayload(nodeID, 2563).data);
                if (_DuskTimeHours.HasValue)
                {
                    return _DuskTimeHours.Value;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                _DuskTimeHours = value;
                sendMessageData(nodeID, 2563, (ulong)_DuskTimeHours);
            }
        }
 
        public int SunriseTimeMins
        {
            get
            {
                _SunriseTimeMins = ((int?)getMessagePayload(nodeID, 2564).data);
                if (_SunriseTimeMins.HasValue)
                {
                    return _SunriseTimeMins.Value;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                _SunriseTimeMins = value;
                sendMessageData(nodeID, 2564, (ulong)_SunriseTimeMins);
            }
        }

        public int SunriseTimeHours
        {
            get
            {
                _SunriseTimeHours = ((int?)getMessagePayload(nodeID, 2565).data);
                if (_SunriseTimeHours.HasValue)
                {
                    return _SunriseTimeHours.Value;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                _SunriseTimeHours = value;
                sendMessageData(nodeID, 2565, (ulong)_SunriseTimeHours);
            }
        }


        public int SunsetTimeMins
        {
            get
            {
                _SunsetTimeMins = ((int?)getMessagePayload(nodeID, 2566).data);
                if (_SunsetTimeMins.HasValue)
                {
                    return _SunsetTimeMins.Value;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                _SunsetTimeMins = value;
                sendMessageData(nodeID, 2566, (ulong)_SunsetTimeMins);
            }
        }

        public int SunsetTimeHours
        {
            get
            {
                _SunsetTimeMins = ((int?)getMessagePayload(nodeID, 2567).data);
                if (_SunsetTimeMins.HasValue)
                {
                    return _SunsetTimeMins.Value;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                _SunsetTimeMins = value;
                sendMessageData(nodeID, 2567, (ulong)_SunsetTimeMins);
            }
        }

        public int HighNoonMins
        {
            get
            {
                _HighNoonMins = ((int?)getMessagePayload(nodeID, 2568).data);
                if (_HighNoonMins.HasValue)
                {
                    return _HighNoonMins.Value;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                _HighNoonMins = value;
                sendMessageData(nodeID, 2568, (ulong)_HighNoonMins);
            }
        }

        public int HighNoonHours
        {
            get
            {
                _HighNoonHours = ((int?)getMessagePayload(nodeID, 2569).data);
                if (_HighNoonHours.HasValue)
                {
                    return _HighNoonHours.Value;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                _HighNoonHours = value;
                sendMessageData(nodeID, 2569, (ulong)_HighNoonHours);
            }
        }

        public int NightTimeMins
        {
            get
            {
                _NightTimeMins = ((int?)getMessagePayload(nodeID, 2570).data);
                if (_NightTimeMins.HasValue)
                {
                    return _NightTimeMins.Value;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                _NightTimeMins = value;
                sendMessageData(nodeID, 2570, (ulong)_NightTimeMins);
            }
        }

        public int NightTimeHours
        {
            get
            {
                _NightTimeHours = ((int?)getMessagePayload(nodeID, 2571).data);
                if (_NightTimeHours.HasValue)
                {
                    return _NightTimeHours.Value;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                _NightTimeHours = value;
                sendMessageData(nodeID, 2571, (ulong)_NightTimeHours);
            }
        }

        public int Blue_1_MaxIntensity
        {
            get
            {
                _Blue_1_MaxIntensity = ((int?)getMessagePayload(nodeID, 2572).data);
                if (_Blue_1_MaxIntensity.HasValue)
                {
                    return _Blue_1_MaxIntensity.Value;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                _Blue_1_MaxIntensity = value;
                sendMessageData(nodeID, 2572, (ulong)_Blue_1_MaxIntensity);
            }
        }

        public int Blue_2_MaxIntensity
        {
            get
            {
                _Blue_2_MaxIntensity = ((int?)getMessagePayload(nodeID, 2573).data);
                if (_Blue_2_MaxIntensity.HasValue)
                {
                    return _Blue_2_MaxIntensity.Value;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                _Blue_2_MaxIntensity = value;
                sendMessageData(nodeID, 2573, (ulong)_Blue_2_MaxIntensity);
            }
        }

        


        public int White_1_MaxIntensity
        {
            get
            {
                _White_1_MaxIntensity = ((int?)getMessagePayload(nodeID, 2574).data);
                if (_White_1_MaxIntensity.HasValue)
                {
                    return _White_1_MaxIntensity.Value;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                _White_1_MaxIntensity = value;
                sendMessageData(nodeID, 2574, (ulong)_White_1_MaxIntensity);
            }
        }

        public int White_2_MaxIntensity
        {
            get
            {
                _White_2_MaxIntensity = ((int?)getMessagePayload(nodeID, 2575).data);
                if (_White_2_MaxIntensity.HasValue)
                {
                    return _White_2_MaxIntensity.Value;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                _White_2_MaxIntensity = value;
                sendMessageData(nodeID, 2575, (ulong)_White_2_MaxIntensity);
            }
        }

        public int CurrentWhite_1_Intensity
        {
            get
            {
                _CurrentWhite_1_Intensity = ((int?)getMessagePayload(nodeID, 2576).data);
                if (_CurrentWhite_1_Intensity.HasValue)
                {
                    return _CurrentWhite_1_Intensity.Value;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                _CurrentWhite_1_Intensity = value;
                sendMessageData(nodeID, 2576, (ulong)_CurrentWhite_1_Intensity);
            }
        }

        public int CurrentWhite_2_Intensity
        {
            get
            {
                _CurrentWhite_2_Intensity = ((int?)getMessagePayload(nodeID, 2577).data);
                if (_CurrentWhite_2_Intensity.HasValue)
                {
                    return _CurrentWhite_2_Intensity.Value;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                _CurrentWhite_2_Intensity = value;
                sendMessageData(nodeID, 2577, (ulong)_CurrentWhite_2_Intensity);
            }
        }

        public int CurrentBlue_1_Intensity
        {
            get
            {
                _CurrentBlue_1_Intensity = ((int?)getMessagePayload(nodeID, 2578).data);
                if (_CurrentBlue_1_Intensity.HasValue)
                {
                    return _CurrentBlue_1_Intensity.Value;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                _CurrentBlue_1_Intensity = value;
                sendMessageData(nodeID, 2578, (ulong)_CurrentBlue_1_Intensity);
            }
        }

        public int CurrentBlue_2_Intensity
        {
            get
            {
                _CurrentBlue_2_Intensity = ((int?)getMessagePayload(nodeID, 2579).data);
                if (_CurrentBlue_2_Intensity.HasValue)
                {
                    return _CurrentBlue_2_Intensity.Value;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                _CurrentBlue_2_Intensity = value;
                sendMessageData(nodeID, 2579, (ulong)_CurrentBlue_2_Intensity);
            }
        }

        public bool ManualOverrideSwitch
        {
            get
            {
                _ManualOverrideSwitch = ((int?)getMessagePayload(nodeID, 2580).data) == 1;
                return _ManualOverrideSwitch;
            }
            set
            {
                _ManualOverrideSwitch = value;
                if (_ManualOverrideSwitch)
                {
                    sendMessageData(nodeID, 2580, 1);
                }
                else
                {
                    sendMessageData(nodeID, 2580, 0);
                }
            }
        }

        public int OverrideWhite_1_Intensity
        {
            get
            {
                _OverrideWhite_1_Intensity = ((int?)getMessagePayload(nodeID, 2581).data);
                if (_OverrideWhite_1_Intensity.HasValue)
                {
                    return _OverrideWhite_1_Intensity.Value;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                _OverrideWhite_1_Intensity = value;
                sendMessageData(nodeID, 2581, (ulong)_OverrideWhite_1_Intensity);
            }
        }

        public int OverrideWhite_2_Intensity
        {
            get
            {
                _OverrideWhite_2_Intensity = ((int?)getMessagePayload(nodeID, 2582).data);
                if (_OverrideWhite_2_Intensity.HasValue)
                {
                    return _OverrideWhite_2_Intensity.Value;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                _OverrideWhite_2_Intensity = value;
                sendMessageData(nodeID, 2582, (ulong)_OverrideWhite_2_Intensity);
            }
        }

        public int OverrideBlue_1_Intensity
        {
            get
            {
                _OverrideBlue_1_Intensity = ((int?)getMessagePayload(nodeID, 2583).data);
                if (_OverrideBlue_1_Intensity.HasValue)
                {
                    return _OverrideBlue_1_Intensity.Value;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                _OverrideBlue_1_Intensity = value;
                sendMessageData(nodeID, 2583, (ulong)_OverrideBlue_1_Intensity);
            }
        }

        public int OverrideBlue_2_Intensity
        {
            get
            {
                _OverrideBlue_2_Intensity = ((int?)getMessagePayload(nodeID, 2584).data);
                if (_OverrideBlue_2_Intensity.HasValue)
                {
                    return _OverrideBlue_2_Intensity.Value;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                _OverrideBlue_2_Intensity = value;
                sendMessageData(nodeID, 2584, (ulong)_OverrideBlue_2_Intensity);
            }
        }

        public int MinWhiteValue
        {
            get
            {
                _MinWhiteValue = ((int?)getMessagePayload(nodeID, 2585).data);
                if (_MinWhiteValue.HasValue)
                {
                    return _MinWhiteValue.Value;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                _MinWhiteValue = value;
                sendMessageData(nodeID, 2585, (ulong)_MinWhiteValue);
            }
        }

        public int MinBlueValue
        {
            get
            {
                _inBlueValue = ((int?)getMessagePayload(nodeID, 2586).data);
                if (_inBlueValue.HasValue)
                {
                    return _inBlueValue.Value;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                _inBlueValue = value;
                sendMessageData(nodeID, 2586, (ulong)_inBlueValue);
            }
        }
    }
}
