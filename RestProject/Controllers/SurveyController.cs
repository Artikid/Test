using Database.DAO;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        private string conString = ConfigurationManager.ConnectionStrings["DBCorsi"].ConnectionString;
        [HttpGet]
        public IHttpActionResult Get(string nomeCorso = "")
        {
            try
            {
                BaseDAO.OpenConnection(conString);
                List<SurveyResults> ret = SurveyResultsDAO.GetAll(nomeCorso);
                return Ok(ret);
            }
            catch (Exception e)
            {
                return InternalServerError(new Exception("Oooooopsss", e));
            }
            finally
            {
                BaseDAO.CloseConnection(conString);
            }
        }
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            BaseDAO.OpenConnection(conString);
            SurveyResults ret = SurveyResultsDAO.GetSingle(id);
            if (ret == null)
            {

                return NotFound();
            }

            BaseDAO.CloseConnection(conString);
            return Ok(ret);


        }
        [HttpPost]
        [Route("")]
        public IHttpActionResult Post([FromBody] SurveyResults bean)
        {
            if (ModelState.IsValid)
            {
                try {
                    BaseDAO.OpenConnection(conString);
                    int newId = SurveyResultsDAO.Insert(bean);
                    bean.ID = newId;

                    return Created("", bean);
                }catch (Exception e)
                {
                    throw new Exception("", e);
                }finally
                {
                    BaseDAO.CloseConnection();
                }

            }
            else
            {
                try
                {
                    return BadRequest(ModelState);
                }catch (Exception e) {
                    throw new Exception("", e);
                }finally
                {
                    BaseDAO.CloseConnection();
                }
            }
        }
        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Put (SurveyResults bean, int id)
        {   
            if (ModelState.IsValid)
            {
                try {
                    BaseDAO.OpenConnection(conString);
                    bean.ID = id;
                    bool ret = SurveyResultsDAO.Update(bean);
                    return Ok(ret);
                }catch (Exception e)
                {
                    throw new Exception("", e);
                }finally
                {
                    BaseDAO.CloseConnection(conString);

                }
            }else
            {
                try {          
                return NotFound();
                }catch (Exception e)
                {
                    throw new Exception("", e);
                }
                finally
                {
                    BaseDAO.CloseConnection(conString);

                }
            }
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                BaseDAO.OpenConnection(conString);
                bool ret = SurveyResultsDAO.Delete(id);
                return Ok(ret);
            }catch (Exception e)
            {
                throw new Exception("", e);
            }
            finally
            {
                BaseDAO.CloseConnection(conString);
            }
        }
    }
}
