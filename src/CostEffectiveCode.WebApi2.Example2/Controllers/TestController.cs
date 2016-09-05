using System.Web.Http;
using System.Web.Http.Description;
using CostEffectiveCode.Cqrs.Commands;
using CostEffectiveCode.Cqrs.Queries;
using CostEffectiveCode.WebApi2.Example2.Models;

namespace CostEffectiveCode.WebApi2.Example2.Controllers
{
    public class TestController : CqrsController
    {
        public TestController(ICommandFactory commandFactory, IQueryFactory queryFactory) 
            : base(commandFactory, queryFactory)
        {
        }

        [ResponseType(typeof(TestDto))]
        public IHttpActionResult Get(int id) => this.Get<int, Test, TestDto>(id);
    }
}
