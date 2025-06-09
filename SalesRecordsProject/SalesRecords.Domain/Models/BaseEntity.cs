using System;
using System.ComponentModel.DataAnnotations;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? ModifiedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; set; } = false;
}