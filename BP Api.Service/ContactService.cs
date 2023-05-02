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
        private readonly IHttpClientFactory httpClientFactory_;
        public ContactService(IMapper mapper,IHttpClientFactory httpClientFactory)
        {
            mapper_ = mapper;  
            httpClientFactory_ = httpClientFactory; 
        }


        public ContactDVO GetContactById(int id)
        {
            //Veri tabanından veri getirme işlemi
            Contact dbContact=getFakeContact();
            
            var client = httpClientFactory_.CreateClient("garantiapi");

            //HttpClient client= new HttpClient();
            //client.BaseAddress = new Uri("örnekbankaadresi.com");//gideceği ana adress

            //// web sunucusunun bir web sayfasına ulaşmaya çalışan tarayıcıya verdiği yanıttır.
            //client.DefaultRequestHeaders.Add("Authorization","Value 123123");

            //String get = await client.GetStringAsync("/api/getpayment");

            //client.Dispose();

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
