using Database.DAO;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace RestProject.Controllers
{
    [RoutePrefix("api/Survey")]
    public class SurveyController : ApiController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [HttpGet]
        public IHttpActionResult Get(string nomeCorso = "")
        {
            try
            {
                log.Info("Chiamato GetAll");
                List<SurveyResults> ret = SurveyResultsDAO.GetAll(nomeCorso);
                log.Info(ret[0]);
                Debug.WriteLine(ret[0]);
                return Ok(ret);
            }
            catch (Exception e)
            {
                log.Error("Errore GetAll", e);
                return InternalServerError(new Exception("Oooooopsss", e));
            }
        }
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            SurveyResults ret = SurveyResultsDAO.GetSingle(id);
            if (ret == null)
            {
                return NotFound();
            }
            return Ok(ret);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Put(SurveyResults bean, int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bean.ID = id;
                    bool ret = SurveyResultsDAO.Update(bean);
                    return Ok(ret);
                }
                catch (Exception e)
                {
                    throw new Exception("", e);
                }
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                bool ret = SurveyResultsDAO.Delete(id);
                return Ok(ret);
            }
            catch (Exception e)
            {
                throw new Exception("", e);
            }
        }
    }
}
