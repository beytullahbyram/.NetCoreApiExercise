using BP_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP_Api.Service
{
    public interface IContactService
    {
        public ContactDVO GetContactById(int id);
    }
}
