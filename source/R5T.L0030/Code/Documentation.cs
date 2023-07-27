using System;
using System.Xml.Linq;


namespace R5T.L0030
{
	/// <summary>
	/// XML document processing library.
	/// </summary>
	public static class Documentation
	{
        /// <summary>
        /// Note: asynchronous settings can be used synchronously, but not vice-versa.
        /// </summary>
        public static readonly object NoteOnAsynchronousSettings;

        /// <summary>
        /// Note that only <see cref="XElement"/>, <see cref="XDocument"/> and <see cref="XAttribute"/> have constructors like this (<see cref="XObject"/>, <see cref="XNode"/>, and <see cref="XContainer"/> do not).
        /// </summary>
        public static readonly object WhichXObjectsAreCloneable;
	}
}