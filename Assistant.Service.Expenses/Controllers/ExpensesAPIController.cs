using Assistans.Service.ExpensesAPI.Models;
using Assistant.Service.ExpensesAPI.Data;
using Assistant.Service.ExpensesAPI.Models;
using Assistant.Service.ExpensesAPI.Models.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using System.ComponentModel;

namespace Assistant.Service.ExpensesAPI.Controllers
{
    [Route("api/expenses")]
    [Authorize]
    [ApiController]
    public class ExpensesAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private  ResponseDto _responseDto;
        private  IMapper _mapper;

        public ExpensesAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _responseDto = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDto GetExpenses()
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

        [Route("category_id/{category_id:int}")]
        [HttpGet]
        public ResponseDto GetExpensesCategory(int category_id)
        {
            try
            {
                IEnumerable<Expenses> obj = _db.expenses.Where(u => u.CategoryId == category_id).ToList();
                _responseDto.Result = _mapper.Map<IEnumerable<ExpensesDto>>(obj);
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
                expensesDto.UserId = userid;
                Expenses obj = _mapper.Map<Expenses>(expensesDto);
                _db.expenses.Add(obj);
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
                _db.expenses.Remove(obj);
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
                _db.expenses.Update(obj);
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
                _responseDto.Result = _mapper.Map<IEnumerable<Category>>(categories);
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
                Category obj = _db.categories.FirstOrDefault(u => u.Id == id);
                Category categoryDto = _mapper.Map<Category>(obj);
                _responseDto.Result = categoryDto;
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
        public ResponseDto PostCategories([FromBody] Category categoryDto)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var ValidNameCategory = _db.categories.FirstOrDefault(u => u.Name == categoryDto.Name && u.UserId == userid);

            if (ValidNameCategory != null)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "This name category is taken";
            }
            else
            {
                try
                {
                    Category obj = _mapper.Map<Category>(categoryDto); // Error Mapper
                    obj.UserId = userid;
                    _db.categories.Add(obj);
                    _db.SaveChanges();

                    _responseDto.Result = _mapper.Map<Category>(obj);
                }
                catch (Exception ex)
                {
                    _responseDto.IsSuccess = false;
                    _responseDto.Message = ex.Message;
                }
            }

            return _responseDto;
        }

        [Route("categories/{id:int}")]
        [HttpDelete]
        public ResponseDto DeleteCategories(int id)
        {
            try
            {
                Category obj = _db.categories.First(u => u.Id == id);
                _db.categories.Remove(obj);
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
        public ResponseDto PutCategories([FromBody] Category categoryDto)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            try
            {
                Category obj = _mapper.Map<Category>(categoryDto);
                obj.UserId = userid;
                _db.categories.Add(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }


        [Route("category_count")]
        [HttpGet]
        public ResponseDto SumCategoryCount()
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            try
            {
                IEnumerable<Category> categories = _db.categories.Where(u => u.UserId == userid).ToList();
                List<CategoryCountDto> categoryCounts = new List<CategoryCountDto>();

                var i = 0;
                foreach (var category in categories)
                {
                    int sum = _db.expenses.Where(row => row.CategoryId == category.Id)
                        .Sum(row => row.Count);

                    CategoryCountDto categoryCountDto = new CategoryCountDto
                    {
                        Id = category.Id,
                        UserId = category.UserId,
                        Name = category.Name,
                        Count = sum
                    };

                    categoryCounts.Add(categoryCountDto);

                }

                _responseDto.Result = categoryCounts;//_mapper.Map<IEnumerable<CategoryDto>>(categories);
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
