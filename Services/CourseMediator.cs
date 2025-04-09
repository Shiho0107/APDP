using APDPAssignment.Models;
using APDPAssignment.Repositories;

namespace APDPAssignment.Services
{
    public class CourseMediator
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IAcademicRecordsRepository _academicRecordsRepository;
        private readonly IStudentRepository _studentRepository;

        public CourseMediator(
            ICourseRepository courseRepository,
            IAcademicRecordsRepository academicRecordsRepository,
            IStudentRepository studentRepository)
        {
            _courseRepository = courseRepository;
            _academicRecordsRepository = academicRecordsRepository;
            _studentRepository = studentRepository;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _courseRepository.GetAllCourses();
        }

        public bool AddCourse(Course course)
        {
            return _courseRepository.AddCourse(course);
        }

        public bool EditCourse(Course course)
        {
            return _courseRepository.EditCourse(course);
        }

        public bool DeleteCourse(int courseId)
        {
            var records = _academicRecordsRepository.GetAllAcademicRecords()
                .Where(r => r.Student.StudentCourses.Any(sc => sc.CourseId == courseId));

            if (records.Any())
                return false;

            return _courseRepository.DeleteCourse(courseId);
        }

        public Course GetCourseById(int courseId)
        {
            return _courseRepository.GetCourseById(courseId);
        }

        public bool AssignCourseToStudent(int studentId, int courseId)
        {
            try
            {
                var student = _studentRepository.GetStudentById(studentId);
                if (student == null)
                    return false;

                var course = _courseRepository.GetCourseById(courseId);
                if (course == null)
                    return false;

                var isEnrolled = student.StudentCourses.Any(sc => sc.CourseId == courseId);
                if (isEnrolled)
                    return false;

                var studentCourse = new StudentCourse
                {
                    StudentId = studentId,
                    CourseId = courseId
                };

                student.StudentCourses.Add(studentCourse);

                var academicRecord = new AcademicRecords
                {
                    StudentId = studentId,
                    grade = "Not Graded",
                    status = "Enrolled"
                };

                var success = _studentRepository.UpdateStudent(student) &&
                              _academicRecordsRepository.AddAcademicRecords(academicRecord);

                return success;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Course> GetStudentCourses(int studentId)
        {
            var student = _studentRepository.GetStudentById(studentId);
            if (student == null)
                return Enumerable.Empty<Course>();

            return student.StudentCourses.Select(sc => sc.Course);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentRepository.GetAllStudents();
        }
    }
}