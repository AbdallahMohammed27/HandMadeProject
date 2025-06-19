using Microsoft.AspNetCore.Identity;

namespace HandMadeEcommece.helper
{
    public class AppUser : IdentityUser<int>
    {
        public byte[]? Image { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public override string UserName { get => base.UserName ; set => base.UserName = value; }
    }
}
