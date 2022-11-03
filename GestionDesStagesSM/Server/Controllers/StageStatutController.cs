using GestionDesStagesSM.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionDesStagesSM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StageStatutController : Controller
    {
        private readonly IStageStatutRepository _stageStatutRepository;

        public StageStatutController(IStageStatutRepository stageStatutRepository)
        {
            _stageStatutRepository = stageStatutRepository;
        }

        [HttpGet]
        public IActionResult GetAllStageStatuts()
        {
            return Ok(_stageStatutRepository.GetAllStageStatuts());
        }


    }
}
