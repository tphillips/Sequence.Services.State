using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sequence.Services.State.BLL;
using StackExchange.Redis;

namespace Sequence.Services.State.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class StateController : ControllerBase
	{
		StateBLL bll;
		public StateController(IDatabase database)
		{
			bll = new StateBLL(database);
		}

		[HttpPost]
		public async Task<ActionResult<Entities.State>> Post([FromBody] Entities.State req)
		{
			return Ok(await bll.SaveState(req));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Entities.State>> Get(Guid id)
		{
			return Ok(await bll.GetState(id));
		}

	}
}
