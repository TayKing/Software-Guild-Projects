using GuildCars.Data.Factories;
using GuildCars.Models.Queries;
using System;
using System.Web.Http;

namespace GuildCars.UI.Controllers
{
    public class VehicleAPIController : ApiController
    {

        [Route("api/vehicle/search/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Search(bool? IsNew, string QueryString, int? MinPrice, int? MaxPrice, int? MinYear, int? MaxYear)
        {
            var repo = DataRepositoryFactory.GetRepository();

            QuickSearchParameters model = new QuickSearchParameters()
            {
                IsNew = IsNew,
                QueryString = QueryString,
                MinPrice = MinPrice,
                MaxPrice = MaxPrice,
                MinYear = MinYear,
                MaxYear = MaxYear
            };
            try
            {
                var result = repo.SearchVehicles(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/models/filter")]
        [AcceptVerbs("GET")]
        public IHttpActionResult FilterModels(int MakeID)
        {
            var repo = DataRepositoryFactory.GetRepository();
            try
            {
                var result = repo.GetModelsByMakeID(MakeID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/reports/sales")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetSalesReport(string UserID, string StartDate, string EndDate)
        {
            var repo = DataRepositoryFactory.GetRepository();
            try
            {
                var result = repo.GetSalesReport(UserID, StartDate, EndDate);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
