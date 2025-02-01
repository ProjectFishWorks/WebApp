using System;
using System.ComponentModel;
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
        private int? _SunsetTimeHours;
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
        private int? _MinBlueValue;

        public LightingControlDevice(MQTTnet.ClientLib.MqttService mqttService, string userID,int systemID, int basestationID, int nodeID) : base(mqttService, userID, systemID, basestationID)
        {
            this.nodeID = nodeID;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public int DawnTimeMins
        {
            get
            {
                ulong? value = getMessagePayload(nodeID, 25060).data;
                Console.WriteLine($"Get value DawnTimeMins : {value}");
                return value.HasValue ? (int)value.Value : 1;
            }
            set
            {
                if (_DawnTimeMins != value)
                {
                    _DawnTimeMins = value;
                    Console.WriteLine($"Set value _DawnTimeMins : {_DawnTimeMins}");
                    sendMessageData(nodeID, 25060, (ulong)value);
                    OnPropertyChanged(nameof(DawnTimeMins));
                }
            }
        }

        public int DawnTimeHours
        {
            get
            {
                ulong? value = getMessagePayload(nodeID, 25061).data;
                Console.WriteLine($"Get value DawnTimeHours : {value}");
                return value.HasValue ? (int)value.Value : 1;
            }
            set
            {
                if (_DawnTimeHours != value)
                {
                    _DawnTimeHours = value;
                    Console.WriteLine($"Set value _DawnTimeHours : {_DawnTimeHours}");
                    sendMessageData(nodeID, 25061, (ulong)value);
                    OnPropertyChanged(nameof(DawnTimeHours));
                }
            }
        }

        public int DuskTimeMins
        {
            get
            {
                ulong? value = getMessagePayload(nodeID, 25062).data;
                Console.WriteLine($"Get value DuskTimeMins : {value}");
                return value.HasValue ? (int)value.Value : 1;
            }
            set
            {
                if (_DuskTimeMins != value)
                {
                    _DuskTimeMins = value;
                    Console.WriteLine($"Set value _DuskTimeMins : {_DuskTimeMins}");
                    sendMessageData(nodeID, 25062, (ulong)value);
                    OnPropertyChanged(nameof(DuskTimeMins));
                }
            }
        }

        public int DuskTimeHours
        {
            get
            {
                ulong? value = getMessagePayload(nodeID, 25063).data;
                Console.WriteLine($"Get value DuskTimeHours : {value}");
                return value.HasValue ? (int)value.Value : 1;
            }
            set
            {
                if (_DuskTimeHours != value)
                {
                    _DuskTimeHours = value;
                    Console.WriteLine($"Set value _DuskTimeHours : {_DuskTimeHours}");
                    sendMessageData(nodeID, 25063, (ulong)value);
                    OnPropertyChanged(nameof(DuskTimeHours));
                }
            }
        }

        public int SunriseTimeMins
        {
            get
            {
                ulong? value = getMessagePayload(nodeID, 25064).data;
                Console.WriteLine($"Get value SunriseTimeMins : {value}");
                return value.HasValue ? (int)value.Value : 1;
            }
            set
            {
                if (_SunriseTimeMins != value)
                {
                    _SunriseTimeMins = value;
                    Console.WriteLine($"Set value _SunriseTimeMins : {_SunriseTimeMins}");
                    sendMessageData(nodeID, 25064, (ulong)value);
                    OnPropertyChanged(nameof(SunriseTimeMins));
                }
            }
        }

        public int SunriseTimeHours
        {
            get
            {
                ulong? value = getMessagePayload(nodeID, 25065).data;
                Console.WriteLine($"Get value SunriseTimeHours : {value}");
                return value.HasValue ? (int)value.Value : 1;
            }
            set
            {
                if (_SunriseTimeHours != value)
                {
                    _SunriseTimeHours = value;
                    Console.WriteLine($"Set value _SunriseTimeHours : {_SunriseTimeHours}");
                    sendMessageData(nodeID, 25065, (ulong)value);
                    OnPropertyChanged(nameof(SunriseTimeHours));
                }
            }
        }


        public int SunsetTimeMins
        {
            get
            {
                _SunsetTimeMins = ((int?)getMessagePayload(nodeID, 25066).data);
                if (_SunsetTimeMins.HasValue)
                {
                    return _SunsetTimeMins.Value;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                _SunsetTimeMins = value;
                sendMessageData(nodeID, 25066, (ulong)_SunsetTimeMins);
            }
        }

        public int SunsetTimeHours
        {
            get
            {
                _SunsetTimeHours = ((int?)getMessagePayload(nodeID, 25067).data);
                if (_SunsetTimeHours.HasValue)
                {
                    return _SunsetTimeHours.Value;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                _SunsetTimeHours = value;
                sendMessageData(nodeID, 25067, (ulong)_SunsetTimeHours);
            }
        }

        public int HighNoonMins
        {
            get
            {
                _HighNoonMins = ((int?)getMessagePayload(nodeID, 25068).data);
                if (_HighNoonMins.HasValue)
                {
                    return _HighNoonMins.Value;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                _HighNoonMins = value;
                sendMessageData(nodeID, 25068, (ulong)_HighNoonMins);
            }
        }

        public int HighNoonHours
        {
            get
            {
                _HighNoonHours = ((int?)getMessagePayload(nodeID, 25069).data);
                if (_HighNoonHours.HasValue)
                {
                    return _HighNoonHours.Value;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                _HighNoonHours = value;
                sendMessageData(nodeID, 25069, (ulong)_HighNoonHours);
            }
        }

        public int NightTimeMins
        {
            get
            {
                _NightTimeMins = ((int?)getMessagePayload(nodeID, 25070).data);
                if (_NightTimeMins.HasValue)
                {
                    return _NightTimeMins.Value;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                _NightTimeMins = value;
                sendMessageData(nodeID, 25070, (ulong)_NightTimeMins);
            }
        }

        public int NightTimeHours
        {
            get
            {
                _NightTimeHours = ((int?)getMessagePayload(nodeID, 25071).data);
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
                sendMessageData(nodeID, 25071, (ulong)_NightTimeHours);
            }
        }

        public int Blue_1_MaxIntensity
        {
            get
            {
                _Blue_1_MaxIntensity = ((int?)getMessagePayload(nodeID, 25072).data);
                if (_Blue_1_MaxIntensity.HasValue)
                {
                    return _Blue_1_MaxIntensity.Value;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                _Blue_1_MaxIntensity = value;
                sendMessageData(nodeID, 25072, (ulong)_Blue_1_MaxIntensity);
            }
        }

        public int Blue_2_MaxIntensity
        {
            get
            {
                _Blue_2_MaxIntensity = ((int?)getMessagePayload(nodeID, 25073).data);
                if (_Blue_2_MaxIntensity.HasValue)
                {
                    return _Blue_2_MaxIntensity.Value;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                _Blue_2_MaxIntensity = value;
                sendMessageData(nodeID, 25073, (ulong)_Blue_2_MaxIntensity);
            }
        }
            
        public int White_1_MaxIntensity
        {
            get
            {
                _White_1_MaxIntensity = ((int?)getMessagePayload(nodeID, 25074).data);
                if (_White_1_MaxIntensity.HasValue)
                {
                    return _White_1_MaxIntensity.Value;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                _White_1_MaxIntensity = value;
                sendMessageData(nodeID, 25074, (ulong)_White_1_MaxIntensity);
            }
        }

        public int White_2_MaxIntensity
        {
            get
            {
                _White_2_MaxIntensity = ((int?)getMessagePayload(nodeID, 25075).data);
                if (_White_2_MaxIntensity.HasValue)
                {
                    return _White_2_MaxIntensity.Value;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                _White_2_MaxIntensity = value;
                sendMessageData(nodeID, 25075, (ulong)_White_2_MaxIntensity);
            }
        }

        public int CurrentWhite_1_Intensity
        {
            get
            {
                _CurrentWhite_1_Intensity = ((int?)getMessagePayload(nodeID, 25076).data);
                if (_CurrentWhite_1_Intensity.HasValue)
                {
                    return _CurrentWhite_1_Intensity.Value;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                _CurrentWhite_1_Intensity = value;
                sendMessageData(nodeID, 25076, (ulong)_CurrentWhite_1_Intensity);
            }
        }

        public int CurrentWhite_2_Intensity
        {
            get
            {
                _CurrentWhite_2_Intensity = ((int?)getMessagePayload(nodeID, 25077).data);
                if (_CurrentWhite_2_Intensity.HasValue)
                {
                    return _CurrentWhite_2_Intensity.Value;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                _CurrentWhite_2_Intensity = value;
                sendMessageData(nodeID, 25077, (ulong)_CurrentWhite_2_Intensity);
            }
        }

        public int CurrentBlue_1_Intensity
        {
            get
            {
                _CurrentBlue_1_Intensity = ((int?)getMessagePayload(nodeID, 25078).data);
                if (_CurrentBlue_1_Intensity.HasValue)
                {
                    return _CurrentBlue_1_Intensity.Value;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                _CurrentBlue_1_Intensity = value;
                sendMessageData(nodeID, 25078, (ulong)_CurrentBlue_1_Intensity);
            }
        }

        public int CurrentBlue_2_Intensity
        {
            get
            {
                _CurrentBlue_2_Intensity = ((int?)getMessagePayload(nodeID, 25079).data);
                if (_CurrentBlue_2_Intensity.HasValue)
                {
                    return _CurrentBlue_2_Intensity.Value;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                _CurrentBlue_2_Intensity = value;
                sendMessageData(nodeID, 25079, (ulong)_CurrentBlue_2_Intensity);
            }
        }

        public bool ManualOverrideSwitch
        {
            get
            {
                _ManualOverrideSwitch = ((int?)getMessagePayload(nodeID, 25080).data) == 1;
                return _ManualOverrideSwitch;
            }
            set
            {
                _ManualOverrideSwitch = value;
                if (_ManualOverrideSwitch)
                {
                    sendMessageData(nodeID, 25080, 1);
                }
                else
                {
                    sendMessageData(nodeID, 25080, 0);
                }
            }
        }

        public int OverrideWhite_1_Intensity
        {
            get
            {
                _OverrideWhite_1_Intensity = ((int?)getMessagePayload(nodeID, 25081).data);
                if (_OverrideWhite_1_Intensity.HasValue)
                {
                    return _OverrideWhite_1_Intensity.Value;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                _OverrideWhite_1_Intensity = value;
                sendMessageData(nodeID, 25081, (ulong)_OverrideWhite_1_Intensity);
            }
        }

        public int OverrideWhite_2_Intensity
        {
            get
            {
                _OverrideWhite_2_Intensity = ((int?)getMessagePayload(nodeID, 25082).data);
                if (_OverrideWhite_2_Intensity.HasValue)
                {
                    return _OverrideWhite_2_Intensity.Value;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                _OverrideWhite_2_Intensity = value;
                sendMessageData(nodeID, 25082, (ulong)_OverrideWhite_2_Intensity);
            }
        }

        public int OverrideBlue_1_Intensity
        {
            get
            {
                _OverrideBlue_1_Intensity = ((int?)getMessagePayload(nodeID, 25083).data);
                if (_OverrideBlue_1_Intensity.HasValue)
                {
                    return _OverrideBlue_1_Intensity.Value;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                _OverrideBlue_1_Intensity = value;
                sendMessageData(nodeID, 25083, (ulong)_OverrideBlue_1_Intensity);
            }
        }

        public int OverrideBlue_2_Intensity
        {
            get
            {
                _OverrideBlue_2_Intensity = ((int?)getMessagePayload(nodeID, 25084).data);
                if (_OverrideBlue_2_Intensity.HasValue)
                {
                    return _OverrideBlue_2_Intensity.Value;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                _OverrideBlue_2_Intensity = value;
                sendMessageData(nodeID, 25084, (ulong)_OverrideBlue_2_Intensity);
            }
        }

        public int MinWhiteValue
        {
            get
            {
                _MinWhiteValue = ((int?)getMessagePayload(nodeID, 25085).data);
                if (_MinWhiteValue.HasValue)
                {
                    return _MinWhiteValue.Value;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                _MinWhiteValue = value;
                sendMessageData(nodeID, 25085, (ulong)_MinWhiteValue);
            }
        }

        public int MinBlueValue
        {
            get
            {
                _MinBlueValue = ((int?)getMessagePayload(nodeID, 25086).data);
                if (_MinBlueValue.HasValue)
                {
                    return _MinBlueValue.Value;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                _MinBlueValue = value;
                sendMessageData(nodeID, 25086, (ulong)_MinBlueValue);
            }
        }
    }
}
