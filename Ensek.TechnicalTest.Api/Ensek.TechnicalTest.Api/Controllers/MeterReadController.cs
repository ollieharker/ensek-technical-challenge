using Ensek.TechnicalTest.Api.Dto;
using Ensek.TechnicalTest.Db.Context;
using Microsoft.AspNetCore.Mvc;

namespace Ensek.TechnicalTest.Api.Controllers
{
    [ApiController]
    public class MeterReadController
    {
        private readonly EnsekDbContext ensekDbContext;

        public MeterReadController(EnsekDbContext ensekDbContext)
        {
            this.ensekDbContext = ensekDbContext;
        }

        [HttpPost]
        [Route("/meter-reading-uploads")]
        public MeterReadUploadResult UploadMeterReads(IFormFile csvFile)
        {
            throw new NotImplementedException();
        }
    }
}
