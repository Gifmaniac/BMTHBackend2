
using System.ComponentModel.DataAnnotations;
using Contracts.Enums.User;
using DataLayer.Models.Store.Orders;

namespace DataLayer.Models.User
{
    public class UserModel
    {
        [Key]
        // Nullable for guest users.    
        public int? UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Roles Role { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation
        public List<OrderModel> Orders { get; set; } = new();
    }
}
