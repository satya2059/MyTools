using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OCAT.DBLayer;

namespace OCAT.API.Controllers
{
    [Route("api/values")]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<DataModel> Get()
        {
            //return new string[] { "value1", "value2" };
            HttpResponseMessage respone = new HttpResponseMessage();
            List<DataModel> returnData = new List<DataModel>();
            try
            {
                returnData = DBAccesslayer.GetAllRecords();
                respone.StatusCode = HttpStatusCode.OK;                
            }
            catch (Exception e)
            {
                respone.StatusCode = HttpStatusCode.InternalServerError;
            }

            return returnData;
        }

        // GET api/values/5
        public DataModel Get([FromUri] string  userId)
        {
            HttpResponseMessage respone = new HttpResponseMessage();
            DataModel returnData = new DataModel ();
            try
            {
                returnData = DBAccesslayer.GetvoterRecord(userId);
                respone.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                respone.StatusCode = HttpStatusCode.InternalServerError;
            }

            return returnData;
        }


        public string Get(int id)
        {
           return "value";
        }

        // POST api/values
        public void Post([FromBody]DataModel value)
        {
            HttpResponseMessage respone = new HttpResponseMessage();
            if (ModelState.IsValid)
            {
                try
                {
                    DBLayer.DBAccesslayer.AddOrUpdate(value);
                    respone.StatusCode = HttpStatusCode.OK;
                }
                catch (Exception e)
                {
                    respone.StatusCode = HttpStatusCode.InternalServerError;
                }
            }
            else
            {
                respone.StatusCode = HttpStatusCode.BadRequest;
            }

        }

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
