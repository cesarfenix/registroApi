using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using registroApi.Context;
using registroApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace registroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly AppDbContext context;
        public PersonaController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<PersonaController>
        //metodo para mostrar los datos
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.persona.ToList());
                //si hay datos los muestra enlistados
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<PersonaController>/5
        [HttpGet("{id}", Name ="GetPersona")]
        public ActionResult Get(int id)
        {
            try
            {
                var persona = context.persona.FirstOrDefault(f => f.id == id);
                return Ok(persona);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<PersonaController>
        // metodo para crear uno nuevo
        [HttpPost]
        public ActionResult Post([FromBody] Persona persona)
        {
            try
            {
                context.persona.Add(persona);
                //verifica si hay una nueva persona agregada
                context.SaveChanges();
                //guarda los cambios
                return CreatedAtRoute("GetPersona", new { id = persona }, persona);
                //retorna una nueva persona creada
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PersonaController>/5
        //metodo para modificar una persona por id
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Persona persona)
        {
            try
            {
                if (persona.id == id)
                {
                    context.Entry(persona).State = EntityState.Modified;
                    // se debe llamar a la libreria using entityframe para quitar error
                    // para consultar 
                    context.SaveChanges();
                    // guardamos la consulta
                    return CreatedAtRoute("GetPersona", new { id = persona.id }, persona);
                    // nos retorna el elemento
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            } 
        }

        // DELETE api/<PersonaController>/5
        // para borrar
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var persona = context.persona.FirstOrDefault(f => f.id == id);
                //comparamos que el la persona en el campo id sea igual al id y validamos con el if
                if (persona != null)
                {
                    context.persona.Remove(persona);
                    // si es igual la elimina
                    context.SaveChanges();
                    //salvamos cambios
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
