using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWT.Algorithms;
using JWT.Builder;

namespace PSIM2.Security
{
    public static class TokenManager
    {
        private static readonly string _secret = "Super secret JWT password";

        public static string GenerateAccessToken(long? userId)
        {
            return new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(Encoding.ASCII.GetBytes(_secret))
                .AddClaim("exp", DateTimeOffset.UtcNow.AddMinutes(60).ToUnixTimeSeconds())
                .AddClaim("userId", userId)
                .Encode();
        }

        public static IDictionary<string, object> VerifyToken(string token)
        {
            return new JwtBuilder()
                 .WithAlgorithm(new HMACSHA256Algorithm())
                 .WithSecret(_secret)
                 .MustVerifySignature()
                 .Decode<IDictionary<string, object>>(token);
        }
    }
}
