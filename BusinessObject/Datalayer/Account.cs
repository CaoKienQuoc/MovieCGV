using System;
using System.Collections.Generic;

namespace BusinessObject.Datalayer
{
    public partial class Account
    {
        public Account()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int AccountId { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string IdentityCard { get; set; }
        public string Image { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? RegisterDate { get; set; }
        public int? Status { get; set; }
        public string Username { get; set; }
        public long RoleId { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
