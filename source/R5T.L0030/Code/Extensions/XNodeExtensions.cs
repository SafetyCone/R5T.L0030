﻿using R5T.F0000;
using System;
using System.Xml.Linq;


namespace R5T.L0030.Extensions
{
    public static class XNodeExtensions
    {
        public static WasFound<XElement> Has_Element<TNode>(this TNode node,
            Func<TNode, XElement> elementOrDefaultSelector)
            where TNode : XNode
        {
            return Instances.XmlOperator.Has_Element(
                node,
                elementOrDefaultSelector);
        }
    }
}
