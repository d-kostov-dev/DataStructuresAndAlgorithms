namespace FriendsOfPesho
{
    using System;

    public class Node : IComparable<Node>
    {
        public Node(int nodeName, int distance)
        {
            this.Name = nodeName;
            this.DijktraDistance = distance;
        }

        public int Name { get; set; }

        public int DijktraDistance { get; set; }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Node);
        }

        public bool Equals(Node other)
        {
            return this.Name.Equals(other.Name);
        }

        public int CompareTo(Node other)
        {
            return this.DijktraDistance.CompareTo(other.DijktraDistance);
        }
    }
}
