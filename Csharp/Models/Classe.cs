namespace Csharp.Models;

public class Classe
{
    public int Id {get; set;}
    public String? Name{get;set;}
    public int level {get; set;}
    
    public int AcademicYearId {get; set;}
    public AcademicYear? AcademicYear {get; set;}

    public ICollection<Students> Students {get; set;} = [];
    
}