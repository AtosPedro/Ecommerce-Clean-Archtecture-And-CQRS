using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Entities
{
    public class Log 
    {
        [Required]
        public Guid Id { get; set; }
        public Guid RequestId { get; set; }
        public Guid? ResponseId { get; set; }        
        [Required]
        public string Type { get; set; }        
        [Required]
        public string Message { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        public object Data { get; set; }
    }
}
