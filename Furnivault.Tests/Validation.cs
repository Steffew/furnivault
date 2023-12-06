namespace Furnivault.Tests
{
    public class Validation
    {
        [Fact]
        public void Validate_too_short_string()
        {
            ItemValidator itemValidator = new ItemValidator();

            Assert.Throws<ArgumentException>(() => itemValidator.ValidateString("test", "test", 5, 10));
        }

        [Fact]
        public void Validate_too_long_string()
        {
            ItemValidator itemValidator = new ItemValidator();

            Assert.Throws<ArgumentException>(() => itemValidator.ValidateString("test", "test", 1, 3));
        }

        [Fact]
        public void Validate_null_string()
        {
            ItemValidator itemValidator = new ItemValidator();

            Assert.Throws<ArgumentException>(() => itemValidator.ValidateString("test", null, 1, 3));
        }

        [Fact]
        public void Validate_whitespace_string()
        {
            ItemValidator itemValidator = new ItemValidator();

            Assert.Throws<ArgumentException>(() => itemValidator.ValidateString("test", " ", 1, 3));
        }
    }
}