using System;
using System.Collections.Generic;
using System.Text;

namespace TokenProvider.Interfaces
{
    /// <summary>
    /// ITokenProvider
    /// </summary>
    public interface ITokenProvider
    {
        /// <summary>
        /// Generate Token
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        string GenerateToken(string UserName, long UserID);

        /// <summary>
        /// Generate Token
        /// </summary>
        /// <param name="RefreshToken"></param>
        /// <returns></returns>
        string GenerateToken(string RefreshToken);


    }
}
