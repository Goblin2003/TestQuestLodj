using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using System.Net;


namespace tast2
{
    internal class Program
    {
        static void Main(string[] args)
            
        {
            
            
            using (TextFieldParser csvv = new TextFieldParser(@"C:\Users\filip\source\repos\searshFreeIP\tast2\csv\geo-US.csv"))
            {
                csvv.TextFieldType = FieldType.Delimited;
                csvv.SetDelimiters(",");
                while (!csvv.EndOfData)
                {
                    var f = csvv.ReadFields();
                    var prefix = f[0].Split('/')[1];
                    Console.WriteLine($"\"{prefix}\" \"{f[3]}\", \"{f[4]}\"");

                }

            }
            
        }
    }
}