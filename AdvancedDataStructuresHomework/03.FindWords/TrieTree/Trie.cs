namespace FindWords.TrieTree
{
    using System.Collections.Generic;
    using System.Text;

    public class Trie
    {
        private List<string> subsequentStrings;
        private IDictionary<string, int> wordsOccurenceCount;

        public Trie()
        {
            this.Root = new TrieNode(' ');
            this.subsequentStrings = new List<string>();
            this.wordsOccurenceCount = new Dictionary<string, int>();
        }

        public TrieNode Root { get; private set; }

        public void AddWord(string inputWord)
        {
            CountCheck(inputWord);

            char[] charsToAdd = inputWord.ToCharArray();
            TrieNode currentNode = this.Root;
            TrieNode childNode = null;

            for (int i = 0; i < charsToAdd.Length; i++)
            {
                char currentChar = inputWord[i];
                childNode = currentNode.GetChild(currentChar);

                if (childNode == null)
                {
                    var newNode = new TrieNode(currentChar);
                    currentNode.SubNodes.Add(currentChar, newNode);
                    currentNode = newNode;
                }
                else
                {
                    currentNode = childNode;
                }
                    
                if (i == charsToAdd.Length - 1)
                {
                    currentNode.IsEndOfWord = true;
                }
                    
            }
        }

        public bool WordExists(string searchQuery)
        {
            char[] charsToSearch = searchQuery.ToCharArray();
            TrieNode currentNode = this.Root;
            TrieNode child = null;

            for (int i = 0; i < charsToSearch.Length; i++)
            {
                child = currentNode.GetChild(charsToSearch[i]);

                if (child == null)
                {
                    return false;
                }
                    
                currentNode = child;
            }

            return true;
        }

        public List<string> GetMatches(string query)
        {
            StringBuilder sbPrevious = new StringBuilder();
            char[] chars = query.ToCharArray();
            TrieNode currentNode = this.Root;
            TrieNode child = null;

            for (int i = 0; i < chars.Length; i++)
            {
                if (i < chars.Length - 1)
                {
                    sbPrevious.Append(chars[i]);
                }
                    
                child = currentNode.GetChild(chars[i]);

                if (child == null)
                {
                    break;
                }
                    
                currentNode = child;
            }

            subsequentStrings.Clear();

            GenerateSubsequentStrings(currentNode, sbPrevious.ToString());

            return subsequentStrings;
        }

        public  int GetWordOccurrenceCount(string word)
        {
            if (this.wordsOccurenceCount.ContainsKey(word))
            {
                return this.wordsOccurenceCount[word];
            }

            return 0;
        }

        private void GenerateSubsequentStrings(TrieNode node, string subsequentString)
        {
            if (node == null)
            {
                return;
            }
                
            subsequentString = subsequentString + node.Value;

            if (node.IsEndOfWord)
            {
                subsequentStrings.Add(subsequentString);
            }

            foreach (var subnode in node.SubNodes)
            {
                GenerateSubsequentStrings(subnode.Value, subsequentString);
            }
                
        }

        private void CountCheck(string inputWord)
        {
            if (!(this.wordsOccurenceCount.ContainsKey(inputWord)))
            {
                this.wordsOccurenceCount.Add(inputWord, 0);
            }

            this.wordsOccurenceCount[inputWord]++;
        }
    }
}
