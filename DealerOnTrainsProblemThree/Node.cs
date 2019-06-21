using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOnTrainsProblemThree
{
    public class Node : INode
    {
        // Private member-variables
        private string _nodeName;
        private int _distance;
        private List<Edge> _neighbors;

        public Node(string nodeName)
        {
            _nodeName = nodeName;
            _neighbors = new List<Edge>();
        }

        public string NodeName
        {
            get
            {
                return _nodeName;
            }
        }
        public int Distance
        {
            get
            {
                return _distance;
            }
            set
            {
                _distance = value;
            }
        }
        public override int GetHashCode()
        {
            return NodeName.GetHashCode();
        }
        public int NumbersOfNeighbours
        {
            get
            {
                return _neighbors.Count();
            }

        }


        /// <summary>
        /// This method exposes the abbility to add an edge to and information to a node connected by this edge
        /// </summary>
        /// <param name="neightbor"></param>
        public void AddNeighborNode(Edge neightbor)
        {
            var isEdgeAlreadyInList = _neighbors.Contains(neightbor);
            if (!isEdgeAlreadyInList)
            {
                _neighbors.Add(neightbor);
            }
        }
        /// <summary>
        /// override the equals method 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this.NodeName.Equals(((Node)obj).NodeName, StringComparison.CurrentCultureIgnoreCase);
        }
        /// <summary>
        /// Override the compare to method. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            return this.NodeName.ToUpper().CompareTo(((Node)obj).NodeName.ToUpper());
        }
        /// <summary>
        /// return all the edges connected to this node.
        /// </summary>
        /// <returns></returns>
        public List<Edge> ListOfAllEdgesConnectedToThisNode()
        {
            return _neighbors;
        }
    }

}
