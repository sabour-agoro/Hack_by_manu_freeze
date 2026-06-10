using Csharp.Data;
using Csharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/students")]

public class StudentControllers: ControllerBase
{
    private readonly dbConnexion Context;
    public StudentControllers(dbConnexion context)
    {
        Context = context;
    }
    [HttpGet]
    public async Task<ActionResult<List<ReadStudentDto>>> GetStudent()
    {
        var data = await Context.students.ToListAsync();
        return Ok(data);
    }

    [HttpGet]
   public async Task<ActionResult<List<ReadStudentDto>>> GetByClassStudent(int classroomId)
{
    try
    {
        var data = await Context.students
            .Where(stu => stu.ClasseId == classroomId)
            .ToListAsync();
            
        if (data == null )
            return NotFound("Aucun élève trouvé");

        return Ok(data);
    }
    catch (Exception e)
    {
        return Problem(detail: e.Message);
    }
}
[HttpPost]
public async Task<ActionResult<List<CreateStudentDto>>> AddStudents(Students stu)
    {
        try{
        await Context.students.AddAsync(stu);
        await Context.SaveChangesAsync();
        return Ok(stu);
        }catch (Exception e)
    {
        return Problem(detail: e.Message);
    }
    }

    [HttpPut("{id}")]
public async Task<ActionResult<List<UpdateStudentDto>>> UpdateStudents(int id,Students stu)
    {
        try
        {
            var stuEx = await Context.students.FirstOrDefaultAsync(stu=> stu.Id==id);
            if(stuEx==null)
            return NotFound("Aucune correspondance");
            stuEx.BirthDate=stu.BirthDate;
            stuEx.classe=stu.classe;
            stuEx.FirstName=stu.FirstName;
            stuEx.gender=stu.gender;
            stuEx.LastName=stu.LastName;
            await Context.SaveChangesAsync();
            return Ok(stuEx);
            
        }catch (Exception e)
    {
        return Problem(detail: e.Message);
    }
        
    }
    [HttpDelete]
public async Task<ActionResult> DeleteStudents(int id)
    {
        try
        {
            var stuEx = await Context.students.FirstOrDefaultAsync(stu=>stu.Id==id);
            if(stuEx==null)
            return NotFound("Aucune correspondance");
             Context.students.Remove(stuEx);
             await Context.SaveChangesAsync();
             return Ok("supprimer avec succes");

            
        }catch (Exception e)
    {
        return Problem(detail: e.Message);
    }
    }

    

    
    
}