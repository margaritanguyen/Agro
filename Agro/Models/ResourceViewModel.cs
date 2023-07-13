using Agro.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Agro.Models
{
    public class ResourceViewModel
    {
        public int Id { get; set; }

        [Required]
        public int Code { get; set; }

        [Required]
        [MaxLength(64)]
        [Unicode]
        public string Name { get; set; }

        [Required]
        [MaxLength(32)]
        [Unicode]
        public string ShortName { get; set; }

        [Required]
        public float TechTolerance { get; set; }

        [Required]
        public float RejectTolerance { get; set; }

        [Required]
        public float AlertTolerance { get; set; }

        [Required]
        public float Density { get; set; }

        [Required]
        public float Activity { get; set; }

        public ResourceType? ResourceType { get; set; }
        public int? ResourceTypeId { get; set; }

        public DosingType? DosingType { get; set; }
        public int DosingTypeId { get; set; }

        [MaxLength(64)]
        public string? Comment { get; set; }

        [Required]
        public DateTime LastChange { get; set; }
    }
}