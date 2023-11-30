using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PhoneEdit.Helpers;

namespace PhoneEdit.Models;

public class BookEntry
{
    [HiddenInput(DisplayValue = false)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    [Remote(action: "RemoteVerifyPersonnelNumber",
        controller: "PhoneBook", AdditionalFields = nameof(Id))]
    [DisplayName("Табельный номер")]
    public string PersonnelNumber { get; set; }

    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    [DisplayName("ФИО")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    [DisplayName("Должность")]
    public string Position { get; set; }

    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    [DisplayName("Подразделение")]
    public string Department { get; set; }

    [DisplayName("Местный телефон")]
    public string? LocalPhoneNumber { get; set; } = string.Empty;

    [DisplayName("Городской телефон")]
    public string? CityPhoneNumber { get; set; } = string.Empty;

    [DisplayName("Почта")]
    public string? Mail { get; set; } = string.Empty;

    [DisplayName("Комната")]
    public string? Room { get; set; } = string.Empty;

    [HiddenInput(DisplayValue = false)] 
    public string Status { get; set; } = string.Empty;

    public override string ToString()
    {
        // Used for full-text search
        return $"Entry: {Name} {Department} {Mail} {Room}";
    }
}