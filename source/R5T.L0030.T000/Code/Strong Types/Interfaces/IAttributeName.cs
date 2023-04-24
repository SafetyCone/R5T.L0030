using System;

using R5T.T0178;


namespace R5T.L0030.T000
{
    /// <summary>
    /// XML attributes have names.
    /// This strong-type allows specifying that a string is an XML attribute name.
    /// It inherits from <see cref="IElementName"/> since attributes are elements too.
    /// </summary>
    [StrongTypeMarker]
    public interface IAttributeName : IStrongTypeMarker,
        IElementName
    {
    }
}
