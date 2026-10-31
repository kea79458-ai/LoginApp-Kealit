using System.ComponentModel.DataAnnotations;

namespace LoginApp_Kealit.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public string Password { get; set; }

        public string Roles { get; set; }

        public string Remark { get; set; }
    }
}