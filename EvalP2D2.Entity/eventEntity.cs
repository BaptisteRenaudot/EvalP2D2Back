namespace EvalP2D2.Entity;

/// <summary>
/// Represents an event entity.
/// </summary>
public class eventEntity
{
    /// <summary>
    /// Gets or sets the unique identifier for the event entity.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets or sets the title of the event.
    /// </summary>
    public string Title { get; set; }
    
    /// <summary>
    /// Gets or sets the description of the event.
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Gets or sets the date and the time of the event.
    /// </summary>
    public DateTime DateTime { get; set; }
    
    /// <summary>
    /// Gets or sets the location of the event.
    /// </summary>
    public string Location { get; set; }
}