namespace PalindromeMVC.Models
{
    public class Palindrome
    {
        public string InputWord { get; set; }
        public string RevWord { get; set; }
        public bool IsPalindrome { get; set; }
        public string Message { get; set; }

        // return a css class parameter
        public string GetPaliMessClass()
        {
            return IsPalindrome ? "text-success" : "text-danger";
        }
    }
}
