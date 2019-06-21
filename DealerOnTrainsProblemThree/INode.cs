using System.Collections.Generic;

namespace DealerOnTrainsProblemThree
{
    public interface INode
    {
        void AddNeighborNode(Edge neightbor);
        int CompareTo(object obj);
        bool Equals(object obj);
        List<Edge> ListOfAllEdgesConnectedToThisNode();
    }
}