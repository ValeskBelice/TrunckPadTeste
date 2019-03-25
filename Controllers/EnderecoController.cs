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
    [Route("api/Endereco")]
    public class EnderecoController : Controller
    {

        private readonly IApplicationEndereco app;

        public EnderecoController(IApplicationEndereco _app)
        {
            app = _app;
        }

        // GET: api/Endereco
        [HttpGet]
        public IEnumerable<Endereco> Get()
        {
            return app.Get();
        }

        // GET: api/Endereco/5
        [HttpGet("{id}")]
        public Endereco Getd(string id)
        {
            return app.GetId(id);
        }
        
        // POST: api/Endereco
        [HttpPost]
        public Endereco Post([FromBody]Endereco value)
        {
            return app.Add(value);
        }
        
        // PUT: api/Endereco/5
        [HttpPut("{id}")]
        public Endereco Put(string id, [FromBody]Endereco value)
        {
            return app.Update(value, id);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Endereco Delete(string id)
        {
            return app.Remove(id);
        }
    }
}
