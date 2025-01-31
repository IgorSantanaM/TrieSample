using System.Diagnostics.Tracing;
using TrieSample;

var trie = new Trie();
trie.Insert(word: "cat");
trie.Insert(word: "can");
trie.Insert(word: "canada");
trie.Contains(word: "canada");
trie.Tranverse();

