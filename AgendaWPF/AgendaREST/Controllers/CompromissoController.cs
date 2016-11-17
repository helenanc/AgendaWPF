using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgendaREST.Controllers
{
    public class CompromissoController : ApiController
    {
        // GET api/agenda
        public IEnumerable<Models.Compromisso> Get()
        {
            Models.AgendaDataContext dc = new Models.AgendaDataContext();
            var r = from f in dc.Compromissos select f;
            return r.ToList();
        }

        // POST api/agenda
        public void Post([FromBody] string value)
        {
            List<Models.Compromisso> x = JsonConvert.DeserializeObject
            <List<Models.Compromisso>>(value);
            Models.AgendaDataContext dc = new Models.AgendaDataContext();
            dc.Compromissos.InsertAllOnSubmit(x);
            dc.SubmitChanges();
        }

        // PUT api/agenda/5
        public void Put(int id, [FromBody] string value)
        {
            Models.Compromisso x = JsonConvert.DeserializeObject
            <Models.Compromisso>(value);
            Models.AgendaDataContext dc = new Models.AgendaDataContext();
            Models.Compromisso comp = (from f in dc.Compromissos
                                   where f.Id == id
                                   select f).Single();
            comp.Descricao = x.Descricao;
            comp.Local = x.Local;
            comp.Data = x.Data;
            comp.Realizado = x.Realizado;
            dc.SubmitChanges();
        }

        // DELETE api/agenda/5
        public void Delete(int id)
        {
            Models.AgendaDataContext dc = new Models.AgendaDataContext();
            Models.Compromisso comp = (from f in dc.Compromissos
                                   where f.Id == id
                                   select f).Single();
            dc.Compromissos.DeleteOnSubmit(comp);
            dc.SubmitChanges();
        }
    }
}
