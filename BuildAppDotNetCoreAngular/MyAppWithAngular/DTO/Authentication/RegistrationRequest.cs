using MyAppWithAngular.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppWithAngular.DTO.Authentication
{
    public class RegistrationRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Common_UsernameRequired")]
        [StringLength(30, MinimumLength = 8, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Common_UsernameSizeNotMatches")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Common_PasswordRequired")]
        [StringLength(15, MinimumLength = 6, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Common_PasswordSizeNotMatches")]
        public string Password { get; set; }
    }
}
