using APIRafael.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIRafael.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController
    {
        [HttpGet(Name = "GetStudents")]
        public List<Student> GetStudents()
        {
            return Students.GetStudents();
        }

        [HttpPost(Name = "AddStudents")]
        public string AddStudent(Student student)
        {
            Students.AddStudent(student);
            return $"Estudante {student.Name} adicionado!";
        }

        [HttpPut(Name = "UpdateStudent")]
        public string UpdateStudent(int id, Student student)
        {
            Students.UpdateStudent(id, student);
            return $"Estudante {student.Name} ATUALIZADO!";
        }

        [HttpDelete(Name = "DeleteStudent")]
        public string DeleteStudent(int id)
        {
            Students.DeleteStudent(id);
            return $"Estudante do id {id} deletado!";
        }
    }
}
