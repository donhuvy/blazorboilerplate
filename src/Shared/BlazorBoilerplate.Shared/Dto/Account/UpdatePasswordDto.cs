﻿using BlazorBoilerplate.Localization;
using System.ComponentModel.DataAnnotations;

namespace BlazorBoilerplate.Shared.Dto.Account
{
    public class UpdatePasswordDto
    {
        [Required]
        [StringLength(100, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorInvalidLength", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string NewPassword { get; set; }

        [Required]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Strings))]
        [Compare("NewPassword", ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "PasswordConfirmationFailed")]
        public string NewPasswordConfirm { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
    }
}