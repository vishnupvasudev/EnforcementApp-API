using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Enforcement.DAL
{
    /// <summary>
    /// DataAccessParameters
    /// </summary>
    public class DataAccessParameters
    {
        /// <summary>
        /// Items
        /// </summary>
        public ConcurrentDictionary<string, object> Items { get; }

        /// <summary>
        /// DataAccessParameters
        /// </summary>
        public DataAccessParameters()
        {
            Items = new ConcurrentDictionary<string, object>();
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <typeparam name="T">items</typeparam>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void Add<T>(string name, T value)
        {
            Items.TryAdd(name, value);
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void Add(string name, object value)
        {
            Items.TryAdd(name, value);
        }
    }
}
