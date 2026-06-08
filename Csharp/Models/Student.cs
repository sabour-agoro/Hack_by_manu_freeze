namespace Csharp.Models;
public enum Gender
{
    Feminin,
    Masculin
}
public class Students
{
    public int Id {get; set;}
    public String? FirstName { get; set;}
    public String? LastName {get; set;}
    public DateTime BirthDate {get; set;}
    public Gender gender {get; set;}

    public int ClasseId {get; set;}
    public Classe? classe {get; set;}

}