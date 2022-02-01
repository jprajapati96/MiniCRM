using CRM.Application.Models.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Application.Models.Customer
{
    public class CustomerViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UserViewModel userViewModel { get; set; }  
    }
}
