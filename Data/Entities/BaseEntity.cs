using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities
{
    public abstract class BaseEntity
    {
        public DateTime DateCreated { get; set; }

        public DateTime? DateDeleted { get; set; }

        [Required]
        public string Id { get; set; }

        public virtual bool Validate()
        {
            if (string.IsNullOrEmpty(Id))
            {
                return false;
            }

            if (DateCreated == new DateTime())
            {
                return false;
            }

            return true;
        }
    }
}
