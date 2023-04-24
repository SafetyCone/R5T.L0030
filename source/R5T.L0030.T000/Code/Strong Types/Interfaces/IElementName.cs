using System;

using R5T.T0178;
using R5T.T0179;


namespace R5T.L0030.T000
{
    /// <summary>
    /// XML elements have names.
    /// This strong-type allows specifying that a string is an XML element name.
    /// </summary>
    [StrongTypeMarker]
    public interface IElementName : IStrongTypeMarker,
        ITyped<string>
    {
    }
}
