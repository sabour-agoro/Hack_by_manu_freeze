using Microsoft.AspNetCore.Mvc;

using Csharp.Models;
using Csharp.Data;
using Microsoft.EntityFrameworkCore;
[ApiController]
[Route("api/academic-years")]
public class AcademyCpntrollers : ControllerBase
{
    private readonly dbConnexion Context;
    public AcademyCpntrollers(dbConnexion context){
        Context = context;
        
    }
  [HttpGet]
  public async Task<ActionResult<List<ReadAcademyDto>>> GetAcademy()
    {
        try
        {
          var data = await Context.academicYears.ToListAsync();
          return Ok(data);
        }
        catch (Exception e)
        {
           return Problem(detail:e.Message);
        }
        
        
    }  
    [HttpPost]
    public async Task<ActionResult<List<CreateAcademyDto>>> AddAcademy(AcademicYear aca)
    {
        try
        {
         await Context.academicYears.AddAsync(aca);
        await Context.SaveChangesAsync();
        return Ok(aca);   
        }catch(Exception e)
        {
            return Problem(detail:e.Message);
        }
        
    }
  [HttpPut("{id}")]
  public async Task<ActionResult<List<UpdateAcademyDto>>> UpdateAcademy(int id , AcademicYear aca)
    {
        try
        {
            
        var acaEx = await Context.academicYears.FirstOrDefaultAsync(aca => aca.Id == id);
        if (acaEx == null)
        {
           return NotFound("Aucune correspondance");
        }
        else
        {
            acaEx.Name=aca.Name;
            acaEx.StartDate=aca.StartDate;
            acaEx.EndDate=aca.EndDate;
            await   Context.SaveChangesAsync();
            return Ok(acaEx);

        }
        } catch( Exception e)
        {
            return Problem(detail:e.Message);
        }

    }
    [HttpDelete("{id}")]

    public async Task<ActionResult> DeleteAcademy(int id)
    {
        try
        {
             var acaEx = await Context.academicYears.FirstOrDefaultAsync(aca=> aca.Id == id);
             if(acaEx == null)
             return NotFound("Aucune correspondance");
             Context.academicYears.Remove(acaEx);
             await Context.SaveChangesAsync();
             return Ok("Academic years delete");
;        }catch(Exception e)
        {
            return Problem(detail:e.Message);
        }
       

    }
    [HttpPatch("{id}/IsActive")]
    public async Task<ActionResult<List<PatchAcademyDto>>> PatchAcademy( int id, AcademicYear aca)
    {
        try
        {
            var acaEx = await Context.academicYears.FirstOrDefaultAsync(aca=> aca.Id==id);
            if(acaEx == null)
            return NotFound("Aucune correspondance");
            acaEx.IsActive=aca.IsActive;
            await Context.SaveChangesAsync();
            return Ok(acaEx);
        }catch(Exception e)
        {
            return Problem(detail:e.Message);
        }
    }
}