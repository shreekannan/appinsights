﻿using System.ComponentModel.DataAnnotations;

namespace AppInsights.Web.Endpoints.ToDoItems
{
    public class NewToDoItemRequest
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}