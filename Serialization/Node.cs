namespace Serialization
{
    using CollectionDecorator;
    using ParentDecorator;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Xml.Serialization;

    /// <summary>
    /// Class for nodes.
    /// </summary>
    public class Node : IChild<Node>
    {
        /// <summary>
        /// Minimal payload for exposition.
        /// </summary>
        public string Id;

        /// <summary>
        /// Gets or sets the parent node; excluded from serialization.
        /// </summary>
        [XmlIgnore]
        public Node Parent { get; set; }

        public CollectionDecorator<Node> Children
        { 
            get; private set;
        }

        public Node(string Id)
        {
            Trace.WriteLine("Node master constructor called");
            this.Id = Id;
            this.Children = new ParentDecorator<Node>(new List<Node>(), this);
        }

        /// <summary>
        /// Parameterless constructor, necessary for deserialization.
        /// </summary>
        public Node() : this("")
        {
            Trace.WriteLine("Node constructor called");
        }
    }
}
