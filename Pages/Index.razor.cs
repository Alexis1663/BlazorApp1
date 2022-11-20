using BlazorApp.Components;
using BlazorApp.Models;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Pages
{
    public partial class Index
    {

        [Inject]
        public IDataService DataService { get; set; }

        public List<Item> Items { get; set; } = new List<Item>();

        private List<CraftingRecipe> Recipes { get; set; } = new List<CraftingRecipe>();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Items = await DataService.List(0, await DataService.Count());
            Recipes = await DataService.GetRecipes();
        }

        private Cake CakeItem = new Cake
        {
            Id = 1,
            Name = "Black Forest",
            Cost = 50
        };

        public List<Cake> Cakes { get; set; }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            LoadCakes();
            StateHasChanged();
            return base.OnAfterRenderAsync(firstRender);
        }

        public void LoadCakes()
        {
            Cakes = new List<Cake>
            {
                // items hidden for display purpose

                new Cake
                {
                    Id = 1,
                    Name = "Black Forest",
                    Cost = 50
                },
            new Cake
                {
                    Id = 2,
                    Name = "Red Velvet",
                    Cost = 60
                },

                new Cake
                {
                    Id = 3,
                    Name = "Rich Fruit Cake",
                    Cost = 70
                }
            };
        }
    }
}
