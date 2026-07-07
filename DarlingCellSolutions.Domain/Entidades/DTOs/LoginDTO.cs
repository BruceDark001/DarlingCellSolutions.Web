using System.ComponentModel.DataAnnotations;

namespace DarlingCellSolutions.Domain.DTOs;

public class LoginDTO
{
    [Required]
    public string Usuario { get; set; } = "";

    [Required]
    public string Password { get; set; } = "";
}