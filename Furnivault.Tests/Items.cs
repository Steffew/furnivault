namespace Furnivault.Tests
{
    public class Items
    {
        [Fact]
        public void Get_all_items()
        {
            MockRepository mockRepository = new MockRepository();
            ItemCollection itemService = new ItemCollection(mockRepository);

            IEnumerable<Item> items = itemService.GetAll();

            Assert.IsType<List<Item>>(items);
        }

        [Fact]
        public void Get_item_by_id()
        {
            MockRepository mockRepository = new MockRepository();
            ItemCollection itemService = new ItemCollection(mockRepository);

            Item item = itemService.GetById(1);

            Assert.Equal("1", item.Identifier);
        }

        [Fact]
        public void Add_item()
        {
            MockRepository mockRepository = new MockRepository();
            ItemCollection itemService = new ItemCollection(mockRepository);

            Item item = itemService.Add("Item", "1", "Description");

            Assert.Equal("Item", item.Name);
            Assert.Equal("1", item.Identifier);
            Assert.Equal("Description", item.Description);
        }

        [Fact]
        public void Update_item()
        {
            MockRepository mockRepository = new MockRepository();
            ItemCollection itemService = new ItemCollection(mockRepository);

            itemService.Update(1, "newItem", "newIdentifier", "newDescription");

            Assert.Equal("newItem", mockRepository.Name);
            Assert.Equal("newIdentifier", mockRepository.Identifier);
            Assert.Equal("newDescription", mockRepository.Description);
        }
    }
}