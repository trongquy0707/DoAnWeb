using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class ChucVu
    {
        public ChucVu()
        {
            Users = new HashSet<User>();
        }

        public int IdChucVu { get; set; }
        public string? TenChucVu { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
