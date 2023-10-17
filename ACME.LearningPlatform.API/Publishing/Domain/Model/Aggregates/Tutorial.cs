namespace ACME.LearningPlatform.API.Publishing.Domain.Model.Aggregates;

public partial class Tutorial
{

    public int Id { get; set; }
    public string Title { get; set; }
    public string Summary { get; private set; }
    
    public Tutorial(string title, string summary):this()
    {
        Title = title;
        Summary = summary;
    }
    
}