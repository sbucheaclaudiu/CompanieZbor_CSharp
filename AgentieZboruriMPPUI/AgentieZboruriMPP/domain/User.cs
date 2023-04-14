namespace AgentieZboruriMPP.domain
{
    public class User : Entity<string>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string username, string password) : base(username)
        {
            this.Username = username;
            this.Password = password;
        }

        public override string ToString()
        {
            return "User{" +
                   "username='" + Username + '\'' +
                   ", password='" + Password + '\'' +
                   '}';
        }
    }
}