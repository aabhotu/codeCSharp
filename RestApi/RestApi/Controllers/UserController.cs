using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestApi.Contracts;
using RestApi.Data;
using RestApi.Data.DTO;
using RestApi.Entities;
using RestApi.Entities.DTO;
using RestApi.Models;
using RestApi.Repository;
using System.Collections;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private IMapper _mapper;
        private IUserRepository _user;
        private RepositoryContext _context;
        public UserController(IMapper mapper, IUserRepository userRepo, RepositoryContext context)
        {
            _mapper = mapper;
            _user = userRepo;
            _context = context;
        }
        public IUserRepository User
        {
            get
            {
                if (_user != null)
                    return _user;
                return new UserRepository(_context);
            }
        }
        [HttpGet]
        public IActionResult GetAllUers()
        {
            try {
                var users = _user.GetAllUser();
                var userResult = _mapper.Map<IEnumerable<userDto>>(users);
                return Ok(userResult);
            }
            catch(Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name ="GetUser")]
        public ActionResult GetUsers(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            //var user = UserDatas.UserList.FirstOrDefault(i => i.id == id);
            var user = _user.GetUserById(id);
            if(user == null)
            {
                return NotFound();
            }
            var userResult = _mapper.Map<userDto>(user);
            return Ok(userResult);
        }
        [HttpPost]
        public ActionResult<User> AddUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid");
            }
            var userEntity = _mapper.Map<User>(user);
            _user.Create(userEntity);
            _user.SaveChanges();
            var userCreate = _mapper.Map<userDto>(userEntity);
            return CreatedAtRoute("GetUser", new {id = userCreate.id }, userCreate);
        }
        [HttpDelete("{id}")]
        public ActionResult<User> DeleteUser(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = _user.GetUserById(id);
            _user.DeleteUser(user);
            _user.SaveChanges();

            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserForUpdate user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            var userEntity = _user.GetUserById(id);
            if (userEntity == null)
            {
                return NotFound();
            }
            _mapper.Map(user, userEntity);
            _user.UpdateUser(userEntity);
            _user.SaveChanges();
            return NoContent();
        }
    }
}
