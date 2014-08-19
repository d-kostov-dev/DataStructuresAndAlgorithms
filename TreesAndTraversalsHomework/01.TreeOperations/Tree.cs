namespace TreeOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Abstract tree class. Creates a tree with easy adding of nodes that are auto placed under their parents if there are any. Currently works with tree with only one root.
    /// </summary>
    /// <typeparam name="KeyType">Type of the key for the tree.</typeparam>
    /// <typeparam name="ValueType">Type of the value for each node.</typeparam>
    public class Tree<KeyType, ValueType>
    {
        private IDictionary<KeyType, TreeNode<ValueType>> nodesTree;

        public Tree()
        {
            this.nodesTree = new Dictionary<KeyType, TreeNode<ValueType>>();
        }

        /// <summary>
        /// Gets or sets the current nodes count. Used every time when a new node is added in the tree.
        /// </summary>
        public int NodesCount { get; set; }

        /// <summary>
        /// Returns the connections count for the hole tree.
        /// </summary>
        public int ConnectionsCount
        {
            get
            {
                return this.NodesCount - 1;
            }
        }

        /// <summary>
        /// Returns the root node of the tree. The class works only for trees with one root.
        /// </summary>
        public TreeNode<ValueType> RootNode
        {
            get
            {
                return this.nodesTree.First().Value;
            }
        }

        /// <summary>
        /// Returns the longest path in the tree.
        /// </summary>
        public int GetLongestPath
        {
            get
            {
                return this.LongestPathCount(this.RootNode);
            }
        }

        /// <summary>
        /// Adds a node to the tree.
        /// </summary>
        /// <param name="parentNodeKey">Parent node key.</param>
        /// <param name="parentNodeValue">Parent node value.</param>
        /// <param name="childNodeKey">Child node key.</param>
        /// <param name="childNodeValue">Child node value.</param>
        public void AddNode(KeyType parentNodeKey, ValueType parentNodeValue, KeyType childNodeKey, ValueType childNodeValue)
        {
            var parentNode = this.FindNode(parentNodeKey);

            // If no parent node is found we add it to the tree.
            if (parentNode == null)
            {
                this.nodesTree.Add(parentNodeKey, new TreeNode<ValueType>(parentNodeValue));
                parentNode = this.nodesTree[parentNodeKey];
                this.NodesCount++;
            }

            var childNode = this.FindNode(childNodeKey);

            // If the child node is not found in the tree it's created and added to its parent.
            if (childNode == null)
            {
                childNode = new TreeNode<ValueType>(childNodeValue);
                this.NodesCount++;
            }

            parentNode.Children.Add(childNode);
            childNode.HasParent = true;

            // If the child node was already created (was root) 
            // and now has parent it's deleted from the tree (not root anymore)
            this.nodesTree.Remove(childNodeKey);
        }

        /// <summary>
        /// Gets all leafs of the tree.
        /// </summary>
        /// <returns>A list holding all leafs.</returns>
        public IList<TreeNode<ValueType>> GetAllLeafs()
        {
            var leafsList = new List<TreeNode<ValueType>>();

            leafsList.AddRange(this.GetLeafsForNode(this.RootNode));

            return leafsList;
        }

        /// <summary>
        /// Returns all nodes that have children and parent at the same time.
        /// </summary>
        /// <returns>A list holding all nodes with children and parent.</returns>
        public IList<TreeNode<ValueType>> GetAllMiddleNodes()
        {
            var middleNodesList = new List<TreeNode<ValueType>>();

            middleNodesList.AddRange(this.GetMiddleNodes(this.RootNode));

            return middleNodesList;
        }

        /// <summary>
        /// Calculates the longest path in the tree. Using recursion.
        /// </summary>
        /// <param name="parentNode">The starting node is the root node.</param>
        /// <returns>The longest path nodes count. Integer.</returns>
        private int LongestPathCount(TreeNode<ValueType> parentNode)
        {
            int maxPath = 0;
            foreach (var node in parentNode.Children)
            {
                maxPath = Math.Max(maxPath, this.LongestPathCount(node));
            }

            return maxPath + 1;
        }

        /// <summary>
        /// Used by the public method GetAllMiddleNodes, this method uses recursion trough all nodes in the tree 
        /// and adds in the list the nodes that have children. 
        /// We are starting from the root so the nodes alwyas have parent.
        /// </summary>
        /// <param name="parentNode">The starting node. First call with RootNode.</param>
        /// <returns>List of all nodes.</returns>
        private IList<TreeNode<ValueType>> GetMiddleNodes(TreeNode<ValueType> parentNode)
        {
            var middleNodes = new List<TreeNode<ValueType>>();

            if (parentNode.Children.Count > 0)
            {
                // If the current node has children and it's not the RootNode, it's added in the list.
                if (parentNode != this.RootNode)
                {
                    middleNodes.Add(parentNode);
                }
                
                foreach (var node in parentNode.Children)
                {
                    // Recursively call the same method to get all other nodes that meet the criteria.
                    middleNodes.AddRange(this.GetMiddleNodes(node));
                }
            }

            return middleNodes;
        }
        
        /// <summary>
        /// Used by the public method GetAllLeafs, this method uses recursion trough all nodes in the tree 
        /// and adds in the list the nodes that have no children. 
        /// We are starting from the root so the nodes alwyas have parent.
        /// </summary>
        /// <param name="parentNode">The starting node. First call with RootNode.</param>
        /// <returns>List of all nodes.</returns>
        private IList<TreeNode<ValueType>> GetLeafsForNode(TreeNode<ValueType> parentNode)
        {
            var childsList = new List<TreeNode<ValueType>>();

            if (parentNode.Children.Count > 0)
            {
                foreach (var node in parentNode.Children)
                {
                    childsList.AddRange(this.GetLeafsForNode(node));
                }
            }
            else
            {
                // If the node has no children (leaf) we add it to the list.
                childsList.Add(parentNode);
            }

            return childsList;
        }

        /// <summary>
        /// Finds a node by it's key. If the node is not found we search all children in the existing tree.
        /// </summary>
        /// <param name="nodeInfo">The node key we are searching for.</param>
        /// <returns>The node if it's found or null.</returns>
        private TreeNode<ValueType> FindNode(KeyType nodeInfo)
        {
            if (this.nodesTree.ContainsKey(nodeInfo))
            {
                return this.nodesTree[nodeInfo];
            }
            else
            {
                // If the current node does not exists in the main tree look for all children.
                foreach (var node in this.nodesTree)
                {
                    return this.SearchNodeInChildren(node.Value, nodeInfo);
                }
            }

            return null;
        }

        /// <summary>
        /// Looks in all children and their children for a node by it's key/value.
        /// </summary>
        private TreeNode<ValueType> SearchNodeInChildren(TreeNode<ValueType> parentNode, KeyType nodeToFind)
        {
            if (parentNode.Value.Equals(nodeToFind))
            {
                return parentNode;
            }

            if (parentNode.Children.Count > 0)
            {
                foreach (var childNode in parentNode.Children)
                {
                    var foundNode = this.SearchNodeInChildren(childNode, nodeToFind);

                    // If a node is found we break the recursion and return it.
                    if (foundNode != null)
                    {
                        return foundNode;
                    }
                }

                return null;
            }

            return null;
        }
    }
}
