using System.ComponentModel.DataAnnotations;

namespace Zadanie_6.Models
{
    public class Animal
    {
        public int IdAnimal { get; set; }
        [Required(ErrorMessage = "ID zwierzęcia jest wymagane")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        public string Description { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage = "Kategoria jest wymagana")]
        public string Area { get; set; }

    }
}
