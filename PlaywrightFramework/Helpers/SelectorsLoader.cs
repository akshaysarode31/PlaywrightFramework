using YamlDotNet.Serialization;


namespace PlaywrightFramework.Helpers
{
    public static class SelectorsLoader
    {
        public static IDictionary<string, IDictionary<string, Selector>> LoadSelectors(string path)
        {
            var deserializer = new DeserializerBuilder()
                //.WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            using var reader = new StreamReader(path);
            var selectors = deserializer.Deserialize<Dictionary<string, Dictionary<string, Selector>>>(reader);

            // Explicitly convert to IDictionary
            IDictionary<string, IDictionary<string, Selector>> result = new Dictionary<string, IDictionary<string, Selector>>();
            foreach (var kvp in selectors)
            {
                result[kvp.Key] = new Dictionary<string, Selector>(kvp.Value);
            }
            return result;
        }
    }

    public class Selector
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
