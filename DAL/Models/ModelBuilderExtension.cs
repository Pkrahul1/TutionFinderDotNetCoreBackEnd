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
                        Name = "Mary",
                        City = "Chapra",
                        Email = "pkrahul.ks16@gmail.com",
                        Password="12345678",
                        ConfirmPassword= "12345678"
                   },
                   new Student
                   {
                       Name = "Darry",
                       City = "Patna",
                       Email = "rahull.ks16@gmail.com",
                       Password = "12345678",
                       ConfirmPassword = "12345678"
                   }
               );
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    Name="David",
                    Email="rahulll.ks18@gmail.com",
                    City="Patna",
                    Gender=Gender.Male,
                    About="I can teach from class 5 to 10 , All Subjects.",
                    Skills="MATH, ENGLISH,SCIENCE",
                    Password = "12345678",
                    ConfirmPassword = "12345678"
                },
                new Teacher
                {
                    Name = "Christy Pearly",
                    Email = "pchristy@gmail.com",
                    City = "Chapra",
                    Gender = Gender.Female,
                    About = "I can teach from class 8 to 10 , All Subjects.",
                    Skills = "MATH, ENGLISH,SCIENCE",
                    Password = "12345678",
                    ConfirmPassword = "12345678"
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
