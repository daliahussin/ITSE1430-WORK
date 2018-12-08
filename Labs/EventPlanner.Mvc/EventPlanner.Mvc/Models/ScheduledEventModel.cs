/* ITSE 1430
 * Dalia Hussin
 * 12/8/2018
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventPlanner.Mvc.Models
{
    public class ScheduledEventModel
    {
        [Range(0, Int32.MaxValue)]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public string Description { get; set; }

        [DisplayName("Is Public")]
        public bool IsPublic { get; set; }

        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndDate < StartDate)
            {
                if (EndDate < StartDate)
                    yield return new ValidationResult("End date must be greater than or equal to start date.", new[] { nameof(EndDate) });
            }
        }
    }
}