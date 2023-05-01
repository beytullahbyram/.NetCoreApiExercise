using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP_Api.Data.Models
{
    //Veri tabanımızdaki tablolarımızın karşılığı olacak class
    public class Contact
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
