using AutoMapper;
using Exercise.AutoMapper.Dtos;
using Exercise.AutoMapper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exercise.AutoMapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        public static List<SuperHero> heroes = new List<SuperHero>
        {
            new SuperHero
            {
                Id = 1,
                Name = "Spider Man",
                FirstName = "Peter",
                LastName = "Parker",
                Place = "New York",
                DateAdded = new DateTime(2001, 08, 10),
                DataModified = null
            },
             new SuperHero
            {
                Id = 2,
                Name = "Iron Man",
                FirstName = "Tony",
                LastName = "Stark",
                Place = "Malibu",
                DateAdded = new DateTime(1970, 05, 29),
                DataModified = null
            },

        };
        private readonly IMapper _mapper;

        public SuperHeroController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<SuperHero>> GetHeroes()
        {
            return Ok(heroes.Select(x => _mapper.Map<GetSuperHeros>(x)).ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<SuperHero> GetHeroById(int id)
        {
            var hero = heroes.FirstOrDefault(x => x.Id == id);
            if (hero is null)
                return NotFound("Hero not found");

            _mapper.Map<GetSuperHeros>(hero);

            return Ok(hero);
        }

        [HttpPost]
        public ActionResult<List<SuperHero>> AddSuperHero(AddSuperHero newSuperHero) 
        {
            var hero = _mapper.Map<SuperHero>(newSuperHero);
            hero.Id = heroes.Max(c => c.Id) + 1;
            heroes.Add(hero);

            return Ok(heroes.Select(x => _mapper.Map<GetSuperHeros>(x)).ToList());
        }
        [HttpPut]
        public ActionResult<List<SuperHero>> UpdateSuperHeroes(UpdateSuperHeroes updateSuperHeroes)
        {
            var hero = heroes.Find(x => x.Id == updateSuperHeroes.Id);
            if (hero is null)
                return NotFound("Hero not found");

            _mapper.Map(updateSuperHeroes, hero);

            return Ok(heroes.Select(x => _mapper.Map<GetSuperHeros>(x)).ToList());
        }
    }
}
