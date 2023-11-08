using System.ComponentModel.DataAnnotations;

namespace Assessment.Console.Options
{
    public class WriterOptions
    {
        [Required, MinLength(1)]
        public string FileName { get; set; } = null!;

        public string? DateFormat { get; set; } = "yyyy-MM-dd hh-mm-ss";

        [Required]
        [RegularExpression(@"^\.[^. ]+$")]
        public string Extension { get; set; } = null!;
    }
}