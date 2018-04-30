using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBAPI_CRUDOperations.Models;

namespace WEBAPI_CRUDOperations.Controllers
{
    public class EmployeeController : ApiController
    {
        readonly IEmployeeRepository repository = new EmployeeRepository();
     
        public IEnumerable<Employee> Get()
        {
            return repository.GetAll();
        }

        public Employee Get(int ID)
        {
            Employee emp = repository.Get(ID);
            if (emp == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
           return emp;
        }

        public HttpResponseMessage PostEmployee(Employee emp)
        {
            emp = repository.Insert(emp);
            var response = Request.CreateResponse<Employee>(HttpStatusCode.Created, emp);

            string uri = Url.Link("DefaultApi", new { customerID = emp.ID });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public HttpResponseMessage PutEmployee(int ID, Employee emp)
        {
            emp.ID = ID;
            if (!repository.Update(emp))
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound," ID :"+ID);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
        public HttpResponseMessage DeleteEmployee(int ID)
        {
            Employee emp = repository.Get(ID);
            if (emp == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                if (repository.Delete(ID))
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound," ID "+ID );
                }
            }
        }
    }
}
