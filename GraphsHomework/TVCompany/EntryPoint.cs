namespace TVCompany
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EntryPoint
    {
        public static void Main()
        {
            int numberOfNodes = int.Parse(Console.ReadLine());
            List<Edge> edges = new List<Edge>();

            GetEdgesInput(edges, numberOfNodes);
            edges.Sort();

            int[] tree = new int[numberOfNodes + 1]; //we start from 1, not from 0
            var mpd = new List<Edge>();
            int treesCount = 1;

            treesCount = FindMinimumSpanningTree(edges, tree, mpd, treesCount);

            PrintMinimumSpanningTree(mpd);
        }

        private static void PrintMinimumSpanningTree(IEnumerable<Edge> mpdNodes)
        {
            long edgesSum = 0;

            foreach (Edge edge in mpdNodes)
            {
                //Console.WriteLine(edge);
                edgesSum += edge.Weight;
            }

            Console.WriteLine(edgesSum);
        }

        private static int FindMinimumSpanningTree(List<Edge> edges, int[] tree, List<Edge> mpd, int treesCount)
        {
            foreach (var edge in edges)
            {
                if (tree[edge.StartNode] == 0) // not visited
                {
                    if (tree[edge.EndNode] == 0) // both ends are not visited
                    {
                        tree[edge.StartNode] = tree[edge.EndNode] = treesCount;
                        treesCount++;
                    }
                    else
                    {
                        // attach the start node to the tree of the end node
                        tree[edge.StartNode] = tree[edge.EndNode];
                    }
                    mpd.Add(edge);
                }
                else // the start is part of a tree
                {
                    if (tree[edge.EndNode] == 0)
                    {
                        //attach the end node to the tree;
                        tree[edge.EndNode] = tree[edge.StartNode];
                        mpd.Add(edge);
                    }
                    else if (tree[edge.EndNode] != tree[edge.StartNode]) // combine the trees
                    {
                        int oldTreeNumber = tree[edge.EndNode];

                        for (int i = 0; i < tree.Length; i++)
                        {
                            if (tree[i] == oldTreeNumber)
                            {
                                tree[i] = tree[edge.StartNode];
                            }
                        }
                        mpd.Add(edge);
                    }
                }
            }
            return treesCount;
        }

        private static void GetEdgesInput(IList<Edge> edges, int numberOfNodes)
        {
            for (int i = 0; i < numberOfNodes; i++)
            {
                var currentEdgeInfo = Console.ReadLine()
                                   .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(s => int.Parse(s.Trim()))
                                   .ToArray();

                edges.Add(new Edge(currentEdgeInfo[0], currentEdgeInfo[1], currentEdgeInfo[2]));
            }
        }
    }

    public class Edge : IComparable<Edge>
    {
        public Edge(int startNode, int endNode, int weight)
        {
            this.StartNode = startNode;
            this.EndNode = endNode;
            this.Weight = weight;
        }

        public int StartNode { get; set; }

        public int EndNode { get; set; }

        public int Weight { get; set; }

        public int CompareTo(Edge other)
        {
            int weightCompared = this.Weight.CompareTo(other.Weight);

            if (weightCompared == 0)
            {
                return this.StartNode.CompareTo(other.StartNode);
            }

            return weightCompared;
        }

        public override string ToString()
        {
            return string.Format("({0} {1}) -> {2}", this.StartNode, this.EndNode, this.Weight);
        }
    }
}
