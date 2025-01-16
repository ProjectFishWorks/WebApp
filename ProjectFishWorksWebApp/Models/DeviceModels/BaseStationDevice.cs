namespace ProjectFishWorksWebApp.Models.DeviceModels
{
    public class BaseStationDevice : Device
    {
        private int nodeID;
        private int? _LEDBrightness;
        private bool _IsErrors;
        private bool _IsNoErrors;
        private bool _ResetErrors;
        private int? _UNIX_Time;
        private int? _UTC_Time;
        private int? _TimeZoneOffset;
        private int? _Local_Time;

        public BaseStationDevice(MQTTnet.ClientLib.MqttService mqttService, int systemID, int basestationID, int nodeID) : base(mqttService, systemID, basestationID)
        {
            this.nodeID = nodeID;
        }

        public int LEDBrightness
        {
            get
            {
                _LEDBrightness = (int?)getMessagePayload(nodeID, 2560).data;
                if (_LEDBrightness.HasValue)
                {
                    return _LEDBrightness.Value;
                }
                else
                {
                    return 1;
                }
            }
            set
            {
                _LEDBrightness = value;
                sendMessageData(nodeID, 2560, (ulong)_LEDBrightness);
            }
        }

        public bool IsErrors
        {
            get
            {
                _IsErrors = getMessagePayload(nodeID, 2561).data == 1;
                return _IsErrors;
            }
            set
            {
                _IsErrors = value;
                sendMessageData(nodeID, 2561, (ulong)(_IsErrors ? 1 : 0));
            }
        }

        public bool IsNoErrors
        {
            get
            {
                _IsNoErrors = getMessagePayload(nodeID, 2562).data == 1;
                return _IsNoErrors;
            }
            set
            {
                _IsNoErrors = value;
                sendMessageData(nodeID, 2562, (ulong)(_IsNoErrors ? 1 : 0));
            }
        }

        public bool ResetErrors
        {
            get
            {
                return getMessagePayload(nodeID, 2563).data == 1;
            }
            set
            {
                sendMessageData(nodeID, 2563, (ulong)(value ? 1 : 0));
            }
        }

        public int UNIX_Time
        {
            get
            {
                _UNIX_Time = (int?)getMessagePayload(nodeID, 2000).data;
                if (_UNIX_Time.HasValue)
                {
                    return _UNIX_Time.Value;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                _UNIX_Time = value;
                sendMessageData(nodeID, 2002, (ulong)_UNIX_Time);
            }
        }

        public int UTC_Time
        {
            get
            {
                _UTC_Time = (int?)getMessagePayload(nodeID, 2002).data;
                if (_UTC_Time.HasValue)
                {
                    return _UTC_Time.Value;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                _UTC_Time = value;
                sendMessageData(nodeID, 2001, (ulong)_UTC_Time);
            }
        }

        public int TimeZoneOffset
        {
            get
            {
                _TimeZoneOffset = (int?)getMessagePayload(nodeID, 2001).data;
                if (_TimeZoneOffset.HasValue)
                {
                    return _TimeZoneOffset.Value;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                _TimeZoneOffset = value;
                sendMessageData(nodeID, 2002, (ulong)_TimeZoneOffset);
            }
        }

        public int Local_Time
        {
            get
            {
                _Local_Time = (int?)getMessagePayload(nodeID, 2003).data;
                if (_Local_Time.HasValue)
                {
                    return _Local_Time.Value;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                _Local_Time = value;
                sendMessageData(nodeID, 2003, (ulong)_Local_Time);
            }
        }
    }
}
