#region Included Namespaces
using Enforcement.Domain;
#endregion Included Namespaces

namespace Enforcement.BLL.Interface
{
    #region IUser
    /// <summary>
    /// IUser
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Register
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        long Register(User user);

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Domain.User Authenticate(string email, string password);
    }
    #endregion IUser
}
