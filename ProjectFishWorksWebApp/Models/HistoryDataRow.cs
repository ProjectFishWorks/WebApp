namespace ProjectFishWorksWebApp.Models
{

    //Data structure for storing a single row historical data, passed as a list to the chart
    public class HistoryDataRow
    {
        public ulong data;

        public decimal? dataFloat
        {
            get
            {
                if (data == null)
                {
                    return null;
                }
                return (decimal)BitConverter.ToDouble(BitConverter.GetBytes(data), 0);
            }
        }

        public DateTime time;
    }
}
