using System;
using System.ComponentModel.DataAnnotations;

namespace Asker.Models
{
    public partial class BaseModel
    {
        public BaseModel() { Id = Guid.NewGuid(); CreatedDate = DateTime.Now; }

        [Key]
        [ScaffoldColumn(false)]
        public Guid Id { get; private set; }

        [Required]
        [ScaffoldColumn(false)]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; private set; }
    }
}
