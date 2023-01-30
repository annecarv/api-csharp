using System.ComponentModel.DataAnnotations;

namespace Dws.Note_one.Api.Resource
{
    public class DeleteStoreResource
    {

        [Required]
        [MaxLength(30)]
        public string Id { get; set; }

    }
}