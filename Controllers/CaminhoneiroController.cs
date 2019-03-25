using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrunckPad.Application.Interfaces;
using TrunckPad.Domain.Entitys;

namespace TrunckPad.Presetation.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Caminhoneiro")]
    public class CaminhoneiroController : Controller
    {
        private readonly IApplicationCaminhoneiro app;

        public CaminhoneiroController(IApplicationCaminhoneiro _app)
        {
            app = _app;
        }

        // GET: api/Caminhoneiro
        [HttpGet]
        public IEnumerable<Caminhoneiro> Get()
        {
            return app.Get();
        }

        // GET: api/Caminhoneiro/5
        [HttpGet("{id}")]
        public Caminhoneiro GetId(string id)
        {
            return app.GetId(id);
        }

        [HttpGet("GetCpf/{cpf}")]
        public IEnumerable<Caminhoneiro> GetCpf(string cpf)
        {
            return app.GetCpf(cpf);
        }

        [HttpGet("GetCnh/{cnh}")]
        public IEnumerable<Caminhoneiro> GetCnh(string cnh)
        {
            return app.GetCnh(cnh);
        }

        [HttpGet("GetVeiculoProprio")]
        public IEnumerable<Caminhoneiro> GetVeiculoProprio()
        {
            return app.GetVeiculoProprio();
        }

        // POST: api/Caminhoneiro
        [HttpPost]
        public Caminhoneiro Post([FromBody]Caminhoneiro value)
        {
            return app.Add(value);
        }
        
        // PUT: api/Caminhoneiro/5
        [HttpPut("{id}")]
        public Caminhoneiro Put(string id, [FromBody]Caminhoneiro value)
        {
            return app.Update(value, id);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Caminhoneiro Delete(string id)
        {
            return app.Remove(id);
        }
    }
}
