using System.ComponentModel.DataAnnotations;

public class CreateAcademyDto
{
    public String? Name{get; set;}
    public DateTime StartDate {get; set;}
    public DateTime EndDate {get; set;}
    public bool IsActive{get; set;}
}