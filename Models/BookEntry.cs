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
        [DisplayName("Таб.№")]
        public string PersonnelNumber { get; set; }
        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Должность")]
        public string Position { get; set; }
        [DisplayName("Отдел")]
        public string Department { get; set; }
        [DisplayName("М. тел.")]
        public string LocalPhoneNumber { get; set; }
        [DisplayName("Г. тел.")]
        public string CityPhoneNumber { get; set; }
        [DisplayName("Почта")]
        public string Mail { get; set; }
        [DisplayName("Комната")]
        public string Room { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string Status { get; set; }

        public BookEntry()
        {
            Status = string.Empty;
        }

        public override string ToString()
        {
            return $"Entry: {Name} {Department} {Mail} {Room}";
        }
    }
}
