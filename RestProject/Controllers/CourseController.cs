using Database.DAO;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestProject.Controllers
{
    [RoutePrefix("api/Course")]
    public class CourseController : ApiController
    {
        private string conString = ConfigurationManager.ConnectionStrings["DBCorsi"].ConnectionString;
        [HttpGet]
        public IHttpActionResult Get(string title = "")
        {
            try
            { 
                BaseDAO.OpenConnection(conString);
                List<Courses> ret = CoursesDAO.GetAll(title);
                return Ok(ret);
            }catch(Exception e)
            {
                return InternalServerError(new Exception("ooooops", e));
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
        public IHttpActionResult Post([FromBody]Courses bean)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BaseDAO.OpenConnection(conString);
                    int newId = CoursesDAO.Insert(bean);
                    bean.COU_PK = newId;

                    return Created("", bean);
                }
                catch (Exception e)
                {
                    throw new Exception("", e);
                }
                finally
                {
                    BaseDAO.CloseConnection();
                }

            }
            else
            {
                try
                {
                    return BadRequest(ModelState);
                }
                catch (Exception e)
                {
                    throw new Exception("", e);
                }
                finally
                {
                    BaseDAO.CloseConnection();
                }
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Put(Courses bean, int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BaseDAO.OpenConnection(conString);
                    bean.COU_PK = id;
                    bool ret = CoursesDAO.Update(bean);
                    return Ok(ret);
                }
                catch (Exception e)
                {
                    throw new Exception("", e);
                }
                finally
                {
                    BaseDAO.CloseConnection(conString);
                }
            }
            else
            {
                try
                {
                    return NotFound();
                }
                catch (Exception e)
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
                bool ret = CoursesDAO.Delete(id);
                return Ok(ret);
            }
            catch (Exception e)
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
