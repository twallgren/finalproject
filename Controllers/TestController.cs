using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    public class TestController : ApiController
    {
        private TestRepository testRepository;

        public TestController()
        {
            this.testRepository = new TestRepository();
        }

        public Test[] Get()
        {
            return testRepository.GetAllContacts();
        }
    }
}