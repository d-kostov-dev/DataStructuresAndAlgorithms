namespace FriendsOfPesho
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EntryPoint
    {
        private static Dictionary<Node, List<Connection>> nodesGraph;
        private static int[] hospitalNodes;
        private static Dictionary<int, Node> nodeNames;

        public static void Main()
        {
            nodesGraph = new Dictionary<Node, List<Connection>>();
            GetInput();

            int bestPath = GetBestPath();
            Console.WriteLine(bestPath);
        }

        private static int GetBestPath()
        {
            int bestPath = int.MaxValue;

            for (int i = 0; i < hospitalNodes.Length; i++)
            {
                DijkstraAlgorithm(nodeNames[hospitalNodes[i]], nodesGraph);

                int currentSum = 0;

                foreach (var item in nodesGraph)
                {
                    if (!hospitalNodes.Contains(item.Key.Name))
                    {
                        currentSum += item.Key.DijktraDistance;
                    }
                }

                if (currentSum < bestPath)
                {
                    bestPath = currentSum;
                }
            }

            return bestPath;
        }

        private static void GetInput()
        {
            int[] initialParams = Console.ReadLine()
                                   .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(s => int.Parse(s.Trim()))
                                   .ToArray();

            int numberOfStreets = initialParams[1];

            hospitalNodes = Console.ReadLine()
                            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(s => int.Parse(s.Trim()))
                            .ToArray();

            nodeNames = new Dictionary<int, Node>();
            List<int[]> allParams = new List<int[]>();

            for (int i = 0; i < numberOfStreets; i++)
            {
                int[] currentNumbers = Console.ReadLine()
                                   .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(s => int.Parse(s.Trim()))
                                   .ToArray();

                allParams.Add(currentNumbers);

                if (!nodeNames.ContainsKey(currentNumbers[0]))
                {
                    nodeNames.Add(currentNumbers[0], new Node(currentNumbers[0], int.MaxValue));
                }

                if (!nodeNames.ContainsKey(currentNumbers[1]))
                {
                    nodeNames.Add(currentNumbers[1], new Node(currentNumbers[1], int.MaxValue));
                }
            }

            for (int i = 0; i < allParams.Count; i++)
            {
                int[] currentParams = allParams[i];

                if (nodesGraph.ContainsKey(nodeNames[currentParams[0]]))
                {
                    nodesGraph[nodeNames[currentParams[0]]].Add(new Connection(nodeNames[currentParams[1]], currentParams[2]));
                }
                else
                {
                    nodesGraph.Add(nodeNames[currentParams[0]], new List<Connection>() { new Connection(nodeNames[currentParams[1]], currentParams[2]) });
                }

                if (nodesGraph.ContainsKey(nodeNames[currentParams[1]]))
                {
                    nodesGraph[nodeNames[currentParams[1]]].Add(new Connection(nodeNames[currentParams[0]], currentParams[2]));
                }
                else
                {
                    nodesGraph.Add(nodeNames[currentParams[1]], new List<Connection>() { new Connection(nodeNames[currentParams[0]], currentParams[2]) });
                }
            }
        }

        public static void DijkstraAlgorithm(Node source, Dictionary<Node, List<Connection>> graph)
        {
            PriorityQ<Node> queue = new PriorityQ<Node>();

            foreach (var node in graph)
            {
                if (source.Name != node.Key.Name)
                {
                    node.Key.DijktraDistance = int.MaxValue;
                    queue.Enqueue(node.Key);
                }
            }

            source.DijktraDistance = 0;
            queue.Enqueue(source);

            while (queue.Count != 0)
            {
                Node currentNode = queue.Peek();

                if (currentNode.DijktraDistance == int.MaxValue)
                {
                    break;
                }

                foreach (var neighbour in graph[currentNode])
                {
                    int potDistance = currentNode.DijktraDistance + neighbour.Distance;

                    if (potDistance < neighbour.Node.DijktraDistance)
                    {
                        neighbour.Node.DijktraDistance = potDistance;
                        Node next = new Node(neighbour.Node.Name, potDistance);
                        queue.Enqueue(next);
                    }
                }

                queue.Dequeue();
            }
        }
    }
}