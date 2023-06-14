using System;

using R5T.T0178;
using R5T.T0179;


namespace R5T.L0030.T000
{
    /// <inheritdoc cref="IAttributeName"/>
    [StrongTypeImplementationMarker]
    public class AttributeName : TypedBase<string>, IStrongTypeImplementationMarker,
        IAttributeName
    {
        public AttributeName(string value)
            : base(value)
        {
        }
    }
}
