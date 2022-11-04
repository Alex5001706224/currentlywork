using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingWeb.Models
{
    public class AllLetters:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if(value != null)
            {
                return ((string)value).All(char.IsLetter);
            }
            return false;
        }
    }
}
