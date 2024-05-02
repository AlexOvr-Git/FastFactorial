using System.Numerics;
namespace FastFactorialTest
{
    internal partial class Program
    {
        // Fast Factorial & Product of Arithmetic Sequence
        // 8!   = 4*(16-1)*(15-3)*(12-5)*8 = 40,320
        // 9!   = 5*(25-1)*(24-3)*(21-5)*(16-7) = 362,880
        // 10!  = 5*(25-1)*(24-3)*(21-5)*(16-7)*10 = 3,628,800
        // 11!! = 5*(25-4)*(21-12)*11 = 10,395 
        // 15!! = 7*(49-4)*(45-12)*(33-20)*15 = 2,027,025
        // 17!! = 9*(81-4)*(77-12)*(65-20)*(45-28) = 34,459,425

        static BigInteger FastFactorial(int iDiff, int iFrom, int iTo)
        {
            BigInteger bigProduct = BigInteger.One;
            if ((iDiff < 1) || (iTo - iFrom) < 2 || (iTo - iFrom) % iDiff != 0)
            { Console.WriteLine(" Inconsistent parameters"); return bigProduct; }

            if ((iTo - iFrom) < (4 * iDiff))
            { for (int n = iFrom; n <= iTo; n += iDiff) bigProduct *= n; return bigProduct; }

            int iHalf = iFrom / 2; iHalf += (((iFrom - iHalf) + (iTo - iHalf)) / 2);
            int iEx = (iHalf - iFrom) % iDiff, iStep = 100000;
            iHalf -= iEx; iEx = (iFrom - iHalf) + (iTo - iHalf);
            long lFactor = iHalf, lDeduct = iDiff * iDiff, lRise = 2 * lDeduct;
            bigProduct = lFactor;
            lFactor *= lFactor;
            for (; iHalf > iFrom; iHalf -= iDiff)
            {
                //Console.WriteLine("Deduct={0:N0}, Factor={1:N0}, bigProduct={2:N0}",
                //    lDeduct, lFactor, bigProduct);
                bigProduct *= (lFactor - lDeduct);
                lFactor -= lDeduct;
                lDeduct += lRise;

                if (lDeduct >= iStep)
                { Console.WriteLine((lDeduct).ToString("N0")); iStep += 100000; }
            }
            return (iEx == 0) ? bigProduct : iTo * bigProduct;
        }
    }
}
