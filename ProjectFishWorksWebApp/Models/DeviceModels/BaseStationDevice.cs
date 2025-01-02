namespace ProjectFishWorksWebApp.Models.DeviceModels
{
    public class BaseStationDevice : Device
    {
        private int nodeID;
        private int? _LEDBrightness;
        private bool _ErrorStatus;
        private bool _ResetErrors;

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

        public bool ErrorStatus
        {
            get
            {
                _ErrorStatus = getMessagePayload(nodeID, 2561).data == 1;
                return _ErrorStatus;
            }
            set
            {
                _ErrorStatus = value;
                sendMessageData(nodeID, 2561, (ulong)(_ErrorStatus ? 1 : 0));
            }
        }

        public bool ResetErrors
        {
            get
            {
                return getMessagePayload(nodeID, 2562).data == 1;
            }
            set
            {
                sendMessageData(nodeID, 2562, (ulong)(value ? 1 : 0));
            }
        }
    }
}
