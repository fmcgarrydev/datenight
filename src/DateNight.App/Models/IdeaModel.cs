using System.ComponentModel.DataAnnotations;

namespace DateNight.App.Models;

public class IdeaModel
{
    public DateTime CreatedOn { get; set; }

    public string Description { get; set; }
    public string Id { get; set; }

    [Required]
    public string Title { get; set; }
}