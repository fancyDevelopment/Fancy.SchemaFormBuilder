using Fancy.SchemaFormBuilder.Annotations;

public class Comment1Dto
{
    public int Id { get; set; }

    [FormTitle("FirstName")]
    public string FirstName { get; set; }
    
    [FormTitle("LastName")]
    public string LastName { get; set; }
    
    [FormTitle("E-Mail")]
    public string EMail { get; set; }
    
    [FormTitle("Comment")]
    public string Comment { get; set; }
}