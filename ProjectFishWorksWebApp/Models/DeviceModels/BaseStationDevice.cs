namespace ProjectFishWorksWebApp.Models.DeviceModels
{
    public class BaseStationDevice : Device
    {
        private int nodeID;
        private int? _LEDBrightness;
        private bool _IsErrors;
        private bool _IsNoErrors;
        private bool _ResetErrors;
        private float? _TimeZoneOffset;

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
                _ResetErrors = getMessagePayload(nodeID, 2563).data == 1;
                return _ResetErrors;
            }
            set
            {
                _ResetErrors = value;
                sendMessageData(nodeID, 2563, (ulong)(_ResetErrors ? 1 : 0));
            }
        }

        public float TimeZoneOffset
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
                    return 1;
                }
            }
            set
            {
                _TimeZoneOffset = value;
                sendMessageData(nodeID, 2001, (ulong)_TimeZoneOffset);
            }
        }
    }
}
