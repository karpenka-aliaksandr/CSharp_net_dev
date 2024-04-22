using Microsoft.AspNetCore.Mvc;
using SocketChat.BLL.Logic;
using SocketChat.Common.Entities;

namespace SocketChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageLogic _messageLogic;

        public MessageController(IMessageLogic messageLogic)
        {
            _messageLogic = messageLogic;
        }

        // GET: api/<MessageController>
        [HttpGet]
        public async Task<List<SignalRMessage>> Get()
        {
            var messages = await _messageLogic.GetAllAsync();
            return messages;
        }

        // POST api/<MessageController>
        [HttpPost]
        public async Task Post([FromBody] SignalRMessage message)
        {
            await _messageLogic.AddAsync(message);
        }
    }
}
