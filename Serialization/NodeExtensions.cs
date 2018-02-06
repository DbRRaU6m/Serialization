namespace Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class NodeExtensions
    {
        /// <summary>
        /// Generates a pretty-printed dump of an object hierarchy, including Ids of parent nodes.
        /// </summary>
        /// <param name="iNode">Root of the object hierarchy.</param>
        /// <param name="Indentation">Indentation level.</param>
        /// <returns>Sequence of strings to represent object hierarchy.</returns>
        public static IEnumerable<string> Dump(this Node iNode, string Indentation = "")
        {
            var FormatString = "{0}Node Id:{1}, Parent Id:{2}";
            var ParentId = null != iNode.Parent ? iNode.Parent.Id : "null";
            var iLine = String.Format(FormatString, Indentation, iNode.Id, ParentId);
            return new string[] { iLine }.Concat(iNode.Children.SelectMany(aNode => aNode.Dump(Indentation + "  ")));
        }
    }
}
