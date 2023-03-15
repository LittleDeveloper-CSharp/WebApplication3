using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Database
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public string Patronymic { get; set; }

        [InverseProperty(nameof(Order.User))]
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
