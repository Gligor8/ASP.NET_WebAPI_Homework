using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIWorkshop_MovieApp.Models;

namespace WebAPIWorkshop_MovieApp
{
    public static class StaticDB
    {
        public static List<Movie> Movies = new List<Movie>()
        {
            new Movie {Title = "Paths of Glory", Description = "Paths of Glory is a 1957 American anti-war film co-written and directed by Stanley Kubrick, based on the novel of the same name by Humphrey Cobb.", Year = 1957, Genre = Models.Enums.Genre.War},
            new Movie {Title = "Career Opportnuties", Description = "Career Opportunities is a 1991 American romantic comedy film starring Frank Whaley in his first lead role and co-starring Jennifer Connelly. It was written and co-produced by John Hughes and directed by Bryan Gordon.", Year = 1991, Genre = Models.Enums.Genre.Romance},
            new Movie {Title = "Starter For 10", Description = "tarter for 10 is a 2006 British comedy-drama film directed by Tom Vaughan from a screenplay by David Nicholls, adapted from his 2003 novel Starter for Ten.", Year = 2006, Genre = Models.Enums.Genre.Comedy},

        };
    }
}
