using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Csharp.Data;
using Csharp.Models;


namespace Csharp.Controllers
{
    [ApiController]
    [Route("api/classe")]
    public class ClasseControllers : ControllerBase
    {
        private readonly dbConnexion Context;

        public ClasseControllers(dbConnexion context)
        {
            Context = context;
        }
//la liste des classes 
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Classe>>> GetClasse()
        {
            return await Context.classes.ToListAsync();
        }
        
//creation de classe
        [HttpPost]
         public async Task<ActionResult<Classe>> PostClasse(CreateClassDto dto)
        {
            var classe = new Classe
            {
                Name = dto.Name,
                level = dto.level,
                
            };
            Context.classes.Add(classe);
            await Context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClasse), new {id = classe.Id}, classe);
        }
//pour modifier 
        [HttpPut("{Id}")]
        public async Task<IActionResult>PutClasse(int Id , UpdateClassDto dto)
        {
            var classe = await Context.classes.FindAsync(Id);
            if(classe == null)
                return NotFound("Classe pas trouvé");
            
            if(dto.Name != null)
                classe.Name = dto.Name;

            await Context.SaveChangesAsync();
            return Ok(classe);
            
        }
//supprimer 
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteClasse(int Id)
        {
            var classe = await Context.classes.FindAsync(Id);
            if (classe == null)
            {
                return NotFound("Classe pas trouvé");
            }
            Context.classes.Remove(classe);
            await Context.SaveChangesAsync();

            return Ok(classe);
        }





        
    }


}