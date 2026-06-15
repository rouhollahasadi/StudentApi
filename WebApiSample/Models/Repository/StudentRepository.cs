using WebApiSample.Models.DatabaseContext;
using WebApiSample.Models.ViewModels;
using WebApiSample.Models;

namespace WebApiSample.Models.Repository
{
    public class StudentRepository
    {
        private readonly MDataBaseContext _context;
        public StudentRepository(MDataBaseContext context)
        {
            _context = context;
        }
        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }
        public Student Get(int Id)
        {
            var student = _context.Students.SingleOrDefault(p => p.Id == Id);
            return student;
        }
        public Student Add(StudentViewModel viewModel) 
        {
            var model = new Student
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                StudentCode = viewModel.StudentCode
            };
            var result = _context.Students.Add(model);
            _context.SaveChanges();
            return model;
        }
        public bool Update(Student student)
        {
           if(student!=null)
            {
                if(student.Id!=null)
                {
                    _context.Students.Update(student);
                    _context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool Delete(int id)
        {
            var result = Get(id);
            if(result!=null)
            {
                _context.Students.Remove(result);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
