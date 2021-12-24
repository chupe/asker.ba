using System;
using System.ComponentModel.DataAnnotations;

namespace AskerTracker.Core.BaseModels
{
    public partial class EntityModel
    {
        public EntityModel() { 
            Id = Guid.NewGuid(); 
            CreatedDate = DateTime.Now;
        }

        [Key]
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; private set; }
    }
}
