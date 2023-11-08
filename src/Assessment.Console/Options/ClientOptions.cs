using System.ComponentModel.DataAnnotations;

namespace Assessment.Console.Options
{
    public class ClientOptions
    {
        [Required]
        [MinLength(7)]
        public string BaseUrl { get; set; } = null!;
    }
}