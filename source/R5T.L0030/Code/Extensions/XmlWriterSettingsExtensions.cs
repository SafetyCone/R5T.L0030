using System;
using System.Xml;


namespace R5T.L0030.Extensions
{
    public static class XmlWriterSettingsExtensions
    {
        public static XmlWriterSettings Set_Standard(this XmlWriterSettings settings)
        {
            Instances.XmlWriterSettingsOperator.Set_Standard(settings);

            return settings;
        }
    }
}
