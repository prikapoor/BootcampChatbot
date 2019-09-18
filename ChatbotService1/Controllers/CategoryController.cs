using ChatbotDataModelLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChatbotService1.Support_Classes;
using Unity;

namespace ChatbotService1.Controllers
{
    public class CategoryController : ApiController
    {
        readonly UnityContainer _con = new UnityContainer();                

        public CategoryController()
        {
            _con.RegisterType<CategoryContractLib.ICategory, CategoryLib.Category>();
        }

        [Route("api/Category")]
        public Question GetCategory()
        {
            CategoryContractLib.ICategory category;
            category = _con.Resolve<CategoryContractLib.ICategory>();
            return category.GetCategories();
        }

        [Route("api/Category/{Q1}")]
        public Question GetCategoryQuestion1(string Q1)
        {
            CategoryContractLib.ICategory category;
            category = _con.Resolve<CategoryContractLib.ICategory>();
            return category.GetQuestion1(Q1);            
        }        

        [Route("api/Category/{Q1}/{Q2}")]
        public HttpResponseMessage GetSolutionICU(string Q1, string Q2)
        {
            CategoryContractLib.ICategory category;
            category = _con.Resolve<CategoryContractLib.ICategory>();            
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, category.GetSolution(Q1,Q2));
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }
    }
}
