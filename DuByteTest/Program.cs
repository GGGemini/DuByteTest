using DuByteTest;
using System.Diagnostics;

// ИЗМЕНЯЕМЫЕ ПАРАМЕТРЫ
int sys = 13; // система счисления
int digitCount = 13; // число из скольки знаков генерируем

int charsCountInPart = digitCount / 2; // равное количество цифр в левой и правой стороне

// ПЕРЕМЕННЫЕ, КОТОРЫЕ ПРИГОДЯТСЯ ПРИ ПОДСЧЁТАХ
int maxValue = sys - 1; // максимальное значение цифры

var valueLeft = new int[charsCountInPart]; // левая часть числа

ulong totalCount = 0;

var sw = new Stopwatch();
sw.Start();

var sumsBuffer = new List<int>();

while (true)
{
    int sumLeftDigits = valueLeft.Sum();

    if (sumsBuffer.Contains(sumLeftDigits))
    {
        Extensions.NextNumber(ref valueLeft, maxValue);
        continue;
    }

    sumsBuffer.Add(sumLeftDigits);

    int[] valueRight = new int[charsCountInPart];
    ulong sameNums = 0;

    while (true)
    {
        int sumRightDigits = valueRight.Sum();

        if (sumLeftDigits == sumRightDigits)
        {
            sameNums++;
            //Console.WriteLine($"{string.Join(',', valueLeft)}*{string.Join(',', valueRight)}");
        }

        var isRightSuccess = Extensions.NextNumber(ref valueRight, maxValue);

        if (!isRightSuccess)
            break;
    }

    totalCount += sameNums * sameNums;

    var isLeftSuccess = Extensions.NextNumber(ref valueLeft, maxValue);

    if (!isLeftSuccess)
        break;
}

sw.Stop();

Console.WriteLine($"Количество красивых чисел: {totalCount * Convert.ToUInt64(sys)}. Время выполнения: {sw.ElapsedMilliseconds}");

Console.ReadKey();