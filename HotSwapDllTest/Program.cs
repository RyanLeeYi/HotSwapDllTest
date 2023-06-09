﻿using InterfaceLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HotSwapDllTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            here:

            Console.WriteLine("Main application is running.");
            Console.WriteLine("Press any key to load plugin...");
            Console.ReadKey();

            string filePath = @"C:\Users\003730\Desktop\test\pluginTest\MyPlugin.dll";

            // 載入插件DLL
            Assembly pluginAssembly = Assembly.Load(File.ReadAllBytes(filePath));

            // 取得插件中實作IPlugin介面的類別
            Type pluginType = pluginAssembly.GetTypes().FirstOrDefault(t => t.GetInterface("IMyInterface") != null);

            string result = string.Empty;

            if (pluginType != null)
            {
                Console.WriteLine("111111");
                // 創建類別實例
                object pluginObject = Activator.CreateInstance(pluginType);

                // 呼叫介面方法
                result = ((IMyInterface)pluginObject).MyMethod();
            }

            //// 加載插件 DLL，用讀取的方式就不會咬住該檔案，才能直接切換DLL
            //Assembly plugin = Assembly.Load(File.ReadAllBytes(filePath));

            //// 獲取插件中的類型和方法
            //Type pluginType = plugin.GetType("MyPlugin.Plugin");
            //MethodInfo pluginMethod = pluginType.GetMethod("SayHello");

            //// 建立插件的實例
            //object pluginInstance = Activator.CreateInstance(pluginType);

            //// 呼叫插件中的方法
            //string result = (string)pluginMethod.Invoke(pluginInstance, null);

            Console.WriteLine(result);

            Console.WriteLine("Retry?Y/N");

            string yesOrNo = Console.ReadLine();

            if (string.Compare(yesOrNo.ToUpper(),"Y") == 0)
            {
                goto here;
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
