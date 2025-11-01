using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace searshFreeIP
{
    internal class Program
    {

        static void Main()
        {
            var ips = new List<string> { "1.2.3.5", "1.2.3.4", "1.2.3.9" };
            Console.WriteLine(FindSmallestFreeIp(ips)); 
        }
        static string FindSmallestFreeIp(List<string> usedIps)
        {
            // Преобразуем IP в числа для быстрого сравнения
            var used = usedIps
                .Select(ip => BitConverter.ToUInt32(IPAddress.Parse(ip).GetAddressBytes().Reverse().ToArray(), 0))
                .OrderBy(x => x)
                .ToList();

            for (int i = 0; i < used.Count - 1; i++)
            {
                uint nextIp = used[i] + 1;
                // Пропускаем адреса, оканчивающиеся на 0
                if ((nextIp & 0xFF) == 0)
                    nextIp++;

                if (nextIp < used[i + 1])
                {
                    var bytes = BitConverter.GetBytes(nextIp).Reverse().ToArray();
                    return new IPAddress(bytes).ToString();
                }
            }

            // Если свободного не нашли — возвращаем следующий за последним
            uint lastNext = used.Last() + 1;
            if ((lastNext & 0xFF) == 0)
                lastNext++;
            var lastBytes = BitConverter.GetBytes(lastNext).Reverse().ToArray();
            return new IPAddress(lastBytes).ToString();
        }

        

    }
}
