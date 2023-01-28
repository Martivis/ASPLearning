using Duende.IdentityServer.Test;

namespace ASPLearning.Identity.Configuration;

public static class AppApiTestUsers
{
	public static List<TestUser> ApiUsers =>
		new List<TestUser>
		{
			new TestUser
			{
				SubjectId = "1",
				Username = "test",
				Password = "testpwd",
			},
			new TestUser
			{
				SubjectId = "2",
				Username = "second",
				Password = "123",
			}
		};
}
