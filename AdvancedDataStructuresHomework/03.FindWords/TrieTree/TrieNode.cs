namespace FindWords.TrieTree
{
    using System.Collections.Generic;

    public class TrieNode
    {
        public TrieNode(char nodeValue)
        {
            this.Value = nodeValue;
            this.SubNodes = new Dictionary<char, TrieNode>();
        }

        public TrieNode(char nodeValue, bool isEndOfWord)
            : this(nodeValue)
        {
            this.IsEndOfWord = isEndOfWord;
        }

        public char Value { get; set; }

        public bool IsEndOfWord { get; set; }

        public IDictionary<char, TrieNode> SubNodes { get; set; }

        public TrieNode GetChild(char searchValue)
        {
            if (this.SubNodes.ContainsKey(searchValue))
            {
                return this.SubNodes[searchValue];
            }

            return null;
        }
    }
}
