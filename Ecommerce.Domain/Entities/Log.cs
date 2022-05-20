using System.ComponentModel.DataAnnotations;

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
        public DateTime CreatedAt { get; set; }
    }
}
