using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly IRepository<Subscription> _subscriptionRepository;

        public SubscriptionController(IRepository<Subscription> subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        [HttpGet("get")]
        public IEnumerable<Subscription> Get()
        {
            return _subscriptionRepository.GetAll();
        }

        [HttpPost("add")]
        public ObjectResult Add(SubscriptionDto subscriptionDto)
        {
            _subscriptionRepository.Add(new Subscription(subscriptionDto.Name, subscriptionDto.Description, subscriptionDto.Price));
            _subscriptionRepository.SaveChanges();
            return Ok(subscriptionDto);
        }

        [HttpPut("update")]
        public ObjectResult Update(SubscriptionDto subscriptionDto, Guid subscriptionId)
        {
            var subscriptionFromDb = _subscriptionRepository.Find(u => u.Id == subscriptionId).FirstOrDefault();
            if (subscriptionFromDb == null)
            {
                return NotFound("Subscription not found");
            }

            subscriptionFromDb.Name = subscriptionDto.Name;
            subscriptionFromDb.Description = subscriptionDto.Description;
            subscriptionFromDb.Price = subscriptionDto.Price;
            _subscriptionRepository.Update(subscriptionFromDb);

            _subscriptionRepository.SaveChanges();
            return Ok(subscriptionFromDb);
        }

        [HttpDelete("delete")]
        public void Delete(Guid subscriptionId)
        {
            var subscriptionFromDb = _subscriptionRepository.Find(u => u.Id == subscriptionId).FirstOrDefault();
            if (subscriptionFromDb != null)
            {
                _subscriptionRepository.Remove(subscriptionFromDb);
                _subscriptionRepository.SaveChanges();
            }
        }
    }
}
