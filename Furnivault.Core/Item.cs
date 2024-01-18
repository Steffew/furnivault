using System.Text.RegularExpressions;

namespace Furnivault.Core.Entities
{
    public class Item
    {
        public int ItemId { get; private set; }
        public string Name { get; private set; }
        public string Identifier { get; private set; }
        public bool Favorite { get; private set; }
        public string Description { get; private set; }
        public int GroupId { get; private set; }

        public Item(string name, string identifier, string description, bool favorite = false)
        {
            ValidateProperty(name, nameof(Name));
            ValidateProperty(identifier, nameof(Identifier));
            ValidateProperty(description, nameof(Description));

            Name = name;
            Identifier = identifier;
            Description = description;
            Favorite = favorite;
        }

        private void ValidateProperty(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{propertyName} cannot be empty or whitespace.", propertyName);
            }
        }

        public void Update(string name, string identifier, string description)
        {
            ValidateProperty(name, nameof(Name));
            ValidateProperty(identifier, nameof(Identifier));
            ValidateProperty(description, nameof(Description));

            Name = name;
            Identifier = identifier;
            Description = description;
        }

        public void ToggleFavorite()
        {
            Favorite = !Favorite;
        }

        public void SetItemId(int id)
        {
            ItemId = id;
        }
        public void SetGroupId(int groupId)
        {
            GroupId = groupId;
        }
    }
}