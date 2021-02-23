using System;
using Xunit;
using todo;
using Xamarin.Forms;

namespace Todo.Tests
{
    public class BoolToTextDecorationConverterTests
    {
        [Fact]
        public void Convert_returns_strikethrough_when_item_is_completed()
        {
            // arrange
            var converter = new BoolToTextDecorationConverter();

            // act
            var result = converter.Convert(true, null, null, null);

            // assert
            Assert.Equal(TextDecorations.Strikethrough, (TextDecorations)result);
        }

        [Fact]
        public void Convert_returns_none_when_item_is_not_completed()
        {
            // arrange
            var converter = new BoolToTextDecorationConverter();

            // act
            var result = converter.Convert(false, null, null, null);

            // assert
            Assert.Equal(TextDecorations.None, (TextDecorations)result);
        }
    }
}
