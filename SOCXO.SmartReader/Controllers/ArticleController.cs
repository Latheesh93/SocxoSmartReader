using SmartReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft;

namespace SOCXO.SmartReaderApp.Controllers
{
    [Route("api/article")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        [HttpGet]
        [Route("test")]
        [AllowAnonymous]
        public HttpResponseMessage Test()
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("parse")]
        [AllowAnonymous]
        public string SmartReaderParse(string url)
        {
            try
            {
                SmartReader.Reader sr = new SmartReader.Reader(url);
                Article article = sr.GetArticle();
                //if (article.IsReadable)
                if(article!=null)
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(article);
                }
                else
                {
                    return null;

                }
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}
