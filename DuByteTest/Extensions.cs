using DuByteTest.Models;

namespace DuByteTest
{
    public static class Extensions
    {
        public const int charLetterToDigit = 55; // чтобы преобразовать букву в число
        public const int charDigitToDigit = 48; //  чтобы преобразовать число (символ) в число ('0')

        public static bool NextNumber(ref int[] numArr, int maxValue)
        {
            int maxIndex = numArr.Length - 1;
            bool needAdded = false;
            for (int i = maxIndex; i >= 0; i--)
            {
                int num = numArr[i];

                if (i == maxIndex || needAdded)
                {
                    int newNum = num + 1;

                    if (newNum > maxValue)
                    {
                        if (i == 0)
                        {
                            return false;
                        }

                        newNum = 0;
                        needAdded = true;
                    }
                    else if (needAdded)
                    {
                        needAdded = false;
                    }

                    numArr[i] = newNum;
                }
                else
                {
                    break;
                }
            }

            return true;
        }

        public static int SumCharDigits(this string numStr)
        {
            int sum = 0;

            foreach (var n in numStr)
                sum += n.ToInt();

            return sum;
        }

        public static int ToInt(this char ch)
        {
            int num = char.IsDigit(ch) ? ch - charDigitToDigit : ch - charLetterToDigit;

            return num;
        }

        public static char ToChar(this int num)
        {
            var ch = num > 9 ? (char)(num + charLetterToDigit) : (char)(num + charDigitToDigit);

            return ch;
        }
    }
}
