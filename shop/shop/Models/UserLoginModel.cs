using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage ="Kullanıcı adı boş olamaz")]
        [EmailAddress(ErrorMessage ="E-posta formatını düzeltiniz")]
        public string MailAddress { get; set; }
        [Required(ErrorMessage = "Şifre boş olamaz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
