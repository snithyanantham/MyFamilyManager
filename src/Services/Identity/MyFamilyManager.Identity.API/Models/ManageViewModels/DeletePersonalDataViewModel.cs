﻿using System.ComponentModel.DataAnnotations;

namespace MyFamilyManager.Identity.API.Models.ManageViewModels
{
    public class DeletePersonalDataViewModel
    {
        public bool RequirePassword { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "PASSWORD_REQUIRED")]
        public string Password { get; set; }
    }
}
