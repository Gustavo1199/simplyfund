using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simplyfund.Bll.ServicesInterface.IBaseServices;
using Simplyfund.GeneralConfiguration.Autentication;
using SimplyFund.Domain.Base.Filter;
using SimplyFund.Domain.Dto.Responses;
using System;
using System.Linq.Expressions;

namespace Simplyfund.Api.Controller.BaseController
{
    [ApiController]
    public abstract class BaseController<T> : ControllerBase where T : class
    {

        private readonly IBaseServices<T> baseServices;
        public BaseController(IBaseServices<T> baseServices)
        {
            this.baseServices = baseServices;
        }


        [HttpPost("Add")]
        public virtual ActionResult Add(T entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    baseServices.Add(entity);
                    return CreatedAtAction(nameof(Add), entity);
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {
                ErrorResponses errorResponses = new ErrorResponses();
                if (ex.InnerException != null)
                {
                    errorResponses.Message = ex.InnerException.Message;

                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }

        [HttpPost("AddAsync")]
        public virtual async Task<ActionResult> AddAsync(T entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await baseServices.AddAsync(entity);
                    return CreatedAtAction(nameof(AddAsync), entity);
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {
                ErrorResponses errorResponses = new ErrorResponses();
                if (ex.InnerException != null)
                {
                    errorResponses.Message = ex.InnerException.Message;

                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }

        [HttpPost("AddAndReturn")]
        public virtual ActionResult<T> AddAndReturn(T entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var ent = baseServices.AddAndReturn(entity);
                    return CreatedAtAction(nameof(AddAndReturn), ent);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                ErrorResponses errorResponses = new ErrorResponses();
                if (ex.InnerException != null)
                {
                    errorResponses.Message = ex.InnerException.Message;

                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }

        [HttpPost("AddAndReturnAsync")]
        public virtual async Task<ActionResult<T>> AddAndReturnAsync(T entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity = await baseServices.AddAndReturnAsync(entity);
                    return CreatedAtAction(nameof(AddAndReturn), entity);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                ErrorResponses errorResponses = new ErrorResponses();
                if (ex.InnerException != null)
                {
                    errorResponses.Message = ex.InnerException.Message;

                }
                else
                {
                    errorResponses.Message = ex.Message;
                }

                return StatusCode(500, errorResponses);
            }
        }

        [HttpPost("AddMany")]
        public virtual ActionResult AddMany(IEnumerable<T> entities)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    baseServices.AddMany(entities);
                    return CreatedAtAction(nameof(AddMany), true);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                ErrorResponses errorResponses = new ErrorResponses();
                if (ex.InnerException != null)
                {
                    errorResponses.Message = ex.InnerException.Message;

                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }

        [HttpDelete("Delete")]
        public virtual ActionResult<bool> Delete(T entity)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var responses = baseServices.Delete(entity);
                    return Ok(responses);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {

                ErrorResponses errorResponses = new ErrorResponses();
                if (ex.InnerException != null)
                {
                    errorResponses.Message = ex.InnerException.Message;

                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }

        }


        [HttpDelete("DeleteByIdAsync/{Id}")]
        public virtual async Task<ActionResult> DeleteByIdAsync(int Id)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var responses = await baseServices.DeleteByIdAsync(Id);
                    return Ok(responses);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {

                ErrorResponses errorResponses = new ErrorResponses();
                if (ex.InnerException != null)
                {
                    errorResponses.Message = ex.InnerException.Message;

                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }

        }

        [HttpGet("GetAll")]
        public virtual ActionResult<IEnumerable<T>> GetAll()
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var responses = baseServices.GetAll();
                    return Ok(responses);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                ErrorResponses errorResponses = new ErrorResponses();
                if (ex.InnerException != null)
                {
                    errorResponses.Message = ex.InnerException.Message;

                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }

        [HttpGet("GetAllAsync")]
        public virtual async Task<ActionResult<IEnumerable<T>>> GetAllAsync()
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var responses = await baseServices.GetAsync();
                    return Ok(responses);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {

                ErrorResponses errorResponses = new ErrorResponses();
                if (ex.InnerException != null)
                {
                    errorResponses.Message = ex.InnerException.Message;

                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }

        }

        [HttpGet("GetById")]
        public virtual ActionResult<T> GetById(int id)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var responses = baseServices.GetById(id);
                    return Ok(responses);
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {

                ErrorResponses errorResponses = new ErrorResponses();
                if (ex.InnerException != null)
                {
                    errorResponses.Message = ex.InnerException.Message;

                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }

        [HttpGet("GetByIdAsync")]
        public virtual async Task<ActionResult<T>> GetByIdAsync(int id)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var responses = await baseServices.GetByIdAsync(id);
                    return Ok(responses);
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {

                ErrorResponses errorResponses = new ErrorResponses();
                if (ex.InnerException != null)
                {
                    errorResponses.Message = ex.InnerException.Message;

                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }

        [HttpPut("Update")]
        public virtual ActionResult Update(T entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    baseServices.Update(entity);
                    return Ok(true);
                }
                else
                {
                    return BadRequest(ModelState);
                }


            }
            catch (Exception ex)
            {
                ErrorResponses errorResponses = new ErrorResponses();
                if (ex.InnerException != null)
                {
                    errorResponses.Message = ex.InnerException.Message;

                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }

        //Task<bool> UpdateAsync(T entity)

        [HttpPut("UpdateAsync")]
        public virtual async Task<ActionResult<bool>> UpdateAsync(T entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var responses = await baseServices.UpdateAsync(entity);
                    return Ok(responses);
                }
                else
                {
                    return BadRequest(ModelState);
                }


            }
            catch (Exception ex)
            {
                ErrorResponses errorResponses = new ErrorResponses();
                if (ex.InnerException != null)
                {
                    errorResponses.Message = ex.InnerException.Message;

                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }

       

        [HttpPost("FilterAndPaginate")]
        public ActionResult<PaginatedList<T>> FilterAndPaginate(FilterAndPaginateRequestModel? filters)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var responses = baseServices.FilterAndPaginate(filters);
                    return Ok(responses);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                ErrorResponses errorResponses = new ErrorResponses();
                if (ex.InnerException != null)
                {
                    errorResponses.Message = ex.InnerException.Message;

                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }

        [HttpPost("FilterAndPaginateAsync")]
        public async Task<ActionResult<PaginatedList<T>>> FilterAndPaginateAsync(FilterAndPaginateRequestModel? filters)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var responses = await baseServices.FilterAndPaginateAsync(filters);
                    return Ok(responses);
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {

                ErrorResponses errorResponses = new ErrorResponses();
                if (ex.InnerException != null)
                {
                    errorResponses.Message = ex.InnerException.Message;

                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }


        [NonAction]
        public int GetUserByToken()
        {

            if (HttpContext.Request.Headers.TryGetValue("UserId", out var userIdValues))
            {
                int userId = Convert.ToInt32(userIdValues.FirstOrDefault());
                return userId;
            }
            else
            {
                return -1;
            }
        }

    }
}
