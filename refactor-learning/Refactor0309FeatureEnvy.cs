using System;
using System.Text;

namespace refactor_learning
{
    /*
     * 含义:
     * 某个函数为了实现其功能，经常从另一个类中获取大量数据。比起自身所在的类来说，更加依赖于另一个类
     * 
     * 坏处:
     * 代码结构混乱，类分工不明确，可能造成其他坏味道。
     * 
     * 目标:
     * 确定类的具体作用，并合理摆置每个函数所在的类。
     * 
     * 实现方法:
     * 考虑搬移函数。
     * 如果只有函数内的一部分特别依赖其他类，先使用提炼函数, 再考虑使用搬移函数。
     * 如果一个函数用到了多个类的功能，那需要判断哪个类拥有最多被此函数使用的数据，把这个函数和数据摆在一起，使用提炼函数将函数分解为数个较小的函数，并分别放置在不同的位置。
     */
    
    public class Refactor0309FeatureEnvy
    {
        public static void GetAndSendData()
        {
            var sb = new StringBuilder();
            sb.Append(WeatherData.GetXianWeather());
            sb.Append(WeatherData.GetChengduWeather());

            var encryptedData = WeatherData.EncryptData(sb.ToString());
            WeatherData.SendData(encryptedData);
        }
    }

    public static class WeatherData
    {
        public static string GetXianWeather()
        {
            return "Xi'an weather";
        }

        public static string GetChengduWeather()
        {
            return "Chengdu weather";
        }

        public static string EncryptData(string str)
        {
            var sb = new StringBuilder(str);
            
            for (var i = 0; i < 10000; i++)
            {
                sb.Append(new Random().Next(0, 9));
            }

            return sb.ToString();
        }

        public static void SendData(string str)
        {
            // Send data.
        }
    }
}