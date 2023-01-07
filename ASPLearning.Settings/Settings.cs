namespace ASPLearning.Settings;


using Microsoft.Extensions.Configuration;
public abstract class Settings
{
	public static T Load<T>(string key)
	{
		T settings = (T)Activator.CreateInstance(typeof(T));
		var configuration = new ConfigurationBuilder()
								.SetBasePath(Directory.GetCurrentDirectory())
								.AddJsonFile("appsettings.json", optional: false)
								.AddJsonFile("appsettings.development.json", optional: true)
								.AddEnvironmentVariables()
								.Build();
		configuration.GetSection(key).Bind(settings);
		return settings;
	}
}