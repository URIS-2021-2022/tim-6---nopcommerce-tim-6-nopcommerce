using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Nop.Core.Http.Extensions;
using Nop.Services.Authentication;

namespace Nop.Services.Html
{
    /// <summary>
    ///  Represents extensions of ISession
    /// </summary>
    public static partial class SessionExtensions
    {
        #region Methods

        /// <summary>
        /// Add error
        /// </summary>
        /// <param name="session">Session</param>
        /// <param name="error">Error</param>
        public static void AddErrorsToDisplay(this ISession session, string error)
        {
            var errors = session.Get<IList<string>>(NopAuthenticationDefaults.ExternalAuthenticationErrorsSessionKey) ?? new List<string>();
            errors.Add(error);
            session.Set(NopAuthenticationDefaults.ExternalAuthenticationErrorsSessionKey, errors);
        }

        /// <summary>
        /// Retrieve errors to display
        /// </summary>
        /// <returns>Errors</returns>
        public static IList<string> RetrieveErrorsToDisplay(this ISession session)
        {
            var errors = session.Get<IList<string>>(NopAuthenticationDefaults.ExternalAuthenticationErrorsSessionKey);

            if (errors != null)
                session.Remove(NopAuthenticationDefaults.ExternalAuthenticationErrorsSessionKey);

            return errors;
        }

        #endregion
    }
}