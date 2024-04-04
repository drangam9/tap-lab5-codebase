using DataLayer.Models;
using DataLayer.Repository;
using DataLayer.Validation;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IRepository<User> _userRepository;
        private readonly IValidation _validation;


        public UserController(IRepository<User> userRepository, IValidation validation)
        {
            _userRepository = userRepository;
            _validation = validation;
        }


        [HttpGet("get")]
        public IEnumerable<User> Get()
        {
            return _userRepository.GetAll();
        }

        [HttpPost("add")]
        public ObjectResult Add(UserDto userDto)
        {
            var error = _validation.ValidateName(userDto.Name);
            if (error != null)
            {
                return BadRequest(error);
            }
            error = _validation.ValidateEmail(userDto.Email);
            if (error != null)
            {
                return BadRequest(error);
            }
            _userRepository.Add(new User(userDto.Name, userDto.Email, userDto.Password, userDto.TypeId, userDto.ProfileId));
            _userRepository.SaveChanges();
            return Ok(userDto);
        }

        [HttpPut("update")]
        public ObjectResult Update(UserDto userDto, Guid userId)
        {
            var userFromDb = _userRepository.Find(u => u.Id == userId).FirstOrDefault();
            if (userFromDb == null)
            {
                return NotFound("User not found");
            }

            userFromDb.Name = userDto.Name;
            userFromDb.Email = userDto.Email;
            userFromDb.Password = userDto.Password;

            userFromDb.TypeId = userDto.TypeId;
            _userRepository.Update(userFromDb);

            _userRepository.SaveChanges();
            return Ok(userFromDb);
        }



        [HttpDelete("delete")]
        public void Delete(Guid userId)
        {
            var userFromDb = _userRepository.Find(u => u.Id == userId).FirstOrDefault();
            if (userFromDb != null)
            {
                _userRepository.Remove(userFromDb);
                _userRepository.SaveChanges();
            }
        }
    }
}
