using ApexCharts;

namespace ProjectFishWorksWebApp.Models.DeviceModels
{
    public class TesterHatDevice : Device
    {
        private int nodeID;
        private int _LED1 = 0;
        private int _LED2 = 0;
        private int _LED3 = 0;
        private int _LED4 = 0;

        private List<int> _LEDValues = new List<int> { 0,0,0,0 };

        private List<HistoryDataRow>? _potentiometerHistory;

        private int _historyHours = 1;

        public TesterHatDevice(MQTTnet.ClientLib.MqttService mqttService, string userID, int systemID, int basestationID, int nodeID) : base(mqttService, userID,  systemID, basestationID)
        {
            this.nodeID = nodeID;
        }

        public List<HistoryDataRow>? PotentiometerHistory { get; set; }
        

        public int LED1
        {
            get
            {
                _LED1 = (int)getMessagePayload(nodeID, 49152).data;
                return _LED1;
            }
            set
            {
                _LED1 = value;
                sendMessageData(nodeID, 49152, (ulong)_LED1);
            }
        }

        public int LED2
        {
            get
            {
                _LED2 = (int)getMessagePayload(nodeID, 49153).data;
                return _LED2;
            }
            set
            {
                _LED2 = value;
                sendMessageData(nodeID, 49153, (ulong)_LED2);
            }
        }

        public int LED3
        {
            get
            {
                _LED3 = (int)getMessagePayload(nodeID, 49154).data;
                return _LED3;
            }
            set
            {
                _LED3 = value;
                sendMessageData(nodeID, 49154, (ulong)_LED3);
            }
        }

        public int LED4
        {
            get
            {
                _LED4 = (int)getMessagePayload(nodeID, 49155).data;
                return _LED4;
            }
            set
            {
                _LED4 = value;
                sendMessageData(nodeID, 49155, (ulong)_LED4);
            }
        }

        public int? PotentiometerValue
        {
            get
            {
                ulong? value = getMessagePayload(nodeID, 45056).data;
                if(value.HasValue)
                {
                    return (int)value.Value;
                }
                return null;
            }
        }

        public List<Boolean?> ButtonValues
        {
            get
            {
                List<Boolean?> values = new List<Boolean?>();
                for(int i = 0; i < 4; i++)
                {
                    ulong? value = getMessagePayload(nodeID, 45057 + i).data;
                    if(value.HasValue)
                    {
                        values.Add(value.Value == 0);
                    }
                    else
                    {
                        values.Add(null);
                    }
                }
                return values;
            }
        }

    }
}
