using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PhoneEdit.Models
{
    public partial class BookEntry
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [Remote(action: "VerifyPersonnelNumber", controller: "PhoneBook", AdditionalFields = "Id")]
        [DisplayName("Таб.№")]
        public string PersonnelNumber { get; set; }

        [Required]
        [DisplayName("Имя")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Должность")]
        public string Position { get; set; }

        [Required]
        [DisplayName("Подразделение")]
        public string Department { get; set; }

        [DisplayName("М. тел.")]
        public string LocalPhoneNumber { get; set; } = string.Empty;

        [DisplayName("Г. тел.")]
        public string CityPhoneNumber { get; set; } = string.Empty;

        [DisplayName("Почта")]
        public string Mail { get; set; } = string.Empty;

        [DisplayName("Комната")]
        public string Room { get; set; } = string.Empty;

        [HiddenInput(DisplayValue = false)] 
        public string Status { get; set; } = string.Empty;

        public override string ToString()
        {
            // Used for full-text search
            return $"Entry: {Name} {Department} {Mail} {Room}";
        }
    }
}
