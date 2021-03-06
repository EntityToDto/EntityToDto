﻿using System;

namespace EntityToDto
{
    /// <summary>
    /// What type of DTO properties to be included when mapping.
    /// </summary>
    [Flags]
    public enum MappingDepth : byte
    {
        /// <summary>
        /// Returns null DTO object.
        /// </summary>
        None = 0b0000,

        /// <summary>
        /// Only maps the primary key(s).
        /// </summary>
        Keys = 0b0001,

        /// <summary>
        /// Only maps the primitive properties.
        /// </summary>
        Primitives = 0b0010 | Keys,

        /// <summary>
        /// Enables to call the complex mapping for root object's properties.
        /// </summary>
        Complex = 0b0100,

        /// <summary>
        /// Used as bitmask. When at the root object, this enables mapping for all properties of the root object.
        /// <see cref="MappingDepth.Root"/> bit is removed when mapping on the root object's complex properties.
        /// </summary>
        Root = 0b1000
    }
}
