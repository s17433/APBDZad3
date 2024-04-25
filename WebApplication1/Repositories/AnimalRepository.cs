using Microsoft.Data.SqlClient;
using WebApplication1.Model;

namespace WebApplication1.Repositories;

public class AnimalRepository : IAnimalRepository
{
    private IConfiguration _configuration;
    
    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        String strProject = "s17433";
        string strDatabase = "Animals";
        str strUserId = "testowygosc";
        str Password = "qwe123qwe123!"
                                   ";Persist Security Info=false;database=" + strDatabase +
                                   ";user id=" + strUserID + ";password=" +
                                   strPassword +
                                   ";Connection Timeout = 0;trustServerCertificate=true;";
    }
    
    public IEnumerable<Animal> GetAnimals()
    {
        using var con = new SqlConnection(_connectionString);
        
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animals ORDER BY Name";
        
        var dr = cmd.ExecuteReader();
        var animals = new List<Animal>();
        while (dr.Read())
        {
            var grade = new Animal()
            {
                IdAnimal = (int)dr["IdAnimal"],
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                Category = dr["Category"].ToString(),
                Area = dr["Area"].ToString(),
            };
            animals.Add(grade);
        }
        
        return animals;
    }

    public Animal GetAnimal(int idAnimal)
    {
        using var con = new SqlConnection(_connectionString);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animals WHERE IdAnimal = @IdAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal", idAnimal);
        
        var dr = cmd.ExecuteReader();
        
        if (!dr.Read()) return null;
        
        var animal = new Animal()
        {
            IdAnimal = (int)dr["IdAnimal"],
            Name = dr["Name"].ToString(),
            Description = dr["Description"].ToString(),
            Category = dr["Category"].ToString(),
            Area = dr["Area"].ToString(),
        };
        
        return animal;
    }

    public int CreateAnimal(Animal animal)
    {
        using var con = new SqlConnection(_connectionString);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "INSERT INTO Animals(IdAnimal, Name, Description, Category, Area) VALUES(@IdAnimal, @Name, @Description, @Category, @Area)";
        cmd.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);
        
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    
    public int DeleteAnimal(int id)
    {
        using var con = new SqlConnection(_connectionString);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "DELETE FROM Animals WHERE IdAnimal = @IdAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal", id);
        
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    public int UpdateAnimal(Animal animal)
    {
        using var con = new SqlConnection(_connectionString);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "UPDATE Animals SET Name=@Name, Description=@Description, Category=@Category, Area=@Area WHERE IdAnimal = @IdAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);
        
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }
}