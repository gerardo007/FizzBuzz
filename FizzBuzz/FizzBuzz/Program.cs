using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{

    public delegate bool FizzBuzzComparison(int number);

    public class FizzBuzzCalculator
    {
        private readonly Dictionary<Tuple<bool, bool>, string> _mappings;
        private readonly FizzBuzzComparison _comparison1;
        private readonly FizzBuzzComparison _comparison2;

        public FizzBuzzCalculator(Dictionary<Tuple<bool, bool>, string> mappings, FizzBuzzComparison comparison1, FizzBuzzComparison comparison2)
        {
            _mappings = mappings;
            _comparison1 = comparison1;
            _comparison2 = comparison2;
        }

        public string NumberFormat(int number)
        {
            var mappedKey = new Tuple<bool, bool>(_comparison1(number), _comparison2(number));
            return String.Format("{0} {1}", number, _mappings[mappedKey]);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int _lowerNumber, _higherNumber;

            var mappings = new Dictionary<Tuple<bool, bool>, string>
                {
                    { new Tuple<bool, bool>(true, true), "- FizzBuzz"},
                    { new Tuple<bool, bool>(true, false), "- Fizz"},
                    { new Tuple<bool, bool>(false, true), "- Buzz"},
                    { new Tuple<bool, bool>(false, false), " - N/A"}
                };
                        
            try 
            {
                
                Console.WriteLine("Enter a lower number: ");
                string LowerNumber = Console.ReadLine();
                
                if (int.TryParse(LowerNumber, out _lowerNumber))
                {
                    //Console.WriteLine("Thank you for entering: {0}", _lowerNumber):
                }
                else 
                {
                    Console.WriteLine("Invalid input: {0}", LowerNumber);
                }
                Console.WriteLine("Enter a higher number: ");
                string HigherNumber = Console.ReadLine();
                if (int.TryParse(HigherNumber, out _higherNumber))
                {
                    //Console.WriteLine("Thank you for entering: {0}", _higherNumber);
                }
                else
                {
                    Console.WriteLine("Invalid input: {0}", HigherNumber);
                }

                if (_lowerNumber > _higherNumber)
                {
                    Console.WriteLine("Invalid Data. Higher number should be > than lower number");
                }
                else
                {
                    var fizzBuzz = new FizzBuzzCalculator(mappings, (n) => n % _lowerNumber == 0, (n) => n % _higherNumber == 0);

                    for (int i = 0; i < 200; i++)
                    {
                        Console.WriteLine(fizzBuzz.NumberFormat(i));
                    }


                    Console.ReadLine();
                }

            }
            catch (Exception ex)
            {                
                Console.WriteLine(ex.Message);
            }


           
        }
    }
}
