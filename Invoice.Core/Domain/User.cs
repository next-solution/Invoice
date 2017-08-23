using System;
using System.Text.RegularExpressions;

namespace Invoice.Core.Domain
{
    public class User
    {
        private static readonly Regex NameRegex = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");
        public Guid Id { get; protected set; }
        public string Username { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string FullName { get; protected set; }
        public string Email { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
    
        protected User()
        {
        }

        public User(string username, string password, string salt, 
                    string fullName, string optEmail = null)
        {
			if (!NameRegex.IsMatch(username))
			{
				throw new Exception("Username is invalid.");
			}

            CheckPassword(password);

            Id = Guid.NewGuid();
            Username = username;
            Password = password;
            Salt = salt;
            FullName = fullName;
            Email = optEmail;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetUsername(string username) 
        {
            if(!NameRegex.IsMatch(username))
            {
                throw new Exception("Username is invalid.");
            }

            Username = Update(Username, username);
        }

        public void SetPassword(string password)
        {
            CheckPassword(password);
            Password = Update(Password, password);
        }

        public void SetFullName(string fullName)
        {
            FullName = Update(FullName, fullName);
        }

		public void SetEmail(string email)
		{
			if (string.IsNullOrWhiteSpace(email))
			{
				throw new Exception("Email can not be empty.");
			}

            Email = Update(Email, email);
		}

        private void CheckPassword(string password)
        {
			if (string.IsNullOrWhiteSpace(password))
			{
				throw new Exception("Password can not be empty.");
			}
			if (password.Length < 8)
			{
				throw new Exception("Password must contain at least 8 characters.");
			}
			if (password.Length > 100)
			{
				throw new Exception("Password can not contain more than 30 characters.");
			}
        }
		
        private T Update<T>(T newValue, T oldValue)
		{
			if (oldValue.Equals(newValue))
			{
				return oldValue;
			}
			UpdatedAt = DateTime.UtcNow;
			return newValue;
		}
    }
}