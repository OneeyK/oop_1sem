using System;
namespace Laba3
{
    public class MyArray
    {
        int[,] Array;
        int m, n;
        int res = 1;
        int average = 1;
        

        public MyArray(int _m, int _n)
        {
            m = _m;
            n = _n;
            Random rand = new Random();
            Array = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Array[i, j] = rand.Next(1, 10);
                }
            }
        }


        public int this[int index]
        {
            get
            {
                if (index >= m || index < 0)
                {
                    return 0;
                }
                else
                {
                    for (int i = 0; i < m; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (j == index - 1)
                            {
                                res *= Array[i, j];
                            }
                        }
                    }
                    return res;
                }
            }
        }

        public int GetAverage
        {
            get
            {
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        average += Array[i, j];
                    }
                }
                return average/(m*n);
            }
        }
    }
}
