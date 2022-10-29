using BlazorApp.Models;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorApp.Pages
{
    public partial class Add
    {
        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        /// <summary>
        /// The default roles.
        /// </summary>
        private List<string> roles = new List<string>() { "admin", "writter", "reader", "member" };

        /// <summary>
        /// The current data model
        /// </summary>
        private DataModel dataModel = new()
        {
            DateOfBirth = DateTime.Now,
            Roles = new List<string>()
        };

        private async void HandleValidSubmit()
        {
            // Get the current data
            var currentData = await LocalStorage.GetItemAsync<List<Data>>("data");

            // Simulate the Id
            dataModel.Id = currentData.Max(s => s.Id) + 1;

            // Add the item to the current data
            currentData.Add(new Data
            {
                LastName = dataModel.LastName,
                DateOfBirth = dataModel.DateOfBirth,
                FirstName = dataModel.FirstName,
                Id = dataModel.Id,
                Roles = dataModel.Roles
            });

            // Save the data
            await LocalStorage.SetItemAsync("data", currentData);

            NavigationManager.NavigateTo("list");
        }

        private void OnRoleChange(string item, object checkedValue)
        {
            if ((bool)checkedValue)
            {
                if (!dataModel.Roles.Contains(item))
                {
                    dataModel.Roles.Add(item);
                }

                return;
            }

            if (dataModel.Roles.Contains(item))
            {
                dataModel.Roles.Remove(item);
            }
        }
    }
}
