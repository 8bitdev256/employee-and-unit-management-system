using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace employee_and_unit_management_system.Models;

[PrimaryKey(nameof(Id))]
public class Unit
{
    public override string ToString()
    {
        return this.Id + " - " + this.Name;
    }

    public int Id { get; set; }

    public required string Name { get; set; }

    public bool Status { get; set; }
    
    public ICollection<Collaborator> Collaborators { get; } = [];
}