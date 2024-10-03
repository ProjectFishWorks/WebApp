using MQTTnet.ClientLib;
using System.Text.Json;

using MQTTnet;

namespace ProjectFishWorksWebApp.Models
{
    public class BaseStationManifests
    {
        private MqttService _mqttService;

        private int _systemID { get; set; }

        List<BaseStationManifestData> _manifests;

        public List<BaseStationManifestData> Manifests
        {
            get
            {
                var messsages = _mqttService.AllMessages.Where(x => (x.Key.StartsWith($"manifestOut/{_systemID}")));

                _manifests = new List<BaseStationManifestData>();

                foreach (var message in messsages)
                {
                    var manifest = JsonSerializer.Deserialize<BaseStationManifestData>(message.Value);
                    if (manifest != null)
                    {
                        _manifests.Add(manifest);
                    }
                    else
                    {
                        Console.WriteLine($"Failed to parse manifest {message.Value}");
                    }
                }
                return _manifests;
            }

        }
        public BaseStationManifests(int systemID, MqttService mqttService)
        {
            this._mqttService = mqttService;
            this._systemID = systemID;

        }
        public void sendManifest(BaseStationManifestData manifest)
        {
            string payload = JsonSerializer.Serialize(manifest);
            MqttApplicationMessage message = new MqttApplicationMessageBuilder()
                .WithTopic($"manifestOut/{_systemID}/{manifest.BaseStationID}")
                .WithPayload(payload)
                .WithRetainFlag()
                .Build();
            _mqttService.Publish(message);
        }
        public Type? stringToType(string typeName)
        {
            return Type.GetType($"ProjectFishWorksWebApp.Components.DeviceWidgets.{typeName}Widget");
        }
    }
}
