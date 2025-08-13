namespace Sequence.Services.State
{
	public static class Global
	{
		public static string ApiPrefix { get; } = System.Environment.GetEnvironmentVariable("ApiPrefix") ?? "dev";
		public static string RedisServer { get; } = System.Environment.GetEnvironmentVariable("RedisServer") ?? "192.168.4.197:6379";
		public static string RedisPassword { get; } = System.Environment.GetEnvironmentVariable("RedisPassword") ?? "eYVX7EwVmmxKPCDmwMtyKVge8oLd2t81";
	}
}