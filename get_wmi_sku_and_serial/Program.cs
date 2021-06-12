using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace get_wmi_sku_and_serial
{
    class Program
    {
        static void Main(string[] args)
        {
            GetSerialNumber();
            GetSKUNumber();
        }

        /// <summary>
        /// 製造番号を取得
        /// </summary>
        /// <returns></returns>
        private static string GetSerialNumber()
        {
            var serialNumber = string.Empty;
            try
            {
                var mc = new ManagementClass("Win32_ComputerSystemProduct");
                foreach (var mo in mc.GetInstances())
                {
                    serialNumber = mo["identifyingnumber"].ToString();
                    Console.WriteLine($"your serialNumber {serialNumber}");
                    mc.Dispose();
                    mo.Dispose();
                    return serialNumber;
                }
            }
            catch
            {
                return string.Empty;
            }
            // foreachの最初の1度目かcatchでreturnするので、ここには来ない想定
            return serialNumber;
        }

        /// <summary>
        /// 機種品番を取得
        /// </summary>
        /// <returns></returns>
        private static string GetSKUNumber()
        {
            var skuNumber = string.Empty;
            try
            {
                var mc = new ManagementClass("Win32_ComputerSystem");
                foreach (var mo in mc.GetInstances())
                {
                    skuNumber = mo["systemskuNumber"].ToString();
                    Console.WriteLine($"your skuNumber {skuNumber}");
                    mc.Dispose();
                    mo.Dispose();
                    return skuNumber;
                }
            }
            catch
            {
                return string.Empty;
            }

            // foreachの最初の1度目かcatchでreturnするので、ここには来ない想定
            return skuNumber;
        }
    }
}
