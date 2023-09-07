using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class CalcController : Controller
    {
        public string Index(int a, int b, string c)
        {
            switch (c)
            {
                case null:
                case "+": return $"{a} + {b} = {a + b}";
                case "-": return $"{a} - {b} = {a - b}";
                case "*": return $"{a} * {b} = {a * b}";
                case "/": return b != 0 ? $"{a} / {b} = {a / b}" : "Делить на ноль нельзя"; // Тернарный оператор
                default:
                    return "Можно передовать только операции +,-,*";
            }
        }
    }
}