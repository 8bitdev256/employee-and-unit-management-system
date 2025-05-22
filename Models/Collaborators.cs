using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace employee_and_unit_management_system.Models;

public class Collaborator
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public int UnitId { get; set; }

    public Unit? Unit { get; set; }
}