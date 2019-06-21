using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOnTrainsProblemThree
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<String> s = new LinkedList<String>();
            Console.WriteLine("Please enter the input for this problem in exact format as requirement provided");
            DirectedGraph dgraph = new DirectedGraph();
            var input = Console.ReadLine();
            dgraph.CreateGrapgh(input);
            Console.WriteLine("Calculate distance to a route by proviting route informat a-b-c ");
            var distance = Console.ReadLine();
            var result = dgraph.DistanceOfRoute(distance);
            Console.WriteLine(result);
            Console.WriteLine("Calculate all path between towns denoted as  source");
            var pathSource = Console.ReadLine();
            Console.WriteLine("Calculate all path between towns denoted as  source");
            var pathDestination = Console.ReadLine();
            Console.WriteLine("please input maximum no of stops as integer");
            dgraph.ShortestPathBetweenTwoNodes(pathSource, pathDestination);
            var maxstop = Console.ReadLine();
            var maxStopValue = Convert.ToInt32(maxstop);
            var resultpath = dgraph.CalculateNumbersOfRoute(pathSource, pathDestination, maxStopValue, false);
            Console.WriteLine(resultpath);
            Console.ReadLine();
        }
    }
}
