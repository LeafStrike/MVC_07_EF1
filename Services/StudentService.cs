using MVC_EF1.Interfaces;
using MVC_EF1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_EF1.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentService _studentService;
        private readonly StudentsDBContext _context;
        public StudentService(StudentsDBContext studentsDBContext)
        {
            _context = studentsDBContext;
        }
        public List<StudentDBModel> GetStudentsList()
        {
            return _context.Students.ToList();
        }
        public StudentDBModel GetStudent(int studentId)
        {
            return _context.Students.FirstOrDefault(x => x.Id == studentId);
        }
        public void EditStudent(StudentDBModel student)
        {
            _context.Students.FirstOrDefault(x => x.Id.Equals(student.Id)).Name = student.Name;
            _context.Students.FirstOrDefault(x => x.Id.Equals(student.Id)).Surname = student.Surname;
            _context.Students.FirstOrDefault(x => x.Id.Equals(student.Id)).Age = student.Age;
            _context.Students.FirstOrDefault(x => x.Id.Equals(student.Id)).GroupId = student.GroupId;
            _context.Students.FirstOrDefault(x => x.Id.Equals(student.Id)).Status = student.Status;
            _context.SaveChanges();
        }
        public void RemoveStudent(int studentId)
        {
            _context.Students.Remove(_context.Students.FirstOrDefault(x => x.Id.Equals(studentId)));
            _context.SaveChanges();
        }
        public StudentDBModel AddStudent(StudentDBModel student)
        {
            _context.Students.Add(new StudentDBModel
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                Age = student.Age,
                GroupId = student.GroupId,
                Status = student.Status
            });
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
            }
            return student;
        }
    }
}
