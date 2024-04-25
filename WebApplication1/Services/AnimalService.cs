using WebApplication1.Model;
using WebApplication1.Repositories;

namespace WebApplication1.Services;

public class AnimalService : IAnimalService
{
    private readonly IAnimalRepository _animalRepository;
    
    public AnimalService(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }
    
    public IEnumerable<Animal> GetAnimals()
    {
        //Business logic
        return _animalRepository.GetAnimals();
    }
    
    public int CreateAnimal(Animal animal)
    {
        //Business logic
        return _animalRepository.CreateAnimal(animal);
    }

    public Animal? GetAnimal(int idAnimal)
    {
        //Business logic
        return _animalRepository.GetAnimal(idAnimal);
    }

    public int UpdateAnimal(Animal animal)
    {
        //Business logic
        return _animalRepository.UpdateAnimal(animal);
    }

    public int DeleteAnimal(int idAnimal)
    {
        //Business logic
        return _animalRepository.DeleteAnimal(idAnimal);
    }
}