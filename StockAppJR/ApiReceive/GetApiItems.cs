using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Globalization;

namespace ApiReceive
{
    public class GetApiItems
    {
        public static async Task<List<DailyValues>> getItems(string stock)
        {

            string URLkey = "3T9IINHM1CPEAP6J";

            string response = await GetAPIFromURL(stock, URLkey);
            List<DailyValues> stoksai = new List<DailyValues>();
            string[] newCsv = response.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 1; i < newCsv.Length - 1; i++)
            {
                DailyValues stokObj = DailyValues.FromCsv(newCsv[i]);
                stoksai.Add(stokObj);
            }

            return stoksai;


        }
        static async Task<string> GetAPIFromURL(string symb, string URLkey)
        {
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync("https://" + $@"www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={symb}&apikey={URLkey}&datatype=csv");
            return response;
        }

        public class DailyValues
        {
            public DateTime Date;
            public decimal Open;
            public decimal High;
            public decimal Low;
            public decimal Close;
            public decimal Volume;


            public static DailyValues FromCsv(string csvFile)
            {
                string[] values = csvFile.Split(',');
                DailyValues dailyValues = new DailyValues();
                dailyValues.Date = Convert.ToDateTime(values[0]);
                dailyValues.Open = decimal.Parse(values[1], CultureInfo.InvariantCulture);
                dailyValues.High = decimal.Parse(values[2], CultureInfo.InvariantCulture);
                dailyValues.Low = decimal.Parse(values[3], CultureInfo.InvariantCulture);
                dailyValues.Close = decimal.Parse(values[4], CultureInfo.InvariantCulture);
                dailyValues.Volume = decimal.Parse(values[5], CultureInfo.InvariantCulture);
                return dailyValues;
            }
        }
    }
}
