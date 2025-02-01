using MQTTnet.ClientLib;
using System.Text.Json;

using MQTTnet;

using Microsoft.AspNetCore.Components.Authorization;


namespace ProjectFishWorksWebApp.Models
{
    public class BaseStationManifests
    {
        private MqttService _mqttService;

        private int _systemID { get; set; }

        private string _userID { get; set; }

        List<BaseStationManifestData> _manifests;

        public List<BaseStationManifestData> Manifests
        {
            get
            {
                var messsages = _mqttService.AllMessages.Where(x => (x.Key.StartsWith($"{_userID}/manifestOut/{_systemID}")));

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
        public BaseStationManifests(string userID, int systemID, MqttService mqttService)
        {
            this._userID = userID;
            this._mqttService = mqttService;
            this._systemID = systemID;

        }
        public void sendManifest(BaseStationManifestData manifest)
        {
            string payload = JsonSerializer.Serialize(manifest);
            MqttApplicationMessage message = new MqttApplicationMessageBuilder()
                .WithTopic($"{_userID}/manifestIn/{manifest.SystemID}/{manifest.BaseStationID}")
                .WithPayload(payload)
                .Build();
            _mqttService.Publish(message);
        }
        public Type? stringToWidgetType(string typeName)
        {
            return Type.GetType($"ProjectFishWorksWebApp.Components.DeviceWidgets.{typeName}Widget");
        }
        public Type? stringToPageType(string typeName)
        {
            Console.WriteLine($"ProjectFishWorksWebApp.Components.DevicePages.{typeName}Page");
            return Type.GetType($"ProjectFishWorksWebApp.Components.DevicePages.{typeName}Page");
        }
    }
}
