using System;

using R5T.T0178;
using R5T.T0179;


namespace R5T.L0030.T000
{
    /// <summary>
    /// XML elements have names.
    /// This strong-type allows specifying that a string is an XML element name.
    /// </summary>
    /// <remarks>
    /// See <see cref="N001.IElementName"/> for a type that can be both an <see cref="IAttributeName"/> and an <see cref="IElementName"/>.
    /// </remarks>
    [StrongTypeMarker]
    public interface IElementName : IStrongTypeMarker,
        ITyped<string>
    {
    }
}
