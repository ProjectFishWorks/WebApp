using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Threading.Tasks;
using ProjectFishWorksWebApp.Models.DeviceModels;
using MQTTnet;

namespace ProjectFishWorksWebApp.Services
{
    public static class DeviceInit
    {
        /// <summary>
        /// Creates a device instance with the correct user ID depending on Debug/Production mode.
        /// Devices will still reflect live MQTT data.
        /// </summary>
        /// 

        public static string ResolveClientId(Task<AuthenticationState>? authenticationState = null)
        {
#if DEBUG
            return "debug-user";
#else
    if (authenticationState is null)
        throw new InvalidOperationException("AuthenticationState is required in Production mode.");

    var authState = authenticationState.GetAwaiter().GetResult();
    return authState.User.FindFirst("sub")?.Value ?? "";
#endif
        }

        public static T Create<T>(
            MQTTnet.ClientLib.MqttService mqtt,
            int systemId,
            int baseStationId,
            int nodeId,
            Task<AuthenticationState>? authenticationState = null
        ) where T : class
        {
            string userId;

#if DEBUG
            // Debug mode: use a fixed ID, but still subscribe to MQTT
            userId = "debug-user";
#else
            if (authenticationState is null)
                throw new InvalidOperationException("AuthenticationState is required in Production mode.");

            var authState = authenticationState.GetAwaiter().GetResult();
            userId = authState.User.FindFirst("sub")?.Value ?? "";
#endif

            return (T)Activator.CreateInstance(typeof(T), mqtt, userId, systemId, baseStationId, nodeId)!;
        }
    }
}
