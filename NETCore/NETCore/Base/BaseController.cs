﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCore.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NETCore.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Entity, Repository, Key> : ControllerBase
        where Entity:class
        where Repository:IRepository<Entity, Key>
    {
        private readonly Repository repository;

        public BaseController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public ActionResult Insert(Entity entity)
        {
            try
            {
                repository.Insert(entity);
                return Ok(new
                {
                    statusCode = StatusCode(200),
                    status = HttpStatusCode.OK,
                    message = "Success"
                });
            }
            catch
            {
                return BadRequest(new
                {
                    status = HttpStatusCode.BadRequest,
                    message = "Error duplicate data",
                    error = entity,
                });
            }
        }
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(new
                {
                    data = repository.Get(),
                    /*statusCode = StatusCode(200),*/
                    status = HttpStatusCode.OK,
                    message = "Success"
                });
            }
            catch
            {
                return BadRequest(new
                {
                    status = HttpStatusCode.NoContent,
                    message = "No Data",
                    /*error = e*/
                });
            }
        }

        [HttpGet("{key}")]
        public ActionResult Get(Key key)
        {
            try
            {
                return Ok(new
                {
                    data = repository.Get(key),
                    /*StatusCode(200),*/
                    status = HttpStatusCode.OK,
                    message = "Success"
                });
            }
            catch
            {
                return BadRequest(new
                {
                    /*statusCode=StatusCode(400),*/
                    status = HttpStatusCode.BadRequest,
                    message = "Data tidak ditemukan"
                });
            }

        }

        [HttpPut]
        public ActionResult Update(Entity entity)
        {
            try
            {
                return Ok(repository.Update(entity));
            }
            catch
            {
                return BadRequest(new
                {
                    message = "key tidak ditemukan",
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        [HttpDelete("{key}")]
        public ActionResult Delete(Key key)
        {
            try
            {
                return Ok(repository.Delete(key));
            }
            catch
            {
                return BadRequest("key tidak ditemukan");
            }

        }
    }
}
