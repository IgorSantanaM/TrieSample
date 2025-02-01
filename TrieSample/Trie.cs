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
                return children[ch];
            }

            public Node[] GetChildren()
            {
                return children.Values.ToArray();
            }

            public void RemoveChild(char ch)
            {
                children.Remove(ch);
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

        private void Tranverse(Node nRoot)
        {
            // Use memo for large words.
            foreach (var child in nRoot.GetChildren())
                Tranverse(child);

            Console.WriteLine(nRoot.value);
        }

        public void Remove(string word)
        {
            if (word is null) return;
            Remove(root, word, index: 0);
        }
        private void Remove(Node root, string word, int index)
        {
            if(index  == word.Length)
            {
                root.isEndOfWord = false;
                return;
            }

            var ch = word[index];
            var child = root.GetChild(ch);

            if (child is null) return;

            Remove(child, word, index + 1);

            Console.WriteLine(root.value);

            if (child.GetChildren().Length == 0 && !child.isEndOfWord)
                root.RemoveChild(ch);
        }

        public List<string> FindWords(string prefix)
        {

            List<string> words = new();
            var lastNode = FindLastNodeOf(prefix);
            FindWords(lastNode, prefix, words);

            return words;
        }

        private void FindWords(Node root, string prefix, List<string> words)
        {
            if (root is null) return;

            if (root.isEndOfWord)
                words.Add(prefix);

            foreach (var child in root.GetChildren())
                FindWords(child, prefix + child.value, words);
        }

        private Node FindLastNodeOf(string prefix)
        {

            if (prefix is null) return null;
             
            var current = root;

            foreach (var ch in prefix.ToCharArray())
            {
               var child = current.GetChild(ch);
                if(child == null)
                    return null;
                current = child;
            }
            return current;
        }
    }
}
