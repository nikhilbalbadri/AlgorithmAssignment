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
                for (int i = 1; i < array.Length - 1; i++)
                {
                    if (i == 1)
                    {
                        if (CheckIfConsecutive(array))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        //groupIntegers(array, i);
                        return true;
                    }
                }
                return false;
            }             
        }

        //private int[] groupIntegers(int[] array,int n)
        //{
        //    string[] numbers = array.Take(n).Select(i => i.ToString()).ToArray();
        //}
        
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
    }
}
