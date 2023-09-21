using DuByteTest;

// ИЗМЕНЯЕМЫЕ ПАРАМЕТРЫ
int sys = 13; // система счисления
int digitCount = 13; // число из скольки знаков генерируем

var strNumsBase = new string('0', digitCount); // генерируем начальную строку с числами (000...)

int charsCountInPart = digitCount / 2; // равное количество цифр в левой и правой стороне
bool oddCountNumbers = digitCount % 2 == 1; // нечетное число цифр? (...0.../......)

// ПЕРЕМЕННЫЕ, КОТОРЫЕ ПРИГОДЯТСЯ ПРИ ПОДСЧЁТАХ
int maxValue = sys - 1; // максимальное значение цифры

var valueLeft = strNumsBase.Remove(charsCountInPart); // левая часть числа
var valueRightStart = strNumsBase.Substring(digitCount - charsCountInPart);
var strList = new List<string>();

while (true)
{
    var sumLeftDigits = valueLeft.SumCharDigits();

    var valueRight = valueRightStart;

    while (true)
    {
        var sumRightDigits = valueRight.SumCharDigits();

        if (sumLeftDigits == sumRightDigits)
        {
            if (oddCountNumbers)
            {
                for (int i = 0; i <= maxValue; i++)
                {
                    var value = $"{valueLeft}{i.ToChar()}{valueRight}";
                    strList.Add(value);
                    Console.WriteLine(value);
                }
            }
            else
            {
                var value = $"{valueLeft}{valueRight}";
                strList.Add(value);
                Console.WriteLine(value);
            }
        }

        var nextRightNumberModel = valueRight.NextNumber(maxValue);

        if (!nextRightNumberModel.IsSuccess)
            break;

        valueRight = nextRightNumberModel.StrNumber;
    }

    var nextLeftNumberModel = valueLeft.NextNumber(maxValue);

    if (!nextLeftNumberModel.IsSuccess)
        break;

    valueLeft = nextLeftNumberModel.StrNumber;
}

Console.WriteLine($"Количество красивых чисел: {strList.Count}");

Console.ReadKey();