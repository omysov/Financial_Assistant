using Assistans.Service.ExpensesAPI.Models;
using Assistant.Service.ExpensesAPI.Data;
using Assistant.Service.ExpensesAPI.Models;
using Assistant.Service.ExpensesAPI.Models.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Assistant.Service.ExpensesAPI.Controllers
{
    [Route("api/expenses")]
    [Authorize]
    public class ExpensesAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly ResponseDto _responseDto;
        private readonly IMapper _mapper;

        public ExpensesAPIController(AppDbContext db, ResponseDto response, IMapper mapper)
        {
            _db = db;
            _responseDto = response;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ResponseDto> GetExpenses()
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            try
            {
                IEnumerable<Expenses> expenses = _db.expenses.Where(u => u.UserId == userid).ToList();
                _responseDto.Result = _mapper.Map<IEnumerable<ExpensesDto>>(expenses);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [Route("{id:int}")]
        [HttpGet]
        public ResponseDto GetExpenses(int id)
        {
            try
            {
                Expenses obj = _db.expenses.FirstOrDefault(u => u.ExpensesId == id);
                ExpensesDto expensesDto = _mapper.Map<ExpensesDto>(obj);
                _responseDto.Result = expensesDto;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }


        [HttpPost]
        public ResponseDto PostExpenses([FromBody] ExpensesDto expensesDto)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            try
            {
                Expenses obj = _mapper.Map<Expenses>(expensesDto);
                obj.UserId = userid;
                _db.Add(obj);
                _db.SaveChanges();

                _responseDto.Result = _mapper.Map<ExpensesDto>(obj);
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
        public ResponseDto DeleteExpenses(int id)
        {
            try
            {
                Expenses obj = _db.expenses.First(u => u.ExpensesId == id);
                _db.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpPut]
        public ResponseDto PutExpenses([FromBody] ExpensesDto expensesDto)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            try
            {
                Expenses obj = _mapper.Map<Expenses>(expensesDto);
                obj.UserId = userid;
                _db.Add(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }


        [HttpGet]
        [Route("categories")]
        public ResponseDto GetCategories()
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            try
            {
                IEnumerable<Category> categories = _db.categories.Where(u => u.UserId == userid).ToList();
                _responseDto.Result = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [Route("categories/{id:int}")]
        [HttpGet]
        public ResponseDto GetCategories(int id)
        {
            try
            {
                Expenses obj = _db.expenses.FirstOrDefault(u => u.ExpensesId == id);
                ExpensesDto expensesDto = _mapper.Map<ExpensesDto>(obj);
                _responseDto.Result = expensesDto;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }


        [HttpPost]
        [Route("categories")]
        public ResponseDto PostCategories([FromBody] ExpensesDto expensesDto)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            try
            {
                Expenses obj = _mapper.Map<Expenses>(expensesDto);
                obj.UserId = userid;
                _db.Add(obj);
                _db.SaveChanges();

                _responseDto.Result = _mapper.Map<ExpensesDto>(obj);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [Route("categories/{id:int}")]
        [HttpDelete]
        public ResponseDto DeleteCategories(int id)
        {
            try
            {
                Expenses obj = _db.expenses.First(u => u.ExpensesId == id);
                _db.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }


        [Route("categories")]
        [HttpPut]
        public ResponseDto PutCategories([FromBody] ExpensesDto expensesDto)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            try
            {
                Expenses obj = _mapper.Map<Expenses>(expensesDto);
                obj.UserId = userid;
                _db.Add(obj);
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
