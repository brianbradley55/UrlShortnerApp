using System;
using System.Collections.Generic;
using System.Text;

namespace URLShortnerApp.Utility
{
    public class Validations : IValidations
    {
        public bool IsValidUri(string uri)
        {
            Uri validatedUri;
            return Uri.TryCreate(uri, UriKind.RelativeOrAbsolute, out validatedUri);
        }
    }
}
