using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models;

public class TaskItem
{
    public int Id { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Title { get; set; }
    public string Description { set; get; }
    public bool IsCompleted { set; get; }
    public DateTime CreatedAt { set; get; }


    public TaskItem()
    {
        CreatedAt = DateTime.UtcNow;
        IsCompleted = false;
    }
}