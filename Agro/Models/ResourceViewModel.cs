using Agro.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Agro.Models
{
    public class ResourceViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "������������ ����.")]
        public int Code { get; set; }

        [Required(ErrorMessage = "������������ ����.")]
        [MaxLength(64)]
        [Unicode]
        public string Name { get; set; }

        [Required(ErrorMessage = "������������ ����.")]
        [MaxLength(32)]
        [Unicode]
        public string ShortName { get; set; }

        [Required(ErrorMessage = "������������ ����.")]
        public float TechTolerance { get; set; }

        [Required(ErrorMessage = "������������ ����.")]
        public float RejectTolerance { get; set; }

        [Required(ErrorMessage = "������������ ����.")]
        public float AlertTolerance { get; set; }

        [Required(ErrorMessage = "������������ ����.")]
        public float Density { get; set; }

        [Required(ErrorMessage = "������������ ����.")]
        public float Activity { get; set; }

        public ResourceType? ResourceType { get; set; }
        public int? ResourceTypeId { get; set; }

        public DosingType? DosingType { get; set; }
        public int DosingTypeId { get; set; }

        [MaxLength(64)]
        public string? Comment { get; set; }

        [Required(ErrorMessage = "������������ ����.")]
        public DateTime LastChange { get; set; }
    }
}