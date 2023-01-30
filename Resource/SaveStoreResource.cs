using System.ComponentModel.DataAnnotations;

namespace Dws.Note_one.Api.Resource
{
    public class SaveStoreResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

         [Required]
        [MaxLength(30)]
        public string TaxId { get; set; }

    }
}