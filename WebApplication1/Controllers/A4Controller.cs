using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class A4Controller : ControllerBase
    {
        const int Row= 20;

        private readonly ILogger<A4Controller> _logger;

        public A4Controller(ILogger<A4Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<StudentEmails> Get(int StudentId,int currentPage)
        {
          

            List<Student> students = new List<Student>();
            students.Add(new Student { Id = 1, Name = "NTest1", Family = "FTest1" });
            students.Add(new Student { Id = 2, Name = "NTest2", Family = "FTest2" });
            students.Add(new Student { Id = 3, Name = "NTest3", Family = "FTest3" });

            List<StudentEmails> studentEmails = new List<StudentEmails>();

            int TotalPages = (400 / Row) * 10;
          
            for (int i = 0; i < 400; i++)
            {
                if (i%2!=0)
                {
                   
                    studentEmails.Add(new StudentEmails {  Id = 1, Email = i + "@gmail.com", Pages = TotalPages }); ;

                }
                else
                {
                    
                    studentEmails.Add(new StudentEmails {  Id = 2, Email = i + "@gmail.com", Pages = TotalPages });

                }

            }
            currentPage -= 1;
            currentPage *= Row;
            var stuEmails= studentEmails.Where(x => x.Id == StudentId).Skip(currentPage - Row).Take(Row);
           
            
            return stuEmails;



            //var options = new JsonSerializerOptions
            //{
            //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            //    WriteIndented = true
            //};
            // return   JsonSerializer.Serialize(students, options);

        }
    }
}