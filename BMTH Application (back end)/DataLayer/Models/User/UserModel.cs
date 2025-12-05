
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
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required Roles Role { get; set; }
        public required DateTime CreatedAt { get; set; }

        // Navigation
        public List<OrderModel> Orders { get; set; } = new();
    }
}
