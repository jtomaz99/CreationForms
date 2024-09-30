using Microsoft.AspNetCore.Mvc;

namespace CreationForms.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetAllHeroes();
        Task<SuperHero?> GetSingleHero(int id);
        Task<List<SuperHero>> AddHero(SuperHero newHero);
        Task<List<SuperHero>?> UpdateHero(int id, SuperHero newHero);
        Task<List<SuperHero>?> DeleteHero(int id);
    }
}
