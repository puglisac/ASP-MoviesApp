using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.Models;

namespace MoviesApp.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly MoviesApp.Data.MoviesAppContext _context;

        public IndexModel(MoviesApp.Data.MoviesAppContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }


        //Insert the following code to add search string to your model
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        
            


        public async Task OnGetAsync()
        {

            //Movie = await _context.Movie.ToListAsync();

            //Insert the following code to enable database serach for search string
            var movies = from m in _context.Movie
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            Movie = await movies.ToListAsync();


        }
    }
}
