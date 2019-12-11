using AutoMapper;
using ILBLI.IRepository;
using ILBLI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ILBLI_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<                                                        ValuesController> _Logger;
        private readonly ITest _Test;
        private readonly IMapper _Mapper;

        public ValuesController(ILogger<ValuesController> logger,ITest test,IMapper mapper)
        {
            this._Logger = logger;
            this._Test = test;
            this._Mapper = mapper;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        { 
            _Test.Doing();
            Person p = new Person();

            var s= _Mapper.Map<PersonEntity>(p); 
            return JsonConvert.SerializeObject(s); 
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
