using InventoryManagementSystem.Models.Common;
using InventoryManagementSystem.Models.Contracts;
using InventoryManagementSystem.Models.Enums;

namespace InventoryManagementSystem.Models
{
    public class User : IUser
    {
        private string username;
        private string firstName;
        private string lastName;
        private string password;

        private readonly IList<IInventory> inventory = new List<IInventory>();
        public User(string username, string firstName, string lastName, string password, Role role) 
        { 
            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Role = role;
        }

        public IList<IInventory> Inventory { get => new List<IInventory>(this.inventory); }

        public string Username 
        { 
            get => this.username; 
            private set 
            { 
                ValidateUsername(value); 
                this.username = value; 
            } 
        }

        public string FirstName
        {
            get => firstName;
            private set
            {
                ValidateFirstName(value);
                this.firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;
            private set
            {
                ValidateLastName(value);
                this.lastName = value;
            }
        }

        public string Password 
        { 
            get => this.password;
            private set
            {
                Validate.ValidatePassword(value);
                this.password = value;
            }
        }

        public Role Role { get; }

        public void AddInventory(IInventory inventory)
        {
            this.inventory.Add(inventory);
        }

        public void RemoveInventory(IInventory inventory)
        {
            this.inventory.Remove(inventory);
        }

        public void SetPassword(string newPassword)
        {
            Validate.ValidatePassword(newPassword);

            this.Password = newPassword;
        }

        public void SetUsername(string newUsername)
        {
            ValidateUsername(newUsername);

            this.Username = newUsername;
        }

        private void ValidateUsername(string name)
        {
            var message = $"{GetType().Name} {Constants.NullOrEmptyMessage}";
            Validate.ValidateNotNullOrEmpty(name, message);

            var min = Constants.UserMinLength;
            var max = Constants.UserMaxLength;
            message = Constants.InvalidUsernameError;
            Validate.ValidateLengthRange(name, min, max, message);
        }

        private void ValidateFirstName(string firstName)
        {
            var message = $"{GetType().Name} {Constants.NullOrEmptyMessage}";
            Validate.ValidateNotNullOrEmpty(firstName, message);

            var min = Constants.FirstNameMinLength;
            var max = Constants.FirstNameMaxLength;
            message = Constants.InvalidFirstNameError;
            Validate.ValidateLengthRange(firstName, min, max, message);
        }

        private void ValidateLastName(string lastName)
        {
            var message = $"{GetType().Name} {Constants.NullOrEmptyMessage}";
            Validate.ValidateNotNullOrEmpty(lastName, message);

            var min = Constants.LastNameMinLength;
            var max = Constants.LastNameMaxLength;
            message = Constants.InvalidLastNameError;
            Validate.ValidateLengthRange(lastName, min, max, message);
        }
    }
}
