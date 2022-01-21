using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Configuration;
using DataEntity;

namespace ExternalSource.Stooq
{
    public class Repository
    {
        public static string DownloadFile(string command)
        {
            string downloadUrl = $"https://stooq.com/q/l/?s={command}&f=sd2t2ohlcv&h&e=csv";
            WebClient client = new WebClient();
            string csvContent = client.DownloadString(downloadUrl);

            return csvContent;
        }

        public static DataEntity.Stooq GetStooq(string CSVContent)
        {
            string[] CSVLines = CSVContent.Split('\r');
            DataEntity.Stooq stooq = new DataEntity.Stooq();
           
            for(int Index=0; Index<CSVLines.Count(); Index++)
            {
                if (!string.IsNullOrEmpty(CSVLines[Index]) && !CSVLines[Index].ToLower().Contains("symbol"))
                { 
                    string[] Fields = CSVLines[Index].Split(',');
                    if(Fields.Length>=4)
                    {
                        stooq.Symbol = Fields[0].ToString();
                        decimal tempValue;

                        if (decimal.TryParse(Fields[1], out tempValue))
                            stooq.Open = tempValue;

                        if (decimal.TryParse(Fields[2], out tempValue))
                            stooq.High = tempValue;

                        if (decimal.TryParse(Fields[3], out tempValue))
                            stooq.Close = tempValue;

                        if (decimal.TryParse(Fields[4], out tempValue))
                            stooq.Volumen = tempValue;
                    }
                }

            }

            return stooq;
        }
    }
}
