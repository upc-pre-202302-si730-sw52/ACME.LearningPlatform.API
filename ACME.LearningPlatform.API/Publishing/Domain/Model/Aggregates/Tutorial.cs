using ACME.LearningPlatform.API.Publishing.Domain.Model.Entities;

namespace ACME.LearningPlatform.API.Publishing.Domain.Model.Aggregates;

public partial class Tutorial
{
    public Tutorial(string title, string summary, int categoryId) : this()
    {
        Title = title;
        Summary = summary;
        CategoryId = categoryId;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Summary { get; private set; }

    public Category Category { get; }
    public int CategoryId { get; private set; }
}