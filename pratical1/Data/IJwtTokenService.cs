using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pratical1.Data
{
    public interface IJwtTokenService
    {
        string BuildToken(string email);
    }
}
