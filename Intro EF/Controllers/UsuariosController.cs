using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intro_EF.Models; // Modelos desde la bd (Usuario - Venta)
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Intro_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // Devuelve JSON
    public class UsuariosController : ControllerBase
    {
        [HttpGet("Lista")]
        public IEnumerable<Usuario> Listar()
        {
            IEnumerable<Usuario> usuarios;
            int total;
            // Cómo utilizar el contexto y lo demás desde la BD
            // "using" -> usar una variable y cuando se termina
            // de usar se usa el "destructor" para borrarlo de 
            // memoria
            using (EfContext bd = new EfContext())
            {
                // SELECT * FROM usuario;
                usuarios = bd.Usuarios.ToList();
                
                // SELECT * FROM usuario WHERE username = 'pablo';
                /* usuarios = bd.Usuarios
                    .Where(x => x.username == "pablo")
                    .ToList(); */
                
                // SELECT * FROM usuario WHERE username = 'pablo' AND password = '54321';
                /*usuarios = bd.Usuarios
                    .Where(x => x.username == "pablo" && x.password == "54321")
                    .ToList();*/
                
                // SELECT count(username) FROM usuario
                // total = bd.Usuarios.Count();
                
                // SELECT max(id) FROM usuario
                // int max = bd.Usuarios.Max(x => x.id);
                
                // SELECT min(id) FROM usuario
                // int min = bd.Usuarios.Min(x => x.id);
                
                // SELECT avg(id) FROM usuario
                // double avg = bd.Usuarios.Average(x => x.id);
                
                // SELECT * FROM usuario WHERE id >= 3 AND id <=5
                // ORDER BY id DESC;
                /*usuarios = bd.Usuarios
                    .Where(x => x.id >= 3 && x.id <= 5)
                    .OrderByDescending(x => x.id)
                    .ToList();*/
                
                // SELECT * FROM usuario WHERE id = 2; // SOLO POR CLAVE PRIMARIA
                /*var usuario = bd.Usuarios.FirstOrDefault(x => x.id == 2);
                usuario.username = "calvin";
                
                // UPDATE usuario SET username = 'calvin' WHERE id = 2;
                bd.Usuarios.Update(usuario);
                bd.SaveChanges();*/
                
                // DELETE FROM usuario WHERE id = 5;
                /*var usuario = bd.Usuarios.FirstOrDefault(x => x.id == 5);
                bd.Usuarios.Remove(usuario);
                bd.SaveChanges();*/

            }

            return usuarios;
        }

        [HttpPost("Update")] // https://localhost:44393/api/Usuarios/Update
        public string Actualizar([FromHeader]int id, [FromHeader]string newName)
        {
            using (var bd = new EfContext())
            {
                var usuario = bd.Usuarios.FirstOrDefault(x => x.id == id);
                usuario.username = newName;
                bd.Usuarios.Update(usuario);
                bd.SaveChanges();
            }

            return "Ok!";
        }
        
    }
}