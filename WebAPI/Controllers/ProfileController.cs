using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IRepository<Profile> _profileRepository;

        public ProfileController(IRepository<Profile> profileRepository)
        {
            _profileRepository = profileRepository;
        }


        [HttpGet("get")]
        public IEnumerable<Profile> Get()
        {
            return _profileRepository.GetAll();
        }

        [HttpPost("add")]
        public ObjectResult Add(ProfileDto profileDto)
        {
            _profileRepository.Add(new Profile(profileDto.Name, profileDto.Followers, profileDto.Bio, profileDto.UserId));
            _profileRepository.SaveChanges();
            return Ok(profileDto);
        }

        [HttpPut("update")]
        public ObjectResult Update(ProfileDto profileDto, Guid profileId)
        {
            var profileFromDb = _profileRepository.Find(u => u.Id == profileId).FirstOrDefault();
            if (profileFromDb == null)
            {
                return NotFound("Profile not found");
            }

            profileFromDb.Name = profileDto.Name;
            profileFromDb.UserId = profileDto.UserId;
            profileFromDb.Followers = profileDto.Followers;
            profileFromDb.Bio = profileDto.Bio;
            _profileRepository.Update(profileFromDb);

            _profileRepository.SaveChanges();
            return Ok(profileFromDb);
        }



        [HttpDelete("delete")]
        public void Delete(Guid profileId)
        {
            var profileFromDb = _profileRepository.Find(u => u.Id == profileId).FirstOrDefault();
            if (profileFromDb != null)
            {
                _profileRepository.Remove(profileFromDb);
                _profileRepository.SaveChanges();
            }
        }

    }
}
