using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// prosimy użytkownika o podanie następujących danych:
// imie
// rok, miesiąc i dzień urodzenia
// miejsce  urodzenia
// wyswietlamy komunikat
// cześć ... urodziłeś się ... masz x lat

namespace consoleApp1
{
    class Program
    {
        static void Main()
        {
            
            int numberOfYears;
        
            Console.WriteLine("Podaj swoje imię");
            var name = Console.ReadLine();
            
            Console.WriteLine("Podaj rok urodzenia");
            var yearOfBirth = GetNumber();


            Console.WriteLine("Podaj miesiąc urodzenia");
            var monthOfBirth = GetNumber();
            
            Console.WriteLine("Podaj dzień urodzenia");
            int dayOfBirth = GetNumber();

            Console.WriteLine("Podaj miejsce urodzenia");
            string placeOfBirth = Console.ReadLine();

            numberOfYears = CalculateNumberOfYears(yearOfBirth, monthOfBirth , dayOfBirth);
            
            if (numberOfYears > -1)
            Console.WriteLine($"Cześć {name} masz {numberOfYears} lat \n urodziłeś się w {placeOfBirth}");
            Console.ReadLine();
        }

        static int CalculateNumberOfYears(int year, int month , int day)
        {
            DateTime currentDate = DateTime.Now;
            int numberOfYears;
            try
            {
                DateTime date   = new DateTime(year, month, day);
                TimeSpan interval = currentDate - date;
                numberOfYears = interval.Days / 365;
            }
            catch (ArgumentOutOfRangeException ex)
            {

                
                string message = $"Z podanych parametów: rok {year}, \n miesiąc {month}, \n dzień  {day} \n nie można utworzyć prawidłowej daty";
                //throw new Exception(message);
                Console.WriteLine(message);
                return -1;
            }
            return numberOfYears;
        }

        static int GetNumber()
        {
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int number))
            {
                string message = $"wpisanych znaków {input} nie można przekonwertować na liczbę"; 
                throw new Exception(message);
            }
            return number;
        }
        
    }
}
