using Microsoft.AspNetCore.Mvc;
using PracticeApi.Models;
using AutoMapper;
using PracticeApi.Services;

namespace PracticeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();

            var res = _mapper.Map<IEnumerable<UserReadDto>>(users);

            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDto userdto)
        {
            //client inputs json data which aspnet uatomaticall converts into usercreatedto
            // i take that input and turn it from DTO to the actual entity User. this is called mapping from DTO to domain/entity

            var user = _mapper.Map<User>(userdto); // <Destination type> Take this object and convert it INTO a user.
            // userdto is the data we are copying it from. User userdto as the data to copy FROM
            //this all translates to: take userdto and map it into a new user object

            var createdUser = await _userService.CreateAsync(user);
            // i pass the entity to the service which handles saving it using EF core

            var userread = _mapper.Map<UserReadDto>(createdUser);

            return CreatedAtAction(nameof(GetById), new { id = userread.Id }, userread);
            //returns http 201 its the correct rest response for creation
            // it returns the location of the new resource dld /api/users/5
            // userread =  returns the created object json data back

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User user)
        {
            var updatedUser = await _userService.UpdateAsync(id, user);

            if (updatedUser == null)
                return NotFound();

            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteAsync(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}