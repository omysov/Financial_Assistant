using Assistans.Service.IncomeAPI.Models;
using Assistant.Service.AuthAPI.Data;
using Assistant.Service.IncomeAPI.Models.Dto;
using AutoMapper;
using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;
//using System.IdentityModel.Tokens.Jwt;

namespace Assistans.Service.IncomeAPI.Controllers
{
    [Route("api/income")]
    [ApiController]
    [Authorize]
    public class IncomeAPIController : ControllerBase
    {

        private readonly AppDbContext _db;
        private readonly ResponseDto _responseDto;
        private readonly IMapper _mapper;

        public IncomeAPIController(AppDbContext db, ResponseDto responseDto, IMapper mapper)
        {
            _db = db;
            _responseDto = responseDto;
            _mapper = mapper;
            
        }

        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ResponseDto Get()
        {

            //var userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;
            //var user = User.FindFirst("Name").Value;
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // Можно вынести в контроллер Front

            try
            {
                IEnumerable<Income> objlist = _db.incomes.Where(u => u.UserId == userid).ToList();

                _responseDto.Result = _mapper.Map<IEnumerable<IncomeDto>>(objlist);

            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }


            ResponseDto response = new ResponseDto();
            response.Message = userid;
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiYWRtaW4iLCJzdWIiOiI0MWI0ZTJhNS01NWU5LTQ3YTUtYmU2Yi03MjE4YmZhZjUxYjUiLCJlbWFpbCI6ImFkbWluQGFkbWluLmNvbSIsIm5iZiI6MTY5NTE2MDA2NCwiZXhwIjoxNjk1NzY0ODY0LCJpYXQiOjE2OTUxNjAwNjQsImlzcyI6ImFzc2lzdGFudC1hdXRoLWFwaSIsImF1ZCI6ImFzc2lzdGFudC1jbGllbnQifQ.xXum61_Iu4xRW7lqRwgIjWDjNlhP0GUwT1XgF6YYZNg";


            return _responseDto;
        }

        [Route("{id:int}")]
        [HttpGet]
        public ResponseDto Get(int id)
        {
            try
            {
                Income obj = _db.incomes.FirstOrDefault(u => u.IncomeId == id);
                IncomeDto incomeDto = _mapper.Map<IncomeDto>(obj);
                _responseDto.Result = incomeDto;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }


        [HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ResponseDto Post([FromBody] IncomeDto incomeDto)
        {

            //var userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;
            //var user = User.FindFirst("Name").Value;
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // Можно вынести в контроллер Front

            try
            {
                Income obj = _mapper.Map<Income>(incomeDto);
                obj.UserId = userid;
                _db.incomes.Add(obj);
                _db.SaveChanges();

                _responseDto.Result = _mapper.Map<IncomeDto>(obj);

            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }

            return _responseDto;
        }


        [HttpPut]
        public ResponseDto Put([FromBody] IncomeDto incomeDto)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            try
            {
                Income obj = _mapper.Map<Income>(incomeDto);
                obj.UserId = userid;
                _db.incomes.Update(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [Route("{id:int}")]
        [HttpDelete]
        public ResponseDto Delete(int id)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            try
            {
                Income obj = _db.incomes.First(u => u.IncomeId == id);
                _db.incomes.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }
    }
}
