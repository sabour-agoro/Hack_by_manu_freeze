using System.ComponentModel.DataAnnotations;

using Csharp.Models;

public class ReadStudentDto
{
    
     public String? FirstName { get; set;}
    public String? LastName {get; set;}
    public DateTime BirthDate {get; set;}
    public Gender gender {get; set;}
}