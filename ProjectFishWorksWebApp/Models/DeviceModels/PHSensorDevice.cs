namespace ProjectFishWorksWebApp.Models.DeviceModels
{
    public class PHSensorDevice : Device
    {
        private int nodeID;
        private float? _pHvalue = 7;
        private UInt64? _voltagePH = 0;
        private bool _pHAlarmOnOff = false;
        private float? _pHAlarmLow = 4;
        private float? _pHAlarmHigh = 10;
        private int decimalCount = 1;

        public PHSensorDevice(MQTTnet.ClientLib.MqttService mqttService, int systemID, int basestationID, int nodeID) : base(mqttService, systemID, basestationID)
        {
            this.nodeID = nodeID;
            Console.Write("Node ID");
            Console.WriteLine(nodeID);
        }

        public bool Alarm
        {
            get
            {
                return getMessagePayload(nodeID, 901).data == 1;
            }
        }

        public List<HistoryDataRow>? pHHistory { get; set; }

        public float? pHvalue
        {
            get
            {
                var _pHvalue = getMessagePayload(nodeID, 2560).dataFloat;
                if (_pHvalue == null)
                {
                    return -1;
                }
                return _pHvalue;
            }
        }

        public float? pHAlarmLow
        {
            get
            {
                var _pHAlarmLow = getMessagePayload(nodeID, 2561).dataFloat;
                if (_pHAlarmLow == null)
                {
                    return -1;
                }

                return _pHAlarmLow;
            }
            set
            {
                sendMessageData(nodeID, 2561, (float)value);
            }
        }

        public float? pHAlarmHigh
        {
            get
            {
                var _pHAlarmHigh = getMessagePayload(nodeID, 2562).dataFloat;
                if (_pHAlarmHigh == null)
                {
                    return -1;
                }
                return _pHAlarmHigh;
            }
            set
            {
                sendMessageData(nodeID, 2562, (float)value);
            }
        }

        public bool pHAlarmOnOff
        {
            get
            {
                return getMessagePayload(nodeID, 2563).data == 1;
            }
            set
            {
                sendMessageData(nodeID, 2563, value ? (ulong)1 : (ulong)0);
            }
        }

        public UInt64? voltagePH
        {
            get
            {
                UInt64? _voltagePH = getMessagePayload(nodeID, 2565).data;
                if (_voltagePH == null)
                {
                    return 0;
                }

                return voltagePH;
            }
        }
    }
}
