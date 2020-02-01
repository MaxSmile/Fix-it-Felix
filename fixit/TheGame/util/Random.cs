using System;
namespace fixit.TheGame.util
{
    public class Random
    {
        
        public static int value(int n, int m)
        {
            System.Random generator = new System.Random();
            return (int)generator.Next(n,m);
        }


        public static bool boolValue(int i)
        {
            if (value(1, 10) % i == 0)
            {
                return true;
            }
            else return false;
        }
    }
}
