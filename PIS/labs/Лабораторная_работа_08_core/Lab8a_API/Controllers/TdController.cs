using Lab8a_API.Interfaces;
using Lab8a_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab8a_API.Controllers
{
    [ApiController]
    [Route("td")]
    public class TdController : ControllerBase
    {
        private ITD _tdService;

        public TdController(ITD tdService)
        {
            _tdService = tdService;
        }

        [HttpGet]
        async public Task<IEnumerable<Phone>> GetAll()
        {
            return _tdService.GetAll();
        }

        [HttpGet("{id}")]
        async public Task<Phone> Get(int id)
        {
            return _tdService.Get(id);
        }

        [HttpPost]
        async public Task Add(Phone phone)
        {
            _tdService.Add(phone.PhoneNumber, phone.OwnerName);
        }

        [HttpDelete("{id}")]
        async public Task Delete(int id)
        {
            _tdService.Delete(id);
        }

        [HttpPut("{id}")]
        async public Task Update(Phone phone)
        {
            _tdService.Update(phone);
        }
    }
}
