using System.Data.SqlClient;
using GakkoHorizontalSlice.Model;

namespace GakkoHorizontalSlice.Repositories;

public class StudentsRepository : IStudentsRepository
{
    private IConfiguration _configuration;
    
    public StudentsRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public IEnumerable<Student> GetStudents()
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdStudent, FirstName, LastName, Email, Address, IndexNumber FROM Student ORDER BY LastName, FirstName";
        
        var dr = cmd.ExecuteReader();
        var students = new List<Student>();
        while (dr.Read())
        {
            var grade = new Student
            {
                IdStudent = (int)dr["IdStudent"],
                FirstName = dr["FirstName"].ToString(),
                LastName = dr["LastName"].ToString(),
                Email = dr["Email"].ToString(),
                Address = dr["Address"].ToString(),
                IndexNumber = (int)dr["IndexNumber"]
            };
            students.Add(grade);
        }
        
        return students;
    }

    public Student GetStudent(int idStudent)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdStudent, FirstName, LastName, Email, Address, IndexNumber FROM Student WHERE IdStudent = @IdStudent";
        cmd.Parameters.AddWithValue("@IdStudent", idStudent);
        
        var dr = cmd.ExecuteReader();
        
        if (!dr.Read()) return null;
        
        var student = new Student
        {
            IdStudent = (int)dr["IdStudent"],
            FirstName = dr["FirstName"].ToString(),
            LastName = dr["LastName"].ToString(),
            Email = dr["Email"].ToString(),
            Address = dr["Address"].ToString(),
            IndexNumber = (int)dr["IndexNumber"]
        };
        
        return student;
    }
    
    public int CreateStudent(Student student)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "INSERT INTO Student(FirstName, LastName, Email, Address, IndexNumber) VALUES(@FirstName, @LastName, @Email, @Address, @IndexNumber)";
        cmd.Parameters.AddWithValue("@IdStudent", student.IdStudent);
        cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
        cmd.Parameters.AddWithValue("@LastName", student.LastName);
        cmd.Parameters.AddWithValue("@Email", student.Email);
        cmd.Parameters.AddWithValue("@Address", student.Address);
        cmd.Parameters.AddWithValue("@IndexNumber", student.IndexNumber);
        
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    
    public int DeleteStudent(int id)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "DELETE FROM Student WHERE IdStudent = @IdStudent";
        cmd.Parameters.AddWithValue("@IdStudent", id);
        
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    public int UpdateStudent(Student student)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "UPDATE Student SET FirstName=@FirstName, LastName=@LastName, Email=@Email, Address=@Address, IndexNumber=@IndexNumber WHERE IdStudent = @IdStudent";
        cmd.Parameters.AddWithValue("@IdStudent", student.IdStudent);
        cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
        cmd.Parameters.AddWithValue("@LastName", student.LastName);
        cmd.Parameters.AddWithValue("@Email", student.Email);
        cmd.Parameters.AddWithValue("@Address", student.Address);
        cmd.Parameters.AddWithValue("@IndexNumber", student.IndexNumber);
        
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }
}