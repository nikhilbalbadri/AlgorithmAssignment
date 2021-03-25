using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithmAssignment.Controllers
{
    [ApiController]
    [Route("api/AlgorithmController/[action]")]
    public class AlgorithmController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public bool Algo1(string request)
        {
            int[] array = request.Select(digit => int.Parse(digit.ToString())).ToArray();
            if (CheckIfConsecutive(array))
            {
                return true;
            }
            else
            {
                int n = 0;
                if (array.Length % 2 != 0)
                {
                    n = Convert.ToInt32(Math.Round((double)array.Length / 2));
                }
                else
                {
                    n = Convert.ToInt32(Math.Round((double)array.Length+1 / 2));
                }
                for (int i = 2; i < n; i++)
                {
                    int[] groupArray = GroupIntegers(array, i);
                    if (CheckIfConsecutive(groupArray))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        

        [HttpPost]
        public string Algo2(string request)
        {
            string response = string.Empty;
            string[] words = request.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length % 2 != 0)
                {
                    char[] charArray = words[i].ToCharArray();
                    Array.Reverse(charArray);
                    response = response + new string(charArray) + " ";
                }
                else
                {
                    response = response + words[i] + " ";
                }
            }
            return response;
        }
        [HttpPost]
        public bool Algo3(string request)
        {
            int[] array = request.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            Array.Sort(array);
            if (array.Length != array.Distinct().Count())
            {
                return false;
            }
            else
            {
                return CheckIfConsecutive(array);
            }
        }
        //Common function to check if the integers of an array are consecutive
        private bool CheckIfConsecutive(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] + 1 != array[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
        //Grouping integers with 'n' specifying the number of integers in a group as one integer.
        private int[] GroupIntegers(int[] array, int n)
        {
            //int[] result = new int[] { };
            List<int> result = new List<int>();
            for (int i = 0; i < array.Length; i += n)
            {
                var k = String.Join("", array.Skip(i).Take(n).ToList());
                result.Add(int.Parse(k));
            }
            return result.ToArray();
        }
    }
}
