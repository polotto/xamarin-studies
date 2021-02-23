using System;
using System.Linq;
using todo;
using Xunit;

namespace Todo.Tests
{
    public class TodoViewModelTests
    {
        [Fact]
        public void ViewModel_populates_items_correctly()
        {
            TodoViewModel viewModel = new TodoViewModel();

            Assert.Equal(5, viewModel.Items.Count);
        }

        [Fact]
        public void AddItemCommand_adds_new_item_to_the_list()
        {
            TodoViewModel viewModel = new TodoViewModel();

            viewModel.AddItemCommand.Execute(null);

            Assert.Equal(6, viewModel.Items.Count);
            Assert.Equal("Todo Item 6", viewModel.Items.Last().Name);
        }

        [Fact]
        public void MarkAsCompletedCommand_marks_item_as_completed_and_puts_it_at_the_end_of_the_list()
        {
            TodoViewModel viewModel = new TodoViewModel();

            viewModel.MarkAsCompletedCommand.Execute(viewModel.Items.First());

            Assert.True(viewModel.Items.Last().Completed);
        }

        [Fact]
        public void MasrkAsCompletedCommand_updates_progress()
        {
            TodoViewModel viewModel = new TodoViewModel();

            viewModel.MarkAsCompletedCommand.Execute(viewModel.Items.First());

            Assert.Equal("Completed 1/5", viewModel.CompletedHeader);
            Assert.Equal(0.2, viewModel.CompletedProgress);
        }
    }
}
