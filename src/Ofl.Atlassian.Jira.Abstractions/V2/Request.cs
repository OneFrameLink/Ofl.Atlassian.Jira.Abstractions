using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Ofl.Reflection;

namespace Ofl.Atlassian.Jira.V2
{
    public abstract class Request
    {
        #region Constructor

        protected Request(
            IReadOnlyCollection<PropertyPath> expand
        )
        {
            // Validate parameters.
            Expand = expand
                ?? throw new ArgumentNullException(nameof(expand));
        }

        #endregion

        #region Instance, read-only state

        [JsonConverter(typeof(ExpandsPropertyPathConverter))]
        public IReadOnlyCollection<PropertyPath> Expand { get; }

        #endregion
    }
}
