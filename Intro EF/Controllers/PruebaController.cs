using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intro_EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Intro_EF.Controllers
{
    [Route("api/[controller]")] // http://localhost/api/Prueba
    [ApiController]
    public class PruebaController : ControllerBase
    {
        [HttpGet("Test")] // http://localhost/api/Prueba/Test
        public string TestBD()
        {
            // Cómo trabajar con "C" de CRUD: Create - Read - Update - Delete
            
            // Cómo utilizar el contexto y lo demás desde la BD
            var bd = new EfContext(); // Llamamos al contexto
            
            // Crear un nuevo usuario
            // user: momonga
            // pass: lord
            var nuevoUsuario = new Usuario();
            nuevoUsuario.username = "momonga";
            nuevoUsuario.password = "lord";
            bd.Add(nuevoUsuario);
            bd.SaveChanges(); 
            /*
             * Equivalente a:
             * INSERT INTO usuario(username, password) VALUES('momonga','lord');
             */
            
            return "Ok!";
        }
    }
}