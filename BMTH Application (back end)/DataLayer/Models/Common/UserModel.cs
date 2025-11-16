
using System.ComponentModel.DataAnnotations;
using DataLayer.Models.Store.Orders;

namespace DataLayer.Models.Common
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        // Navigation
        public List<OrderModel> Orders { get; set; } = new();
    }
}
