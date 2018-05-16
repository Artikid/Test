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
                List<Courses> ret = CoursesDAO.GetAll(title);
                return Ok(ret);
            }
            catch (Exception e)
            {
                return InternalServerError(new Exception("ooooops", e));
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
        [HttpGet]
        [Route("{id:int}/Survey")]
        public IHttpActionResult GetResults(int id)
        {
            List<SurveyResults> ret = SurveyResultsDAO.GetAll(id);
            return Ok(ret);
        }


        [HttpPut]
        [Route("{id:int}/Survey")]
        public IHttpActionResult PutResults([FromBody] List<SurveyResults> bean, int id)
        {
            if (ModelState.IsValid)
            {
                CourseResultsDAO.Delete(id);
                foreach (SurveyResults r in bean)
                {
                    CourseResults b = new CourseResults() { COU_FK = id, RES_FK = r.ID };
                    CourseResultsDAO.Insert(b);
                }
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route]
        public IHttpActionResult Put(Courses bean)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int ret = CoursesDAO.Insert(bean);
                    return Ok(ret);
                }
                catch (Exception e)
                {
                    throw new Exception("", e);
                    // return NotFound();
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
                bool ret = CoursesDAO.Delete(id);
                return Ok(ret);
            }
            catch (Exception e)
            {
                throw new Exception("", e);
            }
        }
    }
}
