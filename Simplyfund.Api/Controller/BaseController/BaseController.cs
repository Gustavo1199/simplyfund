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


        [HttpPost(Name = "Add")]
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
                errorResponses.Message = ex.Message;
                return StatusCode(500, errorResponses);
            }
        }

        [HttpPost(Name = "AddAndReturn")]
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
                errorResponses.Message = ex.Message;
                return StatusCode(500, errorResponses);
            }
        }

        [HttpPost(Name = "AddAndReturnAsync")]
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
                errorResponses.Message = ex.Message;
                return StatusCode(500, errorResponses);
            }
        }

        [HttpPost(Name = "AddMany")]
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
                errorResponses.Message = ex.Message;
                return StatusCode(500, errorResponses);
            }
        }

        [HttpDelete(Name = "Delete")]
        public virtual ActionResult<bool> Delete(T entity)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var responses = baseServices.Delete(entity);
                    return CreatedAtAction(nameof(Delete), responses);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {

                ErrorResponses errorResponses = new ErrorResponses();
                errorResponses.Message = ex.Message;
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
                    return CreatedAtAction(nameof(GetAll), responses);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {

                ErrorResponses errorResponses = new ErrorResponses();
                errorResponses.Message = ex.Message;
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
                    return CreatedAtAction(nameof(GetAll), responses);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {

                ErrorResponses errorResponses = new ErrorResponses();
                errorResponses.Message = ex.Message;
                return StatusCode(500, errorResponses);
            }

        }

        [Auth]
        [HttpGet("GetById")]
        public virtual ActionResult<T> GetById(int id)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var responses = baseServices.GetById(id);
                    return CreatedAtAction(nameof(GetById), responses);
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {

                ErrorResponses errorResponses = new ErrorResponses();
                errorResponses.Message = ex.Message;
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
                    return CreatedAtAction(nameof(Update), true);
                }
                else
                {
                    return BadRequest(ModelState);
                }
                
               
            }
            catch (Exception ex)
            {
                ErrorResponses errorResponses = new ErrorResponses();
                errorResponses.Message = ex.Message;
                return StatusCode(500, errorResponses);
            }
        }

        [HttpPut("UpdateAndReturn")]
        public virtual ActionResult<T> UpdateAndReturn(T entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   var responses = baseServices.UpdateAndReturn(entity);
                    return CreatedAtAction(nameof(UpdateAndReturn), responses);
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {

                ErrorResponses errorResponses = new ErrorResponses();
                errorResponses.Message = ex.Message;
                return StatusCode(500, errorResponses);
            }
        }

        [HttpPut("UpdateAndReturnAsync")]
        public virtual async Task<ActionResult<T>> UpdateAndReturnAsync(T entity)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var responses = await baseServices.UpdateAndReturnAsync(entity);
                    return CreatedAtAction(nameof(UpdateAndReturn), responses);
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {

                ErrorResponses errorResponses = new ErrorResponses();
                errorResponses.Message = ex.Message;
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
                    return CreatedAtAction(nameof(FilterAndPaginate), responses);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                ErrorResponses errorResponses = new ErrorResponses();
                errorResponses.Message = ex.Message;
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
                    return CreatedAtAction(nameof(FilterAndPaginateAsync), responses);
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {

                ErrorResponses errorResponses = new ErrorResponses();
                errorResponses.Message = ex.Message;
                return StatusCode(500, errorResponses);
            }
        }

    }
}
