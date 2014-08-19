namespace TreeOperationsWithList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<ValueType>
    {
        private IList<TreeNode<ValueType>> treeNodes;

        public Tree()
        {
            this.treeNodes = new List<TreeNode<ValueType>>();
        }

        public int NodesCount
        {
            get
            {
                return this.treeNodes.Count;
            }
        }

        public void AddNode(ValueType parentNodeInfo, ValueType childNodeInfo)
        {
            TreeNode<ValueType> parentNode = null;
            
            int parentIndex = FindNodeIndex(parentNodeInfo);
            if (parentIndex > -1)
            {
                parentNode = this.treeNodes[parentIndex];
            }
            else
            {
                parentNode = new TreeNode<ValueType>(parentNodeInfo);
                this.treeNodes.Add(parentNode);
            }

            TreeNode<ValueType> childNode = null;

            int childIndex = FindNodeIndex(childNodeInfo);
            if (childIndex > -1)
            {
                childNode = this.treeNodes[childIndex];
            }
            else
            {
                childNode = new TreeNode<ValueType>(childNodeInfo);
                this.treeNodes.Add(childNode);
            }

            parentNode.Children.Add(childNode);
            childNode.HasParent = true;
        }

        public TreeNode<ValueType> FindRoot()
        {
            TreeNode<ValueType> rootNode = null;

            for (int i = 0; i < this.treeNodes.Count; i++)
            {
                var currentNode = this.treeNodes[i];

                if (currentNode.HasParent == false)
                {
                    return currentNode;
                }
            }

            return null;
        }

        public IList<TreeNode<ValueType>> FindLeafs()
        {
            IList<TreeNode<ValueType>> leafNodes = new List<TreeNode<ValueType>>();

            for (int i = 0; i < this.treeNodes.Count; i++)
            {
                var currentNode = this.treeNodes[i];

                if (currentNode.Children.Count <= 0)
                {
                    leafNodes.Add(currentNode);
                }
            }

            return leafNodes;
        }

        public IList<TreeNode<ValueType>> FindMiddleNodes()
        {
            IList<TreeNode<ValueType>> middleNodes = new List<TreeNode<ValueType>>();

            for (int i = 0; i < this.treeNodes.Count; i++)
            {
                var currentNode = this.treeNodes[i];

                if (currentNode.Children.Count > 0 && currentNode.HasParent)
                {
                    middleNodes.Add(currentNode);
                }
            }

            return middleNodes;
        }

        public int FindLongestPath(TreeNode<ValueType> startingNode)
        {
            if (startingNode.Children.Count == 0)
            {
                return 0;
            }

            int maxPath = 1;
            foreach (var node in startingNode.Children)
            {
                maxPath = Math.Max(maxPath, FindLongestPath(node));
            }

            return maxPath + 1;
        }

        private int FindNodeIndex(ValueType parentValue)
        {
            for (int i = 0; i < treeNodes.Count; i++)
            {
                var currentNode = treeNodes[i];

                if (currentNode.Value.Equals(parentValue))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
