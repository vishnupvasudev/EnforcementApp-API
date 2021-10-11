namespace KeyVault
{
    using KeyVault.Interfaces;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// WebConfigKeyVault
    /// </summary>
    public class WebConfigKeyVault : IKeyValueProvider
    {
        /// <summary>
        /// _iConfiguration
        /// </summary>
        private readonly IConfiguration _iConfiguration;

        /// <summary>
        /// WebConfigKeyVault Constructor
        /// </summary>
        /// <param name="iConfiguration"></param>
        public WebConfigKeyVault(IConfiguration iConfiguration)
        {
            this._iConfiguration = iConfiguration;
        }

        /// <summary>
        /// GetValues_
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetValues(string key)
        {
            string value = this._iConfiguration.GetSection("AppSettings").GetSection(key).Value;
            return value;
        }

        /// <summary>
        /// GetValues
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetValues<T>(string key) where T : class, new()
        {
            T obj = new T();
            this._iConfiguration.GetSection(key).Bind(obj);
            return obj;
        }
    }
}
