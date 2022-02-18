using Microsoft.AspNetCore.Mvc;

namespace FruitsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsController : ControllerBase
    {

        private readonly DataContext _context;

        public FruitsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Fruit>>> Get()
        {
            return Ok(await _context.Fruits.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Fruit>>> addFruit(Fruit fruit)
        {
            _context.Fruits.Add(fruit);
            await _context.SaveChangesAsync();
            return Ok(await _context.Fruits.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Fruit>> Get(int id)
        {
            // search for the fruit with the id past as a parameter
            var dbFruit = await _context.Fruits.FindAsync(id);
            // if fruit is null send a 404 fruit not found
            if (dbFruit == null)
                return NotFound("Fruit not found");
            // if fruit is found send the fruit
            return Ok(dbFruit);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Fruit>> updateFruit(Fruit fruit,int id)
        {
            // search for the fruit with the id past as a parameter
            var dbFruit = await _context.Fruits.FindAsync(id);

            // if fruit is null send a 404 fruit not found
            if (dbFruit == null)
                return NotFound("Fruit not found");

            // update the fruit
            dbFruit.Name = fruit.Name;
            dbFruit.Rating = fruit.Rating;
            dbFruit.Review = fruit.Review;

            // Save changes to db
            await _context.SaveChangesAsync();

            // if fruit is found send the fruit
            return Ok(dbFruit);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Fruit>>> Delete(int id)
        {
            // Find the db to delete
            var dbFruitToDelete = await _context.Fruits.FindAsync(id);

            // if fruit is null send a 404 fruit not found
            if (dbFruitToDelete == null)
                return NotFound("Fruit not found");

            // if fruit is in the list remove it
            _context.Fruits.Remove(dbFruitToDelete);

            // save the changes to db
            await _context.SaveChangesAsync();

            // return the fruits list without the removed fruit
            return Ok(await _context.Fruits.ToListAsync());
        }

    }
}
