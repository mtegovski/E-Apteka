using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Apteka.Models
{
    public class City
    {
       
        public List<string> cities { get; set; }
        public string selectedCity { get; set; }
        City() {
            cities = new List<string>() {
            "Скопје",
            "Демир Капија",
            "Куманово",
            "Кратово",
            "Охрид",
            "Ресен",
            "Крушево",
            "Битола",
            "Свети Николе",
            "Македонски Брод",
            "Кичево",
            "Струмица",
            "Валандово",
            "Дојран",
            "Богданци",
            "Гевгелија",
            "Прилеп",
            "Демир Хисар",
            "Пробиштип",
            "Кочани",
            "Македонска Каменица",
            "Виница",
            "Делчево",
            "Пехчево",
            "Берово",
            "Радовиш",
            "Штип",
            "Неготино",
            "Кавадарци",
            "Крива Паланка",
            "Велес",
            "Струга",
            "Тетово",
            "Гостивар",
            "Дебар" };
        }
    }
}