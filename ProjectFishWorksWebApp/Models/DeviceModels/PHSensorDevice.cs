namespace ProjectFishWorksWebApp.Models.DeviceModels
{
    public class PHSensorDevice : Device
    {
        private int nodeID;
        private float? _pHvalue = 0;
        private bool _pHAlarmOnOff = false;
        private float? _pHAlarmLow = 0;
        private float? _pHAlarmHigh = 0;
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
                _pHvalue = (float?)Math.Round((decimal)getMessagePayload(nodeID, 2560).dataFloat, decimalCount);
                return _pHvalue;
            }
            set
            {
                _pHvalue = value;
                sendMessageData(nodeID, 2560, (ulong)_pHvalue);
            }
        }

        public float? pHAlarmLow
        {
            get
            {
                _pHAlarmLow = (float?)Math.Round((decimal)getMessagePayload(nodeID, 2561).dataFloat, decimalCount);
                return _pHAlarmLow;
            }
            set
            {
                _pHAlarmLow = value;
                sendMessageData(nodeID, 2561, (ulong)_pHAlarmLow);
            }
        }

        public float? pHAlarmHigh
        {
            get
            {
                _pHAlarmHigh = (float?)Math.Round((decimal)getMessagePayload(nodeID, 2562).dataFloat, decimalCount);
                return _pHAlarmHigh;
            }
            set
            {
                _pHAlarmHigh = value;
                sendMessageData(nodeID, 2562, (ulong)_pHAlarmHigh);
            }
        }

        public bool pHAlarmOnOff
        {
            get
            {
                if (getMessagePayload(nodeID, 2563).data == 1)
                {
                    _pHAlarmOnOff = true;
                }
                else
                {
                    _pHAlarmOnOff = false;
                }
                return _pHAlarmOnOff;
            }
            set
            {
                if (value == true)
                {
                    sendMessageData(nodeID, 2563, 1);
                }
                else
                {
                    sendMessageData(nodeID, 2561, 0);
                }
            }
        }

    }
}
