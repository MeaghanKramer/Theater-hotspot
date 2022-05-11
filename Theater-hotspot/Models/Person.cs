using System.ComponentModel.DataAnnotations;

namespace Theater_hotspot.Models
{
    public class Person
    {
      [Required(ErrorMessage = "Het invullen van uw voornaam is verplicht")]
      public string Voornaam { get; set; }
      [Required(ErrorMessage = "Het invullen van uw achternaam is verplicht")]
      public string Achternaam { get; set; }
      [EmailAddress(ErrorMessage = "Het invullen van uw email is verplicht")]
      public string Email { get; set; }
      public string Telefoon { get; set; }
      public string Adres { get; set; }
      [Required(ErrorMessage = "Vul gelieve hier uw probleem in")]
      public string Beschrijving { get; set; }
    }
}
