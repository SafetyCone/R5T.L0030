using System;

using R5T.T0178;
using R5T.T0179;


namespace R5T.L0030.T000
{
    [StrongTypeImplementationMarker]
    public class ElementName : TypedBase<string>, IStrongTypeImplementationMarker,
        IElementName
    {
        public ElementName(string value)
            : base(value)
        {
        }
    }
}
