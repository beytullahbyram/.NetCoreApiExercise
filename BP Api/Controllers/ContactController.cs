using BP_Api.Models;
using BP_Api.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BP_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IConfiguration configuration_;
        private readonly IContactService contactService_;
        public ContactController(IConfiguration Configuration,IContactService ContactService)
        {
            configuration_= Configuration;
            contactService_= ContactService;    
        }

        [HttpGet]
        public String Get()
        {
            return configuration_["ReadMe"].ToString();    
        }

        [HttpGet("{id}")]
        public ContactDVO GetContactById(int id)
        {
            return contactService_.GetContactById(id);
        }

        [HttpPost]
        public ContactDVO CreateContact(ContactDVO contactDVO)
        {
            //100den büyük değilse geri döner 
            return contactDVO;
        }
    }
}
