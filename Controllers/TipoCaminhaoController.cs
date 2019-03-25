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
    [Route("api/TipoCaminhao")]
    public class TipoCaminhaoController : Controller
    {
        private readonly IApplicationTipoCaminhao app;

        public TipoCaminhaoController(IApplicationTipoCaminhao _app)
        {
            app = _app;
        }

        // GET: api/TipoCaminhao
        [HttpGet]
        public IEnumerable<TipoCaminhao> Get()
        {
            return app.Get();
        }

        // GET: api/TipoCaminhao/5
        [HttpGet("{id}")]
        public TipoCaminhao GetId(string id)
        {
            return app.GetId(id);
        }

        [HttpGet("GetCodigo/{codigo}")]
        public IEnumerable<TipoCaminhao> GetCodigo(int codigo)
        {
            return app.GetCodigo(codigo);
        }

        // POST: api/TipoCaminhao
        [HttpPost]
        public TipoCaminhao Post([FromBody]TipoCaminhao value)
        {
            return app.Add(value);
        }
        
        // PUT: api/TipoCaminhao/5
        [HttpPut("{id}")]
        public TipoCaminhao Put(string id, [FromBody]TipoCaminhao value)
        {
            return app.Update(value, id);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public TipoCaminhao Delete(string id)
        {
            return app.Remove(id);
        }
    }
}
