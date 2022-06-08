using DragonBallHeroes.Connections;
using DragonBallHeroes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBallHeroes.Services
{
    public class HeroService
    {
        public async Task<List<Hero>> GetAll()
        {
            var result = await FirebaseConnection.firebase
                .Child("heroes")
                .OnceAsync<Hero>();

            return result.Select(x => new Hero
            {
                Icon = x.Object.Icon
            }).ToList();
        }
    }
}
