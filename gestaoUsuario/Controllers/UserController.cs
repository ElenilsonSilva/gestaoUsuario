using gestaoUsuario.Model;
using gestaoUsuario.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestaoUsuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private DataBase _database;
        public UserController(DataBase dataBase)
        {
            _database = dataBase;
        }
        
        [HttpGet]
        public IActionResult ListarTodosUsuarios()
        {
            var result = _database.Users;
            if (result.Any())
                return Ok();
            else
                return StatusCode(204, "A lista de usuários está vazia");
        }

        [HttpGet("{id}")]
        public IActionResult BuscarUsuarioPorId([FromRoute] int id, [FromServices] DataBase dataBase)
        {
            return Ok(dataBase.Users.Where(x => x.Id == id));
        }

        [HttpPost]
        public IActionResult CriarUsuario([FromBody] User user, [FromServices] DataBase dataBase)
        {
            dataBase.Add(user);
            //salva no banco as alterações
            dataBase.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarUsuarioPorId([FromRoute] int id, [FromServices] DataBase dataBase)
        {
            var usuarioParaDeletar = dataBase.Users.Where(x => x.Id == id).FirstOrDefault();

            dataBase.Remove(usuarioParaDeletar);
            dataBase.SaveChanges();

            return StatusCode(200, $"O usuário {usuarioParaDeletar.Name} foi deletado com sucesso");
        }

    }
}
