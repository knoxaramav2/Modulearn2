using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Modulearn2A.Utility
{

    public class JwtConfig
    {
        public int AccessTokenLifetime;
        public int RefreshTokenLifetime;

        public string Secret;
        public string Issuer;
        public string Audience;
    }

    public interface IJwtAuthManager
    {

    }

    public class RefreshToken
    {

    }

    public class JwtAuthResult
    {

    }

    public class JwtAuthManager : IJwtAuthManager
    {
        public IImmutableDictionary<string, RefreshToken> RefreshTokens;

        private readonly ConcurrentDictionary<string, RefreshToken> _refreshTokens;
        private readonly JwtConfig _jwtConfig;
        private readonly byte[] _secret;

        public JwtAuthManager(JwtConfig jwtConfig)
        {
            _jwtConfig = jwtConfig;
            _refreshTokens = new ConcurrentDictionary<string, RefreshToken>();
            _secret = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
        }

        public JwtAuthResult GenerateTokens(string userName, Claim[] claims, DateTime time)
        {
           

            return null;
        }
    }
}
