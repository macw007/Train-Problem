namespace DealerOnTrainsProblemThree
{
    public class Edge : IEdge
    {
        private Node _destination;
        private int _weight;
        private bool _visited;
        public Node Destination
        {
            get
            {
                return _destination;
            }
          
        }
        public int Weight
        {
            get { return _weight; }
        }

        public Edge(Node destination,int weight)
        {
            _destination = destination;
            _weight = weight;
            _visited = false;
        }

        public bool Visited { get { return _visited; } set { _visited = value; } }
        public override int GetHashCode()
        {
            return Destination.NodeName.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var destination = ((Edge)obj);

            if(Destination.NodeName.Equals(destination.Destination.NodeName))
            {
                return true;
            }
            return false;
        }

    }
}