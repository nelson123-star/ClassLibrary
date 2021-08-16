using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    class KeySoAPIClient
    {
        public KeySoAPIClient(string token)
        {
            var client = new vHttpClient(token);

        }
    }
}
