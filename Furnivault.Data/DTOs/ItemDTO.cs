namespace Furnivault.Data.DTOs
{
    public class ItemDTO
    {
        public string Name { get; set; }
        public int ItemId { get; set; }
        public string Identifier { get; set; }
        public bool Favorite { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
    }
}