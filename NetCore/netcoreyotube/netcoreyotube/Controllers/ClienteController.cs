using Microsoft.AspNetCore.Mvc;
using netcoreyotube.Models;
using System.Reflection.Metadata.Ecma335;

namespace netcoreyotube.Controllers
{ 
    [ApiController]
    [Route("Cliente")]

    public class ClienteController: ControllerBase
    {
//string sucesoAC = "";

        [HttpGet]
        [Route("Listar")]
        public dynamic ListarCliente()
        {
            List<Cliente> LstClientes = new List<Cliente>
            {
                new Cliente
                {
                    Id= 1, correo="google.com",edad=19,Nombre="Andres Cueva"
                },
                new Cliente
                {
                    Id= 2, correo="gmail.com",edad=65,Nombre="Xavier Cueva"
                },
                new Cliente
                {
                    Id= 3, correo="outlook.com",edad=79,Nombre="Omar Risueña"
                }
            };
            return LstClientes;
           
        }

        [HttpGet]
        [Route("ListarId")]
        public dynamic ListarClienteId(int _id)
        {
          
            return new Cliente
            {
                Id = _id,
                correo = "google.com",
                edad = 19,
                Nombre = "Andres Cueva"
               ,sucesoAC = "Funciona OK"
            };   
        
        }


        [HttpPost]
        [Route("Guardar")]
        public dynamic GuardarCliente(Cliente cliente)
        {
            cliente.Id = 4;
            // codigo para q se guarde en la BD
            return new { 
                success=true, message="Cliente Registrado"
                ,result=cliente
            };
        }

        [HttpPost]
        [Route("Eliminar")]
        public dynamic EliminarCliente(Cliente cliente)
        {
             cliente.Id = 3;
            string token= Request.Headers.Where(x => x.Key == "Autorizado").FirstOrDefault().Value;
            if(token!="AC2023")
            {
                return new
                {
                    success = true,
                    message = "token_incorrecto",
                    result = cliente
                };
            }
            else
            {
                     return new
                                {
                                    success = true,
                                    message = "Token correcto"
                                    ,result = cliente
                                };
            }
           
        }
    }
       
 }

