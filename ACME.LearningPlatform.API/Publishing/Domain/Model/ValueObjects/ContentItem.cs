namespace ACME.LearningPlatform.API.Publishing.Domain.Model.ValueObjects;

public record ContentItem
{
    public ContentItem(string type, string content)
    {
        Type = type;
        Content = content;
    }
    
    public string Type { get; set; }
    public string Content { get; set; }
}