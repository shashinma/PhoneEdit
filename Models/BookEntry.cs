using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace PhoneEdit.Models
{
    public partial class BookEntry
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string PersonnelNumber { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string LocalPhoneNumber { get; set; }
        public string CityPhoneNumber { get; set; }
        public string Mail { get; set; }
        public string Room { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string Status { get; set; }
    }
}
