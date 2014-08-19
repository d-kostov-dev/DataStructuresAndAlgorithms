namespace TreeOperations
{
    using System.Collections.Generic;

    public class TreeNode<T>
    {
        public TreeNode()
        {
            this.Children = new List<TreeNode<T>>();
        }

        public TreeNode(T value)
            : this()
        {
            this.Value = value;
        }

        public bool HasParent { get; set; }

        public T Value { get; set; }

        public IList<TreeNode<T>> Children { get; set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
