using System.ComponentModel.DataAnnotations;

namespace IoTManager.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}