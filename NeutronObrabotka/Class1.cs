using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeutronObrabotka
{
    public class Obrabotca
    {
        public bool MetodYuKO(double koef, int maxTime, int maxAmp, int firstTime)
        {
            double k = (double)maxAmp / (double)(maxTime - firstTime);
           if (k<= koef)
            {
                return true;
            }
            return false;
        }
        public void AmpAndTime(int[,] data, out int[] maxTime, out int[] maxAmp, int[] NullLine)
        {
            maxAmp = new int[12];
            maxTime = new int[12];
            for(int i=0; i<12; i++)
            {
                for(int j=0; j<data.Length/12; j++)
                {
                    if(maxAmp[i]> data[i,j]-NullLine[i])
                    {
                        maxAmp[i] = data[i, j] - NullLine[i];
                        maxTime[i] = j;
                    }
                }
            }
        }
        public int[] FirstTme( int[] maxTime, int[] maxAmp, int porog, int[,] data, int[] NullLine)
        {
           int[] firstTime = new int[12];
            for(int i=0; i<12; i++)
            {
                if(maxAmp[i]>=porog)
                {
                    for(int j= maxTime[i]-1; j>-1; j--)
                    {
                        if(data[i, j]>NullLine[i])
                        {
                            firstTime[i] = j;
                        }
                    }
                }
                else
                {
                    firstTime[i] = -1;
                }
            }
            return firstTime;
        }
    }
}
