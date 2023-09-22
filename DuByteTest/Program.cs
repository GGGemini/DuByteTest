using DuByteTest;
using System.Diagnostics;

// ИЗМЕНЯЕМЫЕ ПАРАМЕТРЫ
int sys = 13; // система счисления
int digitCount = 7; // число из скольки знаков генерируем

int charsCountInPart = digitCount / 2; // равное количество цифр в левой и правой стороне

// ПЕРЕМЕННЫЕ, КОТОРЫЕ ПРИГОДЯТСЯ ПРИ ПОДСЧЁТАХ
int maxValue = sys - 1; // максимальное значение цифры

var valueLeft = new int[charsCountInPart]; // левая часть числа

ulong totalCount = 0;

var sw = new Stopwatch();
sw.Start();

while (true)
{
    int sumLeftDigits = 0;
    for (int i = 0; i < valueLeft.Length; i++)
        sumLeftDigits += valueLeft[i];

    int[] valueRight = new int[charsCountInPart];

    while (true)
    {
        int sumRightDigits = 0;
        for (int i = 0; i < valueRight.Length; i++)
            sumRightDigits += valueRight[i];

        if (sumLeftDigits == sumRightDigits)
        {
            totalCount++;
            //Console.WriteLine($"{string.Join(',', valueLeft)}*{string.Join(',', valueRight)}");
        }

        var isRightSuccess = Extensions.NextNumber(ref valueRight, maxValue);

        if (!isRightSuccess)
            break;
    }

    var isLeftSuccess = Extensions.NextNumber(ref valueLeft, maxValue);

    if (!isLeftSuccess)
        break;
}

sw.Stop();

Console.WriteLine($"Количество красивых чисел: {totalCount/* * Convert.ToUInt64(sys)*/}. Время выполнения: {sw.ElapsedMilliseconds}");

Console.ReadKey();