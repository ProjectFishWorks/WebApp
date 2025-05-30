﻿namespace ProjectFishWorksWebApp.Models.DeviceModels
{
    public class TempHumDevice : Device
    {
        private int nodeID;                         
        private float? _CanopyTemp = 0;              
        private float? _CanopyHum = 0;
        private float? _TankTemp = 0;
        private float? _SumpTemp = 0;
        private bool _CanopyTempAlarmOnOff = false;
        private float? _CanopyTempAlarmLow = 0;
        private float? _CanopyTempAlarmHigh = 0;
        private bool _CanopyHumAlarmOnOff = false;
        private float? _CanopyHumAlarmLow = 0;
        private float? _CanopyHumAlarmHigh = 0;
        private bool _TankTempAlarmOnOff = false;
        private float? _TankTempAlarmLow = 0;
        private float? _TankTempAlarmHigh = 0;
        private bool _SumpTempAlarmOnOff = false;
        private float? _SumpTempAlarmLow = 0;
        private float? _SumpTempAlarmHigh = 0;
        private int decimalCount = 1;


        public TempHumDevice(MQTTnet.ClientLib.MqttService mqttService, int systemID,int basestationID,int nodeID) : base(mqttService, systemID, basestationID)
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

        public List<HistoryDataRow>? TempHumHistory { get; set; }

        public float? CanopyTemp
        {
            get
            {
                _CanopyTemp = (float?)Math.Round((decimal)getMessagePayload(nodeID, 2560).dataFloat,decimalCount);
                return _CanopyTemp;
            }
            set
            {
                _CanopyTemp = value;
                sendMessageData(nodeID, 2560, (ulong)_CanopyTemp);
            }
        }

        public bool CanopyTempAlarmOnOff
        {
            get
            {
                if (getMessagePayload(nodeID, 2561).data == 1)
                {
                    _CanopyTempAlarmOnOff = true;
                }
                else
                {
                    _CanopyTempAlarmOnOff = false;
                }
                return _CanopyTempAlarmOnOff;
            }
            set
            {
                _CanopyTempAlarmOnOff = value;
                sendMessageData(nodeID, 2561, (ulong)(_CanopyTempAlarmOnOff ? 1 : 0));
            }
        }

        public float? CanopyTempAlarmLow
        {
            get
            {
                _CanopyTempAlarmLow = (float?)getMessagePayload(nodeID, 2562).data;
                return _CanopyTempAlarmLow;
            }
            set
            {
                _CanopyTempAlarmLow = value;
                sendMessageData(nodeID, 2562, (ulong)_CanopyTempAlarmLow);
            }
        }

        public float? CanopyTempAlarmHigh
        {
            get
            {
                _CanopyTempAlarmHigh = (float?)getMessagePayload(nodeID, 2563).data;
                return _CanopyTempAlarmHigh;
            }
            set
            {
                _CanopyTempAlarmHigh = value;
                sendMessageData(nodeID, 2563, (ulong)_CanopyTempAlarmHigh);
            }
        }

        public float? CanopyHum
        {
            get
            {
                _CanopyHum = (float?)Math.Round((decimal)getMessagePayload(nodeID, 2564).dataFloat, decimalCount);
                return _CanopyHum;
            }
            set
            {
                _CanopyHum = value;
                sendMessageData(nodeID, 2564, (ulong)_CanopyHum);
            }
        }

        public bool CanopyHumAlarmOnOff
        {
            get
            {
                    if (getMessagePayload(nodeID, 2565).data == 1)
                    {
                        _CanopyHumAlarmOnOff = true;
                    }
                    else
                    {
                        _CanopyHumAlarmOnOff = false;
                    }
                    return _CanopyHumAlarmOnOff;
            }
            set
            {
                _CanopyHumAlarmOnOff = value;
                sendMessageData(nodeID, 2565, (ulong)(_CanopyHumAlarmOnOff ? 1 : 0));
            }
        }

        public float? CanopyHumAlarmLow
        {
            get
            {
                _CanopyHumAlarmLow = (float?)getMessagePayload(nodeID, 2566).data;
                return _CanopyHumAlarmLow;
            }
            set
            {
                _CanopyHumAlarmLow = value;
                sendMessageData(nodeID, 2566, (ulong)_CanopyHumAlarmLow);
            }
        }

        public float? CanopyHumAlarmHigh
        {
            get
            {
                _CanopyHumAlarmHigh = (float?)getMessagePayload(nodeID, 2567).data;
                return _CanopyHumAlarmHigh;
            }
            set
            {
                _CanopyHumAlarmHigh = value;
                sendMessageData(nodeID, 2567, (ulong)_CanopyHumAlarmHigh);
            }
        }

        public float? TankTemp
        {
            get
            {
                _TankTemp = (float?)Math.Round((decimal)getMessagePayload(nodeID, 2572).dataFloat, decimalCount);
                return _TankTemp;
            }
            set
            {
                _TankTemp = value;
                sendMessageData(nodeID, 2572, (ulong)_TankTemp);
            }
        }

        public bool TankTempAlarmOnOff
        {
            get
            {
                if (getMessagePayload(nodeID, 2569).data == 1)
                {
                    _TankTempAlarmOnOff = true;
                }
                else
                {
                    _TankTempAlarmOnOff = false;
                }
                return _TankTempAlarmOnOff;
            }
            set
            {
                _TankTempAlarmOnOff = value;
                sendMessageData(nodeID, 2569, (ulong)(_TankTempAlarmOnOff ? 1 : 0));
            }
        }

        public float? TankTempAlarmLow
        {
            get
            {
                _TankTempAlarmLow = (float?)getMessagePayload(nodeID, 2570).data;
                return _TankTempAlarmLow;
            }
            set
            {
                _TankTempAlarmLow = value;
                sendMessageData(nodeID, 2570, (ulong)_TankTempAlarmLow);
            }
        }

        public float? TankTempAlarmHigh
        {
            get
            {
                _TankTempAlarmHigh = (float?)getMessagePayload(nodeID, 2571).data;
                return _TankTempAlarmHigh;
            }
            set
            {
                _TankTempAlarmHigh = value;
                sendMessageData(nodeID, 2571, (ulong)_TankTempAlarmHigh);
            }
        }


        public float? SumpTemp
        {
            get
            {
                _SumpTemp = (float?)Math.Round((decimal)getMessagePayload(nodeID, 2568).dataFloat, decimalCount);
                return _SumpTemp;
            }
            set
            {
                _SumpTemp = value;
                sendMessageData(nodeID, 2568, (ulong)_SumpTemp);
            }
        }

        public bool SumpTempAlarmOnOff
        {
            get
            {
                if (getMessagePayload(nodeID, 2573).data == 1)
                {
                    _SumpTempAlarmOnOff = true;
                }
                else
                {
                    _SumpTempAlarmOnOff = false;
                }
                return _SumpTempAlarmOnOff;
            }
            set
            {
                _SumpTempAlarmOnOff = value;
                sendMessageData(nodeID, 2573, (ulong)(_SumpTempAlarmOnOff ? 1 : 0));
            }
        }

        public float? SumpTempAlarmLow
        {
            get
            {
                _SumpTempAlarmLow = (float?)getMessagePayload(nodeID, 2574).data;
                return _SumpTempAlarmLow;
            }
            set
            {
                _SumpTempAlarmLow = value;
                sendMessageData(nodeID, 2574, (ulong)_SumpTempAlarmLow);
            }
        }

        public float? SumpTempAlarmHigh
        {
            get
            {
                _SumpTempAlarmHigh = (float?)getMessagePayload(nodeID, 2575).data;
                return _SumpTempAlarmHigh;
            }
            set
            {
                _SumpTempAlarmHigh = value;
                sendMessageData(nodeID, 2575, (ulong)_SumpTempAlarmHigh);
            }
        }
    }
}
