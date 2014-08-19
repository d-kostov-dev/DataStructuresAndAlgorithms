namespace TreeOperationsWithList
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// You are given a tree of N nodes represented as a set of N-1 pairs of nodes (parent node, child node), 
    /// each in the range (0..N-1). 
    /// Write a program to read the tree and find: 
    /// a) the root node 
    /// b) all leaf nodes 
    /// c) all middle nodes 
    /// d) the longest path in the tree 
    /// e) * all paths in the tree with given sum S of their nodes 
    /// f) * all subtrees with given sum S of their nodes 
    /// </summary>
    public class EntryPoint
    {
        public static void Main()
        {
            var numberOfNodes = int.Parse(Console.ReadLine());
            var nodesTree = new Tree<int>();

            for (int i = 0; i < numberOfNodes - 1; i++)
            {
                string nodeInfo = Console.ReadLine();
                var nodeParts = nodeInfo.Split(' ');

                int parentNodeInfo = int.Parse(nodeParts[0]);
                int childNodeInfo = int.Parse(nodeParts[1]);

                nodesTree.AddNode(parentNodeInfo, childNodeInfo);
            }

            var rootNode = nodesTree.FindRoot();
            var leafNodes = nodesTree.FindLeafs();
            var middleNodes = nodesTree.FindMiddleNodes();
            int longestPath = nodesTree.FindLongestPath(rootNode);


            Console.WriteLine("Root node value: {0}", rootNode.Value);
            Console.WriteLine("Leafs values: {0}", string.Join(", ", leafNodes));
            Console.WriteLine("Middle nodes values: {0}", string.Join(", ", middleNodes));
            Console.WriteLine("Longest path contains: {0} nodes", longestPath);
        }
    }
}
