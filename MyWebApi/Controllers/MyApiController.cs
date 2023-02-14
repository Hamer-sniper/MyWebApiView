﻿using Microsoft.AspNetCore.Mvc;
using MyWebApiView.Interfaces;
using MyWebApiView.Models;

namespace MyWebApiView.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyApiController : ControllerBase
    {
        private readonly IDataBookData dataBookData;
        public MyApiController(IDataBookData dBData)
        {
            dataBookData = dBData;
        }

        // GET api/MyApi
        [HttpGet]
        public IEnumerable<IDataBook> Get()
        {
            return dataBookData.GetAllDatabooks();
        }

        // GET api/MyApi/1
        [HttpGet("{id}")]
        public IDataBook GetCarById(int id)
        {
            return dataBookData.ReadDataBook(id);
        }

        // POST api/MyApi
        [HttpPost]
        public void Post([FromBody] DataBook dataBook)
        {
            dataBookData.CreateDataBook(dataBook);
        }

        // PUT api/MyApi/3
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] DataBook dataBook)
        {
            dataBookData.UpdateDataBookById(id, dataBook);
        }

        // DELETE api/MyApi/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dataBookData.DeleteDataBookById(id);
        }

    }
}
