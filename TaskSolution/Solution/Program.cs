using System;

public class Task
{
    static void Main(string[] args)
    {
        double[] Plovdiv = new double[14];
        double[] Sofia = new double[14];
        double[] Varna = new double[14];

        EnterWindSpeedsInMetersPerSecond(Plovdiv, "Населено място Пловдив");
        EnterWindSpeedsInMetersPerSecond(Sofia, "Населено място София");
        EnterWindSpeedsInMetersPerSecond(Varna, "Населено място Варна");

        double avgPlovdiv = CalculateAverageSpeedInKmPerHour(Plovdiv);
        double avgSofia = CalculateAverageSpeedInKmPerHour(Sofia);
        double avgVarna = CalculateAverageSpeedInKmPerHour(Varna);

        Console.WriteLine($"\nСредна скорост за периода (км/ч):");
        Console.WriteLine($"Населено място A: {avgPlovdiv:F2} км/ч");
        Console.WriteLine($"Населено място B: {avgSofia:F2} км/ч");
        Console.WriteLine($"Населено място C: {avgVarna:F2} км/ч");

        Console.WriteLine();
        FindDaysWithIncreasedSpeed(Plovdiv, "Населено място Пловдив");
        FindDaysWithIncreasedSpeed(Sofia, "Населено място София");
        FindDaysWithIncreasedSpeed(Varna, "Населено място Варна");
    }

    static void EnterWindSpeedsInMetersPerSecond(double[] array, string locationName)
    {
        Console.WriteLine($"Въведете скоростта на вятъра (м/сек.) за 14 дни за {locationName}:");
       
        for (int index = 0; index < 14; index++)
        {
            try
            {
                Console.Write($"Ден {index + 1}: ");
                array[index] = double.Parse(Console.ReadLine());

                if (array[index] < 0)
                {
                    Console.WriteLine("Скоростта на вятъра трябва да бъде неотрицателна. Опитайте отново.");
                    index--;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Моля, въведете валидно число. Опитайте отново.");
                index--;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Възникна неочаквана грешка: {ex.Message}. Опитайте отново.");
                index--;
            }
        }
    }

    static double CalculateAverageSpeedInKmPerHour(double[] array)
    {
        return array.Average() * 3.6;
    }

    static void FindDaysWithIncreasedSpeed(double[] array, string locationName)
    {
        Console.WriteLine($"Дни с по-висока скорост на вятъра спрямо предходния ден за {locationName}:");
       
        for (int index = 1; index < array.Length; index++)
        {
            if (array[index] > array[index - 1])
            {
                Console.WriteLine($"Ден {index + 1}: {array[index]} м/сек.");
            }
        }
    }
}
