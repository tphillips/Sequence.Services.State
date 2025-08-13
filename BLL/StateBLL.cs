using System;
using System.Threading.Tasks;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace Sequence.Services.State.BLL
{

	public partial class StateBLL
	{

		private IDatabase db;

		public StateBLL(IDatabase database)
		{
			db = database;
		}

		internal async Task<Entities.State> GetState(Guid id)
		{
			var value = await db.StringGetAsync(id.ToString());
			return value.IsNull ? null : JsonConvert.DeserializeObject<Entities.State>(value);
		}

		internal async Task<Entities.State> SaveState(Entities.State req)
		{
			var existing = await GetState(req.ID);
			if (existing != null)
			{
				existing.Body = req.Body;
				existing.Version++;
				req = existing;
			}
			else
			{
				req.Version = 1;
			}
			await db.StringSetAsync(req.ID.ToString(), JsonConvert.SerializeObject(req));
			return req;
		}
	}
}