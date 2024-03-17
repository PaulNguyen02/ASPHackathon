using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
namespace WebEnvironment_Hackathon_GaMo.Models.ViewModel
{
    
        public class LoginVm
        {
            public int Id { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập UserName")]
            public string Name { get; set; }

            [DataType(DataType.Password), Required(ErrorMessage = "Làm ơn nhập Password")]
            public string Password { get; set; }
            public string ReturnUrl { get; set; }
        }
}
