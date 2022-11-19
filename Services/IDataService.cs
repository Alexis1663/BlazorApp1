﻿using BlazorApp.Models;

namespace BlazorApp.Services
{
    public interface IDataService
    {
        Task Add(ItemModel model);

        Task<int> Count();

        Task<List<Item>> List(int currentPage, int pageSize);
    }
}