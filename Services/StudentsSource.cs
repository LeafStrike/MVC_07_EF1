using MVC_EF1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_EF1.Services
{
    public class StudentsSource
    {
        public List<Student> Students { get; }

        public StudentsSource()
        {
            Students = new List<Student>()
            {
                new Student
                {
                    Id = 0,
                    Name = "Nick",
                    Surname = "Valuev",
                    Age = 40,
                    GroupId = 10,
                    Status = "выпускник-бакалавр"
                },
                new Student
                {
                    Id = 1,
                    Name = "Dora",
                    Surname = "TheTraveller",
                    Age = 18,
                    GroupId = 12,
                    Status = "бакалавр"
                },
                new Student
                {
                    Id = 2,
                    Name = "Frodo",
                    Surname = "Baggins",
                    Age = 35,
                    GroupId = 14,
                    Status = "бакалавр"
                },
                new Student
                {
                    Id = 3,
                    Name = "Bilbo",
                    Surname = "Baggins",
                    Age = 110,
                    GroupId = 8,
                    Status = "магистр"
                }
            };
        }
    }
}
