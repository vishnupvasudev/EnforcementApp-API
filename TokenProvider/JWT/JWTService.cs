#region Included Namespaces
using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using KeyVault.Interfaces;
using Utilities;
using Microsoft.IdentityModel.Tokens;
using TokenProvider.Interfaces;
#endregion Included Namespaces

namespace TokenProvider
{
    /// <summary>
    /// JWT Service
    /// </summary>
    public class JWTService : ITokenProvider
    {
        #region Varibles
        /// <summary>
        /// _ i key ValueProvider - readonly member
        /// </summary>
        private readonly IKeyValueProvider _ikeyValueProvider;

        #endregion Varibles

        #region Constructor
        /// <summary>
        /// JWTService
        /// </summary>
        /// <param name="ikeyValueProvider"></param>
        /// <param name="encryption"></param>
        public JWTService(IKeyValueProvider ikeyValueProvider)
        {
            this._ikeyValueProvider = ikeyValueProvider;
        }
        #endregion

        #region Generate Token
        /// <summary>
        /// Generate Token
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public string GenerateToken(string UserName, long UserID)
        {
            string encUserID = UserID.ToString(CultureInfo.InvariantCulture).Encrypt();
            var claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name, UserName),
                    new Claim(ClaimTypes.NameIdentifier,encUserID ),
                };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_ikeyValueProvider.GetValues("JWTSecret"));
            var jwtExpireInMinutes = _ikeyValueProvider.GetValues("JWTTokenExpireInMinutes");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(Convert.ToDouble(jwtExpireInMinutes, CultureInfo.InvariantCulture)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// GenerateToken
        /// </summary>
        /// <param name="RefreshToken"></param>
        /// <returns></returns>
        public string GenerateToken(string RefreshToken)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
