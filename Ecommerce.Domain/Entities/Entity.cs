﻿using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entities
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
