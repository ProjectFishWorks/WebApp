using System;
using System.ComponentModel;

namespace ProjectFishWorksWebApp.Models.DeviceModels
{
    public class BaseStationDevice : Device, INotifyPropertyChanged
    {
        private int nodeID;                 // 0
        private int? _TimeZoneOffset = 8;       // 2001
        private int? _LEDBrightness = 1;        // 2500
        private bool _IsErrors;             // 2501
        private bool _IsNoErrors;           // 2502
        private bool _ResetErrors;          // 2503


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public BaseStationDevice(MQTTnet.ClientLib.MqttService mqttService, string userID,int systemID, int basestationID, int nodeID) 
            : base(mqttService,userID, systemID, basestationID)
        {
            this.nodeID = nodeID;
        }

        public void UpdateFromPayloads(int nodeID)
        {
            var tzPayload = getMessagePayload(nodeID, 2001);
            if (tzPayload?.data != null)
            {
                _TimeZoneOffset = (int)tzPayload.data;
                OnPropertyChanged(nameof(TimeZoneOffset));
            }

            var ledPayload = getMessagePayload(nodeID, 2500);
            if (ledPayload?.data != null)
            {
                _LEDBrightness = (int)ledPayload.data;
                OnPropertyChanged(nameof(LEDBrightness));
            }

            var errPayload = getMessagePayload(nodeID, 2501);
            if (errPayload?.data != null)
            {
                _IsErrors = (errPayload.data == 1);
                OnPropertyChanged(nameof(IsErrors));
            }

            var noErrPayload = getMessagePayload(nodeID, 2502);
            if (noErrPayload?.data != null)
            {
                _IsNoErrors = (noErrPayload.data == 1);
                OnPropertyChanged(nameof(IsNoErrors));
            }

            var resetPayload = getMessagePayload(nodeID, 2503);
            if (resetPayload?.data != null)
            {
                _ResetErrors = (resetPayload.data == 1);
                OnPropertyChanged(nameof(ResetErrors));
            }
        }

        public int TimeZoneOffset
        {
            get => _TimeZoneOffset ?? 8; // default to 8 if null
            set
            {
                if (_TimeZoneOffset != value)
                {
                    _TimeZoneOffset = value;
                    sendMessageData(nodeID, 2001, unchecked((ulong)value));
                    OnPropertyChanged(nameof(TimeZoneOffset));
                }
            }
        }

        public int LEDBrightness
        {
            get => _LEDBrightness ?? 1; // default to 1 if null
            set
            {
                if (_LEDBrightness != value)
                {
                    _LEDBrightness = value;
                    sendMessageData(nodeID, 2500, unchecked((ulong)value));
                    OnPropertyChanged(nameof(LEDBrightness));
                }
            }
        }

        public bool IsErrors
        {
            get => _IsErrors;
            set
            {
                if (_IsErrors != value)
                {
                    _IsErrors = value;
                    sendMessageData(nodeID, 2501, (ulong)(_IsErrors ? 1 : 0));
                    OnPropertyChanged(nameof(IsErrors));
                }
            }
        }

        public bool IsNoErrors
        {
            get => _IsNoErrors;
            set
            {
                if (_IsNoErrors != value)
                {
                    _IsNoErrors = value;
                    sendMessageData(nodeID, 2502, (ulong)(_IsNoErrors ? 1 : 0));
                    OnPropertyChanged(nameof(IsNoErrors));
                }
            }
        }

        public bool ResetErrors
        {
            get => _ResetErrors;
            set
            {
                if (_ResetErrors != value)
                {
                    _ResetErrors = value;
                    sendMessageData(nodeID, 2503, (ulong)(_ResetErrors ? 1 : 0));
                    OnPropertyChanged(nameof(ResetErrors));
                }
            }
        }
    }
}

