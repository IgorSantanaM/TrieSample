using System.Diagnostics.Tracing;
using TrieSample;

var trie = new Trie();
trie.Insert(word: "cat");
trie.Insert(word: "can");
trie.Insert(word: "canada");
trie.Insert(word: "canado");
trie.Contains(word: "canada");
trie.Tranverse();
var words = trie.FindWords("ca");

Console.WriteLine(words);

trie.Remove(word: "cat");

