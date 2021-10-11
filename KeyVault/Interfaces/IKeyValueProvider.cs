using System;
using System.Collections.Generic;
using System.Text;

namespace KeyVault.Interfaces
{
    /// <summary>
    /// IKeyValueProvider Interface
    /// </summary>
    public interface IKeyValueProvider
    {
        /// <summary>
        /// Get Values
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetValues(string key);

        /// <summary>
        /// Get Values
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T GetValues<T>(string key) where T : class, new();
    }
}
