using AutoMapper;
using BP_Api.Data.Models;
using BP_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP_Api.Service
{
    public class ContactService : IContactService
    {
        private readonly IMapper mapper_;
        public ContactService(IMapper mapper)
        {
            mapper_ = mapper;  
        }


        public ContactDVO GetContactById(int id)
        {
            //Veri tabanından veri getirme işlemi
            Contact dbContact=getFakeContact();
            ////Mapping işlemi
            ////1
            //ContactDVO resultContactDVO=new ContactDVO();
            //mapper_.Map(dbContact,resultContactDVO);
            
            //2
            ContactDVO resDVO=mapper_.Map<ContactDVO>(dbContact);
            return resDVO;
        }


       
        private Contact getFakeContact()
        {
            return  new Contact()
            {
                ID=1,
                LastName="john",
                Name="Doe"
            };
        }
    }
}
