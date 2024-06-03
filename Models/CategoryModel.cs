using System.ComponentModel.DataAnnotations;

namespace wepAppPractice.Models
{
    public class CategoryModel
    {

        [Key]

        [Required]

        [Display(Name = "provide your Name")]
        public string Name { get; set; }
        [Required(ErrorMessage="vara na yaar")]
        [Display(Name="provide your description")]
        [StringLength(5,MinimumLength =3,ErrorMessage ="lol jamma 3 ni type garna parena")]
        public string Description { get; set; }
        
    }
}
