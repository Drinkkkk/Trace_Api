using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Trace_Api.Dto
{
    public class UserDto:BaseDto
    {
        private int userid;

        public int UserID
        {
            get { return userid; }
            set { userid = value; OnPropertyChanged(); }
        }

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged(); }
        }

        
        private string password;
        
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(); }
        }

        private string? fullname;

        public string? FullName
        {
            get { return fullname; }
            set { fullname = value; OnPropertyChanged(); }
        }
        private string? phone;

        public string? Phone
        {
            get { return phone; }
            set { phone = value; OnPropertyChanged(); }
        }

        private string? role;

        public string? Role
        {
            get { return role; }
            set { role = value; OnPropertyChanged(); }
        }
        private byte[]? avatardata;

        public byte[]? AvatarData
        {
            get { return avatardata; }
            set { avatardata = value; OnPropertyChanged(); }
        }

    }
}
