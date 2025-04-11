using System.ComponentModel.DataAnnotations;

namespace MyWebApi.Models
{
    public class Project
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        [Required]
        public DateOnly StartDate { get; set; }

        [Required]
        public DateOnly EndDate { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string CityImage { get; set; }

        [Required]
        public string HouseImage { get; set; }

        public bool IsResidential { get; set; }
    }
}
