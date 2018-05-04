using iTest.Data.Models.Abstract;
using System.ComponentModel.DataAnnotations;

namespace iTest.Data.Models
{
    public class Result : DataModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}