using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GolFullStack.Domain.Service.Interface.Business;
using GolFullStack.Domain.Validation.GolValidation.Interface;
using GolFullStack.Entity.Entities.Business;
using GolFullStack.Integration.Controllers;
using GolFullStack.Integration.ViewModels.Business;
using Microsoft.AspNetCore.Mvc;

namespace GolFullStack.Integration.V1.Controller.Business
{
    [ApiVersion("1.0")]    [Route("api/v{version:apiVersion}/Airplane")]
    public class AirplaneController : MainController
    {
        private readonly IMapper _mapper;        private readonly IAirplaneService _dbAirplane;        public AirplaneController(INotification notifier,                                  IAirplaneService dbAirplane,                                  IMapper mapper) : base(notifier)        {            _dbAirplane = dbAirplane;            _mapper = mapper;        }



        #region C.R.U.D
        [HttpGet("getall")]        public async Task<List<AirplaneViewModel>> GetAllCodeNews()        {            return _mapper.Map<List<AirplaneViewModel>>(await _dbAirplane.GetAll());        }        [HttpGet("getbyid/{id:guid}")]        public async Task<AirplaneViewModel> GetById([FromRoute] Guid id)        {            return _mapper.Map<AirplaneViewModel>(await _dbAirplane.GetById(id));        }        [HttpPost("add")]        public async Task<ActionResult<AirplaneViewModel>> Add([FromBody] AirplaneViewModel airplaneViewModel)        {            if (!ModelState.IsValid) return CustomReponse(ModelState);


            await _dbAirplane.Add(_mapper.Map<Airplane>(airplaneViewModel));            return CustomResponse(airplaneViewModel);        }        [HttpPut("update/{id:guid}")]        public async Task<ActionResult<AirplaneViewModel>> Update([FromRoute] Guid id, [FromBody] AirplaneViewModel airplaneViewModel)        {            if (id != airplaneViewModel.Id)            {                NotifyError("ID diferente do ID informado no objeto");                return CustomResponse(airplaneViewModel);            }            await _dbAirplane.Update(_mapper.Map<Airplane>(airplaneViewModel));            return CustomResponse(airplaneViewModel);        }        [HttpDelete("delete/{id:guid}")]        public async Task<ActionResult<AirplaneViewModel>> Delete(Guid id)        {            var codeNews = await GetById(id);            if (codeNews == null) return NotFound();            await _dbAirplane.Delete(id);            return CustomResponse(codeNews);        }        #endregion
    }
}
