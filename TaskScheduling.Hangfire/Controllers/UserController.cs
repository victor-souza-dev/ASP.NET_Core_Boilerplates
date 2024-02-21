using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;

namespace TaskScheduling.Hangfire.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("pagination")]
        public IActionResult GetWithPagination([FromQuery] GenericPagination pagination)
        {
            try
            {
                return Ok(_userService.GetWithPagination(pagination));
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_userService.GetAll().Result);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_userService.GetById(id).Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserDTO body)
        {
            try
            {
                User user = new User(body.Name, body.Email, body.Password);
                _userService.Create(user);
                return Ok("Criado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] UserDTO body, string id)
        {
            try
            {
                User user = new User(body.Name, body.Email, body.Password);
                _userService.Update(id, user);
                return Ok("Alterado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            try
            {
                _userService.Delete(id);
                return Ok("Deletado com sucesso!");
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
    