namespace ProjectFishWorksWebApp.Models.DeviceModels
{
    public class LeakSensorDevice : Device
    {
        private int nodeID;

        public LeakSensorDevice(MQTTnet.ClientLib.MqttService mqttService, int systemID, int basestationID, int nodeID) : base(mqttService, systemID, basestationID)
        {
            this.nodeID = nodeID;
        }
        /*#define NODE_ID 0xB2              // 178
#define LEAK_DETECTED_MESSAGE_ID 0x0A00    // 2560
#define HIGH_WATER_LEVEL_MESSAGE_ID 0x0A01   // 2561
        */
    }
}
