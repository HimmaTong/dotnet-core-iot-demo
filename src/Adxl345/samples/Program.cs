﻿// This repository is licensed under the MIT License © Zhang Yuexin
// https://github.com/ZhangGaoxing/dotnet-core-iot-demo/blob/master/LICENSE

using System;
using System.Numerics;
using System.Threading;
using System.Device.Spi;
using Iot.Device.Adxl345;

namespace Adxl345.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            SpiConnectionSettings settings = new SpiConnectionSettings(0, 0)
            {
                ClockFrequency = Iot.Device.Adxl345.Adxl345.SpiClockFrequency,
                Mode = Iot.Device.Adxl345.Adxl345.SpiMode
            };
            
            var device = SpiDevice.Create(settings);
            
            // set gravity measurement range ±4G
            using (Iot.Device.Adxl345.Adxl345 sensor = new Iot.Device.Adxl345.Adxl345(device, GravityRange.Range04))
            {
                // loop
                while (true)
                {
                    // read data
                    Vector3 data = sensor.Acceleration;

                    Console.WriteLine($"X: {data.X.ToString("0.00")} g");
                    Console.WriteLine($"Y: {data.Y.ToString("0.00")} g");
                    Console.WriteLine($"Z: {data.Z.ToString("0.00")} g");
                    Console.WriteLine();

                    // wait for 500ms
                    Thread.Sleep(500);
                }
            }
        }
    }
}
