using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOnTrainsProblemThree
{
    public class Graphs
    {


        public Graphs()
        {
            _vertexes = new List<Node>();
        }
        private List<Node> _vertexes;

        public void AddNode(Node node)
        {
            var isNodeConainedInList = _vertexes.Contains(node);
            if (!isNodeConainedInList)
            {
                _vertexes.Add(node);
            }

        }

        private string PrintStack(Stack<Node> path)
        {
            StringBuilder builder = new StringBuilder();
            foreach (Node item in path)
            {
                builder.Append(item.NodeName);
                builder.Append(",");
            }

            return builder.ToString();
        }

        private bool IsThereAnyUnvisitedNode(List<Edge> edges)
        {
            return edges.Any(d => !d.Visited);
        }

        private LinkedList<Node> ConvertListToLinkedList(List<Node> ajacentList)
        {
            var linkedList = new LinkedList<Node>();
            foreach (Node node in ajacentList)
            {
                linkedList.AddLast(node);
            }
            return linkedList;
        }
        public List<Node> Vertexes
        {
            get { return _vertexes; }
        }

        public Node FindNode(string nodeName)
        {
            return _vertexes.FirstOrDefault(f => f.NodeName.Equals(nodeName));
        }

        public void addEdgeToNode(Node node, Edge edge)
        {
            var nodeFound = FindNode(node.NodeName);
            nodeFound?.AddNeighborNode(edge);
        }

        public bool IsNodeInGraph(Node node)
        {
            return _vertexes.Contains(node);
        }


        public void PrintGraph()
        {
            //
            foreach (Node node in _vertexes)
            {
                Console.Write($"--{node.NodeName}");
                HelperMethodForAdjacentList(node.ListOfAllEdgesConnectedToThisNode());
            }
        }

        private void HelperMethodForAdjacentList(List<Edge> neightbors)
        {
            neightbors.ForEach(n => Console.Write($"-{n.Weight}->{n.Destination.NodeName}"));
        }




        private void printPath(LinkedList<Node> visited)
        {
            foreach (Node node in visited)
            {
                Console.Write(node.NodeName);
            }
        }

        private List<string> AllPathFromNode(Node source, Node destination, int maxStop)
        {

            List<string> seenPath = new List<string>();
            List<string> foundPath = new List<string>();

            var adjancentList = source.ListOfAllEdgesConnectedToThisNode();

            foreach (Edge edge in adjancentList)
            {
                int counter = 1;
                var currentPath = source.NodeName;
                var sourceNode = edge.Destination;
                var nodeToVisit = new Stack<Node>();
                nodeToVisit.Push(source);

                while (nodeToVisit.Count != 0 || counter == 1)
                {

                    if (!seenPath.Contains(currentPath + sourceNode.NodeName) && counter <= maxStop)
                    {
                        currentPath += sourceNode.NodeName;

                        seenPath.Add(currentPath);

                        var nodeFound = sourceNode.Equals(destination);

                        if (nodeFound)
                        {
                            foundPath.Add(currentPath);
                        }
                        var currentSourceUnseenAjacentNode = sourceNode.ListOfAllEdgesConnectedToThisNode().Where(x => !seenPath.Contains(currentPath + x.Destination.NodeName)).FirstOrDefault();
                        nodeToVisit.Push(sourceNode);
                        if (currentSourceUnseenAjacentNode != null)
                        {
                            sourceNode = currentSourceUnseenAjacentNode.Destination;
                        }
                        counter++;
                    }
                    else
                    {
                        sourceNode = nodeToVisit.Pop();
                        currentPath = currentPath.Length == 1 ? currentPath : currentPath.Substring(0, currentPath.Length - 1);
                        counter--;
                    }


                }

            }
            return foundPath;
        }
        public int DijstraAlgorithmShortestPath(string source, string destination)
        {

            var sourceNode = FindNode(source.ToUpper().Trim());
            var destinationNode = FindNode(destination.ToUpper().Trim());
            var visitedStack = new Stack<Node>();
            sourceNode.Distance = 0;
            visitedStack.Push(sourceNode);
            while (visitedStack.Count > 0)
            {
                //set all adjacent nodes distamce to int max 
                var allDirectEdgesToSource = sourceNode.ListOfAllEdgesConnectedToThisNode();

                foreach (Edge edge in allDirectEdgesToSource)
                {
                    edge.Destination.Distance = Math.Min((sourceNode.Distance + edge.Weight), edge.Destination.Distance);
                }

                var smallestEdgeNotVisited = sourceNode.ListOfAllEdgesConnectedToThisNode().Where(x => !x.Visited).OrderBy(t => t.Weight).FirstOrDefault();
                if (smallestEdgeNotVisited != null)
                {
                    smallestEdgeNotVisited.Visited = true;
                    visitedStack.Push(smallestEdgeNotVisited.Destination);
                    sourceNode = smallestEdgeNotVisited.Destination;
                }
                else
                {
                    sourceNode = visitedStack.Pop();
                }
            }

            return destinationNode.Distance;
        }

        public List<string> FindPathWithMaxDistance(string source, string destination, int maxStopOrMaxDistance, bool isMaxDistance = false)
        {

            try
            {
                List<string> allPaths = new List<string>();
                string pathFound = string.Empty;
                var sourceNode = FindNode(source.ToUpper().Trim());
                var destinationNode = FindNode(destination.ToUpper().Trim());

                if (sourceNode == null || destination == null)
                {
                    //return 0 for this routes is both the source and destination is null
                    return allPaths;
                }
                if (isMaxDistance)
                {
                    allPaths = FindPathWithMaxDistanceAlgorithm(sourceNode, destinationNode, maxStopOrMaxDistance);
                }
                else
                {
                    allPaths = allPaths = AllPathFromNode(sourceNode, destinationNode, maxStopOrMaxDistance);
                }


                return allPaths;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong performing this task this is sample of the issue {ex.Message}");
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }
        private List<string> FindPathWithMaxDistanceAlgorithm(Node source, Node destination, int maxDiatance)
        {

            List<string> seenPath = new List<string>();
            List<string> foundPath = new List<string>();
            int currentDistance = 0;
            var adjancentList = source.ListOfAllEdgesConnectedToThisNode();

            foreach (Edge edge in adjancentList)
            {
                int sourceNodeEdgeDistance = edge.Weight;
                int previouseWeight = 0;
                int counter = 1;
                var currentPath = source.NodeName;
                var sourceNode = edge.Destination;
                var nodeToVisit = new Stack<Node>();
                nodeToVisit.Push(source);

                while (nodeToVisit.Count != 0 || counter == 1)
                {

                    if (!seenPath.Contains(currentPath + sourceNode.NodeName) && currentDistance <= maxDiatance)
                    {
                        currentPath += sourceNode.NodeName;
                        currentDistance += sourceNodeEdgeDistance;
                        seenPath.Add(currentPath);

                        var nodeFound = sourceNode.Equals(destination);

                        if (nodeFound)
                        {
                            foundPath.Add(currentPath);
                        }
                        var currentSourceUnseenAjacentNode = sourceNode.ListOfAllEdgesConnectedToThisNode().Where(x => !seenPath.Contains(currentPath + x.Destination.NodeName)).FirstOrDefault();
                        nodeToVisit.Push(sourceNode);
                        if (currentSourceUnseenAjacentNode != null)
                        {
                            sourceNode = currentSourceUnseenAjacentNode.Destination;
                            previouseWeight = sourceNodeEdgeDistance;
                            sourceNodeEdgeDistance = currentSourceUnseenAjacentNode.Weight;
                        }
                        counter++;
                    }
                    else
                    {
                        sourceNode = nodeToVisit.Pop();
                        currentPath = currentPath.Length == 1 ? currentPath : currentPath.Substring(0, currentPath.Length - 1);
                        counter--;
                        currentDistance -= previouseWeight;
                    }


                }

            }
            return foundPath;
        }
    }
}
