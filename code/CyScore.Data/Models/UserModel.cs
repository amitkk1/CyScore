using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyScore.Data.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public string Salt { get; set; }
    }
}
