using System;
using System.Threading.Tasks;
using PushAPI.API.Infrastructure;
using PushAPI.DAL.GenericEntity;
using PushAPI.ServiceLayer.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace PushAPI.API.Controllers
{
    [Route("api/[controller]")]
    public class BaseRestFulController<T> : BaseController where T : Entity
    {
        protected readonly IGenericService<T> _genericService;
        public BaseRestFulController(ILoggerFactory loggerFactory, IOptions<AppSettings> settings, IGenericService<T> genericService, IHostingEnvironment env) : base(loggerFactory, settings, env)
        {
            _genericService = genericService;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            return await MakeActionCall(async () =>
            {
                var result = await _genericService.GetAllEntitiesAsync();
                return result;
            });
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(long id)
        {
            return await MakeActionCall(async () =>
            {
                var result = await _genericService.GetByIdAsync(id);
                return result;
            });
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody]T model)
        {
            return await MakeActionCall(async () =>
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(GetModelStateErrors());
                }

                var result = await _genericService.CreateAsync(model);
                return result;
            });
        }

        [HttpPut]
        public virtual async Task<IActionResult> Put([FromBody]T model)
        {
            return await MakeActionCall(async () =>
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(GetModelStateErrors());
                }

                var result = await _genericService.UpdateAsync(model);
                return result;
            });
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(long id)
        {
            return await MakeActionCall(async () =>
            {
                var result = await _genericService.RemoveEntityAsync(id);
                return result;
            });
        }

    }
}