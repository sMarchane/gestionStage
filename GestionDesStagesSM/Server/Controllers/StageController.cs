﻿using GestionDesStagesSM.Client.Services;
using GestionDesStagesSM.Server.Interfaces;
using GestionDesStagesSM.Shared.Modele;
using Microsoft.AspNetCore.Mvc;

namespace GestionDesStagesSM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StageController : ControllerBase
    {
        private readonly IStageRepository _stageRepository;
        

        public StageController(IStageRepository stageRepository)
        {
            this._stageRepository = stageRepository;
            
        }

        [HttpPost]
        public IActionResult CreateStage([FromBody] Stage stage)
        {
            if (stage == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = _stageRepository.AddStage(stage);

            return Created("stage", created);
        }



        [HttpGet("{id}")]
        public IActionResult GetAllStage(string id)
        {
            return Ok(_stageRepository.GetAllStagesById(id));
        }
        [HttpGet]
        public IActionResult GetAllStages()
        {
            return Ok(_stageRepository.GetAllStages());
        }

        [HttpGet("GetStageByStageId/{StageId}")]
        public IActionResult GetStageByStageId(string StageId)
        {
            return Ok(_stageRepository.GetStageByStageId(StageId));
        }
        [HttpPut]
        public IActionResult UpdateStage([FromBody] Stage stage)
        {
            if (stage == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // S'assurer que le stage existe dans la table avant de faire la mise à jour
            var stageToUpdate = _stageRepository.GetStageByStageId(stage.StageId.ToString());

            if (stageToUpdate == null)
                return NotFound();

            _stageRepository.UpdateStage(stage);

            return NoContent(); //success
        }


    }
}