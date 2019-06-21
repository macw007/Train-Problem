using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOnTrainsProblemThree
{
    public class DirectedGraph
    {
        private Graphs _graph;
        public DirectedGraph()
        {
            _graph = new Graphs();
        }


        /// <summary>
        /// This method creates the gragh to be used in the problem 
        /// </summary>
        /// <param name="Input"></param>
        public void CreateGrapgh(string Input)
        {
            try
            {
                var inputSplit = Input.Replace(" ", "").ToUpper().Trim().Split(',');
                if (inputSplit.ToList().All(s => s.Length >= 3))
                {

                    for (int i = 0; i < inputSplit.Length; i++)
                    {
                        string[] myStringArray = inputSplit[i].Select(x => x.ToString())
                                         .ToArray();

                        var weight = Convert.ToInt32(myStringArray[2]);
                        var nodeName = myStringArray[0];
                        var destinatitonNodeName = myStringArray[1];

                        var sourceNode = _graph.FindNode(nodeName);
                        sourceNode = sourceNode ?? new Node(nodeName);

                        var destinationNode = _graph.FindNode(destinatitonNodeName);
                        destinationNode = destinationNode ?? new Node(destinatitonNodeName);


                        var edge = new Edge(destinationNode, weight);

                        _graph.AddNode(sourceNode);
                        _graph.AddNode(destinationNode);
                        _graph.addEdgeToNode(sourceNode, edge);

                    }
                }
                else
                {
                    throw new Exception($"The input provide in one of the parameters was not in correct Format as expected ");
                }

                foreach (Node nodes in _graph.Vertexes)
                {
                    nodes.Distance = int.MaxValue;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"an error occored while creating the Graph {ex.Message}");
            }
        }
        /// <summary>
        /// This method calculates all paths in a graph from the source node to the destination node 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="maxStop"></param>
        /// <param name="isExact"></param>
        /// <returns></returns>
        public int CalculateNumbersOfRoute(string source, string destination, int maxStop, bool isExact)
        {
            int itemResult = 0;
            var result = _graph.FindPathWithMaxDistance(source, destination, maxStop);
            if (!isExact)
            {
                itemResult = result.Count();
            }
            else
            {
                itemResult = result.Where(x => x.Length == (maxStop + 1)).Count();
            }


            return itemResult;
        }

        public int CalulateAllRoutesWithMaxDistance(string source, string destination, int maxDistance)
        {
            var result = _graph.FindPathWithMaxDistance(source, destination, maxDistance, true);

            return result.Count();
        }

        public string DistanceOfRoute(string input)
        {
            var result = CalculateDistanceOfRoute(input);

            return result < 0 ? " NO SUCH ROUTE " : result.ToString();
        }
        /// <summary>
        /// This method calculates the distance on a path 
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        private int CalculateDistanceOfRoute(string Input)
        {
            var inputString = Input.Replace(" ", "").ToUpper().Trim().Split('-');
            Node lookedAtNode = null;
            int distance = 0;
            if (inputString.Length < 2)
            {
                return distance; //There is an edge of zero for this route.
            }
            else
            {

                lookedAtNode = _graph.FindNode(inputString[0]);
                if (lookedAtNode == null)
                {
                    return int.MinValue;
                }
                for (int i = 1; i < inputString.Length; i++)
                {
                    var edges = lookedAtNode.ListOfAllEdgesConnectedToThisNode().Where(e => e.Destination.NodeName.Equals(inputString[i])).FirstOrDefault();
                    if (edges != null)
                    {
                        distance += edges.Weight;
                        lookedAtNode = edges.Destination;
                    }
                    else
                    {
                        return int.MinValue;
                    }

                }
            }
            return distance;
        }

        public int ShortestPathBetweenTwoNodes(string source, string destination)
        {
            return _graph.DijstraAlgorithmShortestPath(source, destination);
        }
    }
}
