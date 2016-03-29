using System;
using MvcWebDemo.Models.ViewModel;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using FcuMVCPorject.Models;

namespace FcuMVCPorject.Service
{
    public class StudentBaseService
    {
        private StudentDbContext db = new StudentDbContext();

        public List<StudentViewModel> getStudentList()
        {
            if (!db.StudentProfile.Any())
            {
                db.StudentProfile.Add(new StudentProfile()
                {
                    guid = new Guid(),
                    Id = "D9938982",
                    Name = "Duran Hsieh",
                    Address = "台中市西屯區文化路100號",
                    Email = "dog0416@gmail.com",
                    Tel = "0912123456",
                    Message = "hello mvc"
                });
                db.SaveChanges();
            }

            var result = db.StudentProfile.Select(x=> new StudentViewModel{ guid = x.guid, ID = x.Id,NAME = x.Name,ADDRESS = x.Address, EMAIL=x.Email, TEL = x.Tel,MESSAGE = x.Message}).ToList();
            return result;
        }

        public StudentViewModel getStudent(Guid guid)
        {
            var result = db.StudentProfile.FirstOrDefault(x => x.guid == guid);
            if (result != null)
            {
                return new StudentViewModel()
                {
                    guid = result.guid,
                    ID = result.Id,
                    NAME = result.Name,
                    ADDRESS = result.Address,
                    TEL = result.Tel,
                    EMAIL = result.Email,
                    MESSAGE = result.Message
                };
            }
            else
            {
                return null;
            }
        }

        public bool addStudent(StudentViewModel data)
        {
            data.guid = Guid.NewGuid();
            db.StudentProfile.Add(ConvertFromViewModel(data));
            db.SaveChanges();
            return true;
        }

        public bool updateStudent(StudentViewModel data)
        {
            db.StudentProfile.AddOrUpdate(ConvertFromViewModel(data));
            db.SaveChanges();
            return true;
        }

        public bool deleteStudent(Guid guid)
        {
            var result = db.StudentProfile.FirstOrDefault(x => x.guid == guid);
            db.StudentProfile.Remove(result);
            db.SaveChanges();
            return true;
        }

        private StudentProfile ConvertFromViewModel(StudentViewModel data)
        {
            return new StudentProfile()
            {
                guid = data.guid,
                Id = data.ID,
                Name = data.NAME,
                Address = data.ADDRESS,
                Email = data.EMAIL,
                Tel = data.TEL,
                Message = data.MESSAGE
            };
        }

    }
}