namespace Furnivault.Core.Entities
{
    public class Item
    {
        public int ItemId { get; private set; }
        public string Name { get; private set; }
        public string Identifier { get; private set; }
        public bool Favorite { get; private set; }
        public string Description { get; private set; }

        public Item(string name, string identifier, string description)
        {
            SetProperties(name, identifier, description);
        }

        public void UpdateItem(string name, string identifier, string description)
        {
            SetProperties(name, identifier, description);
        }

        private void SetProperties(string name, string identifier, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty!", nameof(name));

            if (string.IsNullOrWhiteSpace(identifier))
                throw new ArgumentException("Identifier cannot be empty!", nameof(identifier));

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be empty!", nameof(description));

            Name = name;
            Identifier = identifier;
            Description = description;
        }

        public void ToggleFavorite()
        {
            Favorite = !Favorite;
        }
    }
}
