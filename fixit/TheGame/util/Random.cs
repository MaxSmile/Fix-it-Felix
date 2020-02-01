using System;
namespace fixit.TheGame.util
{
    public class Random
    {
        
        public static int value(int n, int m)
        {
            System.Random generator = new System.Random();
            return (int)(generator.Next() * (m - n + 1) + n);
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
