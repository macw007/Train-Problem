
using DealerOnTrainsProblemThree;
using NUnit.Framework;
using System;

namespace DealerOnTrainProblemThreeUnitTest
{
    [TestFixture]
    public class ProblemThreeUnitTest
    {

        private DirectedGraph _directedGraph = new DirectedGraph();

        [SetUp]
        public void buildGraph()
        {
            string graphInput = "AB5,BC4,CD8,DC8,DE6,AD5,CE2,Eb3,Ae7";
            _directedGraph.CreateGrapgh(graphInput);
        }

        [Test]
        public void Problem_one_Through_Five()
        {
            string path = " A-B-C";
            var result = _directedGraph.DistanceOfRoute(path);
            Assert.AreEqual("9", result);
        }
        //ShortestPathBetweenTwoNodes

        [Test]
        public void Problem_Six_Through_Seven()
        {
            string source = "A";
            string destination = "C";
            int maxStop = 4;
            var result = _directedGraph.CalculateNumbersOfRoute(source, destination, maxStop, true);
            Assert.AreEqual(3, result);
        }


        [Test]
        public void Problem_Eight_Through_Nine()
        {
            string source = "A";
            string destination = "C";
            var result = _directedGraph.ShortestPathBetweenTwoNodes(source, destination);
            Assert.AreEqual(9, result);
        }



        [Test]
        public void Problem_Ten()
        {
            string source = "C";
            string destination = "C";
            var result = _directedGraph.CalulateAllRoutesWithMaxDistance(source, destination, 30);
            Assert.AreEqual(7, result);
        }
    }
}
