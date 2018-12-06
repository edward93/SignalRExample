using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PushAPI.API.Infrastructure;
using PushAPI.DAL.Entities;
using PushAPI.API.SignalR;
using PushAPI.ServiceLayer.Services;
using Microsoft.AspNetCore.SignalR;

namespace PushAPI.API.Controllers
{
    public class MessageController : BaseRestFulController<SystemMessage>
    {
        private readonly IHubContext<MessageHub> _hub;
        public MessageController(ILoggerFactory loggerFactory, IHubContext<MessageHub> sgnalRMessage, IOptions<AppSettings> settings, IGenericService<SystemMessage> genericService, IHostingEnvironment env) : base(loggerFactory, settings, genericService, env)
        {
            _hub = sgnalRMessage;
        }

        public override async Task<IActionResult> Post([FromBody]SystemMessage model)
        {
            return await MakeActionCall(async () =>
            {
                var message = model.MessageBody;
                await _genericService.CreateAsync(model);
                await _hub.Clients.All.SendAsync("ReceiveMessage", message);

                return true;
            });
        }
    }
}
