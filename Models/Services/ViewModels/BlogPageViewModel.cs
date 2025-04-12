using DogusProject.Models.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DogusProject.Models.Services.ViewModels;

public class BlogPageViewModel
{

        public List<BlogViewModel> BlogList { get; set; } = null!;
        public List<SelectListItem> CategoryList { get; set; }= null!;
        
        public int? CategoryId { get; set; }
    

}