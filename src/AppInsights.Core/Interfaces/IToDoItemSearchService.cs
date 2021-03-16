﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Result;
using AppInsights.Core.Entities;

namespace AppInsights.Core.Interfaces
{
    public interface IToDoItemSearchService
    {
        Task<Result<ToDoItem>> GetNextIncompleteItemAsync();
        Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(string searchString);
    }
}
