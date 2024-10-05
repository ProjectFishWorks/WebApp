namespace ProjectFishWorksWebApp.Models
{

    //Data structure for deserializeing historical data messages 
    public class MQTTHistoricalData
    {

        public class historicalData
        {
            public ulong time { get; set; }
            public ulong data { get; set; }

            public float? dataFloat
            {
                get
                {
                    if (data == null)
                    {
                        return null;
                    }
                    return BitConverter.ToSingle(BitConverter.GetBytes(data), 0);
                }
            }
        }

        public int hoursToRead { get; set; }
        public int systemID { get; set; }

        public int baseStationID { get; set; }

        public int nodeID { get; set; }

        public int messageID { get; set; }

        public List<historicalData> history { get; set; } = new List<historicalData>();
    }
}
