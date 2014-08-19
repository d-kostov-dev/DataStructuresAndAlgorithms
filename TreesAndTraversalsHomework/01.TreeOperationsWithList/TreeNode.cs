namespace TreeOperationsWithList
{
    using System.Collections.Generic;

    public class TreeNode<ValueType>
    {
        public TreeNode()
        {
            this.Children = new List<TreeNode<ValueType>>();
        }

        public TreeNode(ValueType value)
            : this()
        {
            this.Value = value;
        }

        public bool HasParent { get; set; }

        public ValueType Value { get; set; }

        public IList<TreeNode<ValueType>> Children { get; set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
