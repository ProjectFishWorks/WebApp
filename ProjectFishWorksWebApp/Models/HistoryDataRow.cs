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
                var f =  BitConverter.ToSingle(BitConverter.GetBytes(data));
                var d = (decimal)f;
                //Console.WriteLine($"Decimal: {d}, float: {f}");
                return (int)d;
                
            }
        }

        public DateTime time;
    }
}
