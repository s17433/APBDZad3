using APBD_03.Model;
using APBD_03.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_03.Controlers;

[Route("api/[controller]")]
[ApiController]
public class AnimalController : ControllerBase
{
    private IAnimalService _animalService;

    public AnimalController(IAnimalService animalService)
    {
        _animalService = animalService;
    }
    
    /// <summary>
    /// Endpoints used to return list of animals.
    /// </summary>
    /// <returns>List of animals</returns>
    [HttpGet]
    public IActionResult GetAnimals()
    {
        var animals = _animalService.GetAnimals();
        return Ok(animals);
    }
    
    /// <summary>
    /// Endpoint used to return a single animal.
    /// </summary>
    /// <param name="id">Id of a animal</param>
    /// <returns>Animal</returns>
    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = _animalService.GetAnimal(id);

        if (animal==null)
        {
            return NotFound("Animal not found");
        }
        
        return Ok(animal);
    }
    
    /// <summary>
    /// Endpoint used to create a animal.
    /// </summary>
    /// <param name="animal">New animal data</param>
    /// <returns>201 Created</returns>
    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        var affectedCount = _animalService.CreateAnimal(animal);
        return StatusCode(StatusCodes.Status201Created);
    }
    
    /// <summary>
    /// Endpoint used to update a animal.
    /// </summary>
    /// <param name="id">Id of a animal</param>
    /// <param name="animal">204 No Content</param>
    /// <returns></returns>
    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var affectedCount = _animalService.UpdateAnimal(animal);
        return NoContent();
    }
    
    /// <summary>
    /// Endpoint used to delete a animal.
    /// </summary>
    /// <param name="id">Id of a animal</param>
    /// <returns>204 No Content</returns>
    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var affectedCount = _animalService.DeleteAnimal(id);
        return NoContent();
    }
}