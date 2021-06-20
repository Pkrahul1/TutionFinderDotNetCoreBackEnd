using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                   new Student
                    {
                        Id = 1,
                        Name = "Mary",
                        City = "Chapra",
                        Email = "pkrahul.ks16@gmail.com"
                    },
                   new Student
                   {
                       Id = 2,
                       Name = "Darry",
                       City = "Patna",
                       Email = "rahull.ks16@gmail.com"
                   }
               );
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    Id=1,
                    Name="David",
                    Email="rahulll.ks18@gmail.com",
                    City="Patna",
                    Gender=Gender.Male,
                    About="I can teach from class 5 to 10 , All Subjects.",
                    Skills="MATH, ENGLISH,SCIENCE",
                },
                new Teacher
                {
                    Id = 2,
                    Name = "Christy Pearly",
                    Email = "pchristy@gmail.com",
                    City = "Chapra",
                    Gender = Gender.Female,
                    About = "I can teach from class 8 to 10 , All Subjects.",
                    Skills = "MATH, ENGLISH,SCIENCE",
                }
                );
            modelBuilder.Entity<Tution>().HasData(
               new Tution
               {
                   Id = 1,
                   City = "chapra",
                   Description = "I can teach from class 5 to 10 , All Subjects.",
                   CreaterId = "rahull.ks16@gmail.com",
                   Status = true

               },
               new Tution
               {
                   Id = 2,
                   City = "Patna",
                   Description = "I can teach from class 5 to 10 , All Subjects.",
                   CreaterId = "pkrahul.ks16@gmail.com",
                   Status = true
               }
               ) ;
        }
    }
}
