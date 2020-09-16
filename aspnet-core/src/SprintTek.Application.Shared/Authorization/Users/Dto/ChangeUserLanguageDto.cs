using System.ComponentModel.DataAnnotations;

namespace SprintTek.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
