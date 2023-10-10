﻿using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class UserDeliveryInfo
    {
        [Required(ErrorMessage ="Поле Ф.И.О. должно быть заполнено")]
        [StringLength(70,MinimumLength =3,ErrorMessage ="ФИО должно содержать от 3 до 70 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Поле Email должно быть заполнено")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле Телефон должно быть заполнено")]
        [StringLength(20,MinimumLength =5,ErrorMessage ="Поле телефон должно содержать от 5 до 20 символов")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Поле Адрес должно быть заполнено")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Поле Адрес должно содержать от 5 до 200 символов")]
        public string Address { get; set; }
    }
}
