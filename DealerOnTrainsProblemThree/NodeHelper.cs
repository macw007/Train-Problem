using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOnTrainsProblemThree
{
    public class NodeHelper
    {

        public Node Vector { get; set; }

        public int DistancefromSourceToVector { get; set; }

        public NodeHelper(Node vector,int distance)
        {
            this.Vector = vector;
            this.DistancefromSourceToVector = distance;
        }

        

    }
}
