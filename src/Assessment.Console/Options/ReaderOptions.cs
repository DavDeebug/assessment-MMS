using System.ComponentModel.DataAnnotations;

namespace Assessment.Console.Options
{
    public class ReaderOptions
    {
        [Required, MinLength(1)]
        public string Separator { get; set; } = null!;
        
        [Required, MinLength(1)]
        public string FileName { get; set; } = null!;

        [Required]
        [RegularExpression(@"^\.[^. ]+$")]
        public string Extension { get; set; } = null!;
    }
}