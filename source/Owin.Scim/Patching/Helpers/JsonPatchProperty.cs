// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Owin.Scim.Patching.Helpers
{
    using System;

    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Metadata for JsonProperty.
    /// </summary>
    public class JsonPatchProperty
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public JsonPatchProperty(JsonProperty property, object parent)
        {
            if (property == null)
                throw new ArgumentNullException("property");

            if (parent == null)
                throw new ArgumentNullException("parent");

            Property = property;
            Parent = parent;
        }

        /// <summary>
        /// Gets or sets JsonProperty.
        /// </summary>
        public JsonProperty Property { get; set; }

        /// <summary>
        /// Gets or sets Parent.
        /// </summary>
        public object Parent { get; set; }
    }
}