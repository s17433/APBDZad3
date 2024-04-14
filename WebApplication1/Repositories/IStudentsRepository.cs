using GakkoHorizontalSlice.Model;

namespace GakkoHorizontalSlice.Repositories;

public interface IStudentsRepository
{
    IEnumerable<Student> GetStudents();
    int CreateStudent(Student student);
    Student GetStudent(int idStudent);
    int UpdateStudent(Student student);
    int DeleteStudent(int idStudent);
}