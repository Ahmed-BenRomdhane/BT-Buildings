using System.ComponentModel.DataAnnotations;
using System;

namespace BT_BuildingsDAL
{
    public class Owner
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a valid CIN")]
        public int CIN { get; set; }
        [Required(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your firstname")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your lastname")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter a valid phonenumber")]
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}