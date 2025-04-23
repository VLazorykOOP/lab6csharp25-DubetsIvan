using System;

namespace DigitCheckApp
{
    public class NotTwoDigitNumberException : Exception
    {
        public NotTwoDigitNumberException(string message) : base(message) { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введiть двозначне число: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int number))
                    throw new FormatException("Це не число!");

                if (number < 10 || number > 99)
                    throw new NotTwoDigitNumberException("Число не є двозначним!");

                int firstDigit = number / 10;
                int secondDigit = number % 10;

                Console.WriteLine(firstDigit == secondDigit
                    ? "Цифри однаковi."
                    : "Цифри рiзнi.");

                Console.WriteLine("\nПеревiрка ArrayTypeMismatchException:");
                object[] objArray = new string[1];
                objArray[0] = 123;
            }
            catch (NotTwoDigitNumberException ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Формат помилковий: " + ex.Message);
            }
            catch (ArrayTypeMismatchException ex)
            {
                Console.WriteLine("ArrayTypeMismatchException оброблено: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Невiдома помилка: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Програма завершена.");
            }
        }
    }
}
