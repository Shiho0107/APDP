using APDPAssignment.Models;

namespace APDPAssignment.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int studentId);

    }
}
