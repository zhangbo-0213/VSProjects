﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Service;

namespace Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost serviceHost = new ServiceHost(typeof (CalculatorService)))
            {
                serviceHost.Opened += delegate { Console.WriteLine("服务已经启动，请按任意键终止服务！"); };
                serviceHost.Open();
               
                Console.ReadKey();
            }
        }
    }
}
