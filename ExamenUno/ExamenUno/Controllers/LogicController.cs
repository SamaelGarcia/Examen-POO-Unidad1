using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;

namespace ExamenUno.Controllers
{
    [ApiController]
    [Route("api/logic")]
    public class LogicController : ControllerBase
    {
       
        [HttpGet("is-prime/{number}")]
        public IActionResult GetPrime(int number)
        {
            if( number < 2)
            {
                return Ok(new { number, isPrime = false });
            }
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return Ok(new { number, isPrime = false });
                }
            }

            return Ok(new { number, isPrime = true });
        }

        [HttpGet("factorial/{number_factorial}")]
        public IActionResult GetFactorial(int number_factorial)
        {
            if (number_factorial < 0)
            {
                return BadRequest("Debe ser un número entero positivo.");
            }

            long factorial = CalculateFactorial(number_factorial);
            return Ok(new { number = number_factorial, factorial = factorial });
        }
        private long CalculateFactorial(int number)
        {
            if (number == 0 || number == 1)
            {
                return 1;
            }

            long result = 1;
            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }

        [HttpGet("fibonacci/{limit}")]
        public IActionResult GetFibonacci(int limit)
        {
            var fiboSequence = new List<int>();
            if (limit >= 0)
            {
                fiboSequence.Add(0);
            }
            if (limit >= 1)
            {
                fiboSequence.Add(1);
            }
            int a = 0, b = 1;

            while(true)
            {
                int siguiente = a + b;
                if (siguiente > limit) break;

                fiboSequence.Add(siguiente);
                a = b;
                b = siguiente;
            }

            return Ok(new { limit = limit, sequence = fiboSequence });
        }

        [HttpGet("count-vowels")]
        public IActionResult CountVowels([FromQuery] string text)
        {
            int vowelCount = CountVowelOccurrences(text);
            return Ok(new { text = text, vowelCount = vowelCount });
        }

        private int CountVowelOccurrences(string text)
        {
            int count = 0;
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'á', 'é', 'í', 'ó', 'ú', 'A', 'E', 'I', 'O', 'U', 'Á', 'É', 'Í', 'Ó', 'Ú' };

            foreach (char c in text)
            {
                if (vowels.Contains(c))
                {
                    count++;
                }
            }

            return count;
        }
    }
}