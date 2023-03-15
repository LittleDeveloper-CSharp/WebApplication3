using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Database
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }

        public int UserId { get; set; }

        [InverseProperty(nameof(Database.User.Orders))]
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
