using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Models;

public class Card
{
    public Card(string cardOwner, string cardNumber, int expireDateMonth, int expireDateYear, int cvc)
    {
        CardOwner = cardOwner; 
        CardNumber = cardNumber;
        ExpireDateMonth = expireDateMonth;
        ExpireDateYear = expireDateYear;
        CVC = cvc;
    }

    [Required]
    public string CardOwner { get; set; }
    [Required]
    [StringLength(16)]
    [MinLength(16)]
    [RegularExpression(@"\d{16}")]
    public string CardNumber { get; set; }
    [Required]
    [Range(1, 12)]
    public int ExpireDateMonth { get; set; }
    [Required]
    [Range(2022, 2040)]
    public int ExpireDateYear { get; set; }
    [Required]
    [Range(100, 999)]
    public int CVC { get; set; }
    
    public bool IsValid()
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(this);
        DateTime currentDate = new DateTime(ExpireDateYear, ExpireDateMonth, 1);
        if (!Validator.TryValidateObject(this, context, results, true)) return false;
        if (currentDate <= DateTime.Today) return false;
        return true;
    }
}