using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP_Api.Models
{
    //Dışarıya verilecek tüm modeller bu projede olacak.
    //Bir kullanıcı GetContact methodunu çağırdığında bu bilgiler gönderilecek
    public class ContactDVO
    {
        public int ID { get; set; }
        public string FullName { get; set; }    
    }
}
