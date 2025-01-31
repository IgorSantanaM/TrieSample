using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrieSample
{
    public class Trie
    {
        public const int ALPHABET_SIZE = 26;

        private class Node
        {
            public char value;
            public Dictionary<char, Node> children = new();
            public bool isEndOfWord;

            public Node(char value)
            {
                this.value = value; 
            }

            public override string ToString()
            {
                return "value = " + value;
            }
            
            public bool HasChild(char ch)
            {
                return children.ContainsKey(ch);
            }

            public void AddChild(char ch)
            {
                children.Add(ch, new Node(value));
            } 

            public Node GetChild(char ch)
            {
                return children.GetValueOrDefault(ch);
            }

            public Node[] GetChildren()
            {
                return children.Values.ToArray();
            }
        }

        private Node root = new Node(value: ' ');
        public void Insert(string word)
        {
            var current = root;
            foreach (char ch in word.ToCharArray())
            {
                var index = ch - 'a';
                if (!current.HasChild(ch))
                    current.AddChild(ch);
                current = current.GetChild(ch);
            }
            current.isEndOfWord = true;
        }

        public bool Contains(string word)
        {
            if (word is null or "") return false;

            var current = root;

            foreach (char ch in word.ToCharArray())
            {
                if (!current.HasChild(ch)) return false;

                current = current.GetChild(ch);
            }
            return current.isEndOfWord;
        }

        public void Tranverse()
        {
            Tranverse(root);
        }
        private void Tranverse(Node root)
        {
            
            // Use memo for large words.
            foreach (var child in root.GetChildren()) 
                Tranverse(child);

    
        }
    }
}
