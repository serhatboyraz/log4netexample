using System;

namespace LogExample
{
    class Program
    {
        static void Main(string[] args)
        {

            string parseData = "a2";

            try
            {
                int s2 = int.Parse(parseData);
            }
            catch (Exception e)
            {
                Logger.WriteError($"parse ederken hata aldım. Data şuydu : {parseData}", e);
            }
            Console.WriteLine("Hello World!");
        }
    }
}
