using System;
using System.ComponentModel;

namespace ProjectFishWorksWebApp.Models.DeviceModels
{
    public class BaseStationDevice : Device // , INotifyPropertyChanged
    {
        private int nodeID;                 // 0
        private int? _TimeZoneOffset;       // 2001
        private int? _LEDBrightness;        // 2500
        private bool _IsErrors;             // 2501
        private bool _IsNoErrors;           // 2502
        private bool _ResetErrors;          // 2503




        public BaseStationDevice(MQTTnet.ClientLib.MqttService mqttService, int systemID, int basestationID, int nodeID) : base(mqttService, systemID, basestationID)
        {
            this.nodeID = nodeID;
        }
        /*
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        */

        public int TimeZoneOffset
        {
            get
            {
                ulong? value = getMessagePayload(nodeID, 2001).data;
                if (value == null)
                {
                    return 8;
                }
                return (int)value.Value;
            }
            set
            {
                _TimeZoneOffset = value;
                Console.WriteLine($"Set value _TimeZoneOffset : {_TimeZoneOffset}");
                sendMessageData(nodeID, 2001, (ulong)value);
            }
        }

        public int LEDBrightness
        {
            get
            {
                _LEDBrightness = (int?)getMessagePayload(nodeID, 2500).data;
                   // Console.WriteLine($"_LEDBrightness = (int?)getMessagePayload(nodeID, 2560).data : {_LEDBrightness}");
                if (_LEDBrightness.HasValue)
                {
                    //Console.WriteLine($" if (_LEDBrightness.HasValue) Get value _LEDBrightness : {_LEDBrightness}");
                    return _LEDBrightness.Value;
                }
                else
                {
                    //Console.WriteLine($" else return 1 = value _LEDBrightness : {_LEDBrightness}");
                    return 1;
                }

            }
            set
            {
                _LEDBrightness = value;
                Console.WriteLine($"Set value _LEDBrightness : {_LEDBrightness}");
                sendMessageData(nodeID, 2500, (ulong)_LEDBrightness);
            }
        }

        


        public bool IsErrors
        {
            get
            {
                _IsErrors = getMessagePayload(nodeID, 2501).data == 1;
                return _IsErrors;
            }
            set
            {
                _IsErrors = value;
                sendMessageData(nodeID, 2501, (ulong)(_IsErrors ? 1 : 0));
            }
        }

        public bool IsNoErrors
        {
            get
            {
                _IsNoErrors = getMessagePayload(nodeID, 2502).data == 1;
                return _IsNoErrors;
            }
            set
            {
                _IsNoErrors = value;
                sendMessageData(nodeID, 2502, (ulong)(_IsNoErrors ? 1 : 0));
            }
        }

        public bool ResetErrors
        {
            get
            {
                _ResetErrors = getMessagePayload(nodeID, 2503).data == 1;
                return _ResetErrors;
            }
            set
            {
                _ResetErrors = value;
                sendMessageData(nodeID, 2503, (ulong)(_ResetErrors ? 1 : 0));
            }
        }
    }
}
