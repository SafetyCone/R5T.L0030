using System;

using R5T.T0178;


namespace R5T.L0030.T000.N001
{
    /// <summary>
    /// Strongly-types a string as an element (either attribute or element) name.
    /// Allows an element name to be either a <see cref="IAttributeName"/> or <see cref="T000.IElementName"/>
    /// </summary>
    [StrongTypeMarker]
    public interface IElementName : IStrongTypeMarker,
        T000.IElementName,
        IAttributeName
    {
    }
}
