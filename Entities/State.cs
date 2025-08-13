using System;

namespace Sequence.Services.State.Entities
{
	public class State
	{
		public Guid ID { get; set; }
		public int Version { get; internal set; } = 1;
		public string Body { get; set; }
	}
}
