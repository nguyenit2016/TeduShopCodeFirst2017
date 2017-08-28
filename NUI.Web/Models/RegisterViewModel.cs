using System.ComponentModel.DataAnnotations;

namespace NUI.Web.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Tên là bắt buộc")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập là bắt buộc")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email là bắt buộc")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không đúng")]
        public string Email { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }
    }
}