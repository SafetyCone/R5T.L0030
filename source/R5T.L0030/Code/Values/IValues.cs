using System;
using System.Xml.Linq;

using R5T.T0131;


namespace R5T.L0030
{
    [ValuesMarker]
    public partial interface IValues : IValuesMarker
    {
        /// <summary>
        /// The default attribute value for use in creating attributes when attributes need to be created, but all you have it the name of the attribute.
        /// </summary>
        /// <remarks>
        /// You cannot create a new <see cref="XAttribute"/> without specifying both the attribute's name and its value.
        /// But this it not ideal, since you might not know the value of the attribute yet when you want to create it (like in an acquire-by-name method).
        /// Also, it does not match the behavior of <see cref="XElement"/>s, which can be created by only specifying a name.
        /// So this value is the default for use when you need a value, but don't yet have one.
        /// </remarks>
        public const string DefaultAttributeValue_Constant = Z0000.IStrings.Empty_Constant;

        /// <inheritdoc cref="DefaultAttributeValue_Constant"/>
        public string DefaultAttributeValue => IValues.DefaultAttributeValue_Constant;
    }
}
