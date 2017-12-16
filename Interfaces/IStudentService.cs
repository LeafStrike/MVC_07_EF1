using MVC_EF1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_EF1.Interfaces
{
    public interface IStudentService
    {
        List<StudentDBModel> GetStudentsList();
        StudentDBModel GetStudent(int studentId);
        void EditStudent(StudentDBModel student);
        void RemoveStudent(int studentId);
        StudentDBModel AddStudent(StudentDBModel student);
    }
}
