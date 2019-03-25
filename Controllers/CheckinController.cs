using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrunckPad.Application.Interfaces;
using TrunckPad.Domain.Dto;
using TrunckPad.Domain.Entitys;

namespace TrunckPad.Presentation.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Checkin")]
    public class CheckinController : Controller
    {

        private readonly IApplicationCheckin app;

        public CheckinController(IApplicationCheckin _app)
        {
            app = _app;
        }

        // GET: api/Checkin
        [HttpGet]
        public IEnumerable<Checkin> Get()
        {
            return app.Get();
        }

        // GET: api/Checkin/5
        [HttpGet("{id}")]
        public Checkin GetId(string id)
        {
            return app.GetId(id);
        }

        [HttpGet("GetCaminhoneiroSemCarga/{data}")]
        public IEnumerable<CaminhoneiroDto> GetCaminhoneiroSemCarga(DateTime data)
        {
            return app.GetCaminhoneiroSemCarga(data);
        }

        [HttpGet("GetCaminhoneiros/{dataInicio}/{dataTermino}")]
        public IEnumerable<CaminhoneiroDto> GetCaminhoneiros(DateTime dataInicio, DateTime dataTermino)
        {
            return app.GetCaminhoneiros(dataInicio, dataTermino);
        }

        // POST: api/Checkin
        [HttpPost]
        public Checkin Post([FromBody]Checkin value)
        {
            return app.Add(value);
        }
        
        // PUT: api/Checkin/5
        [HttpPut("{id}")]
        public Checkin Put(string id, [FromBody]Checkin value)
        {
            return app.Update(value, id);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Checkin Delete(string id)
        {
            return app.Remove(id);
        }
    }
}
