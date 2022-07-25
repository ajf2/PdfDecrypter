using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfDecrypter {
  public class BruteForcePasswordIterator : IEnumerable<string> {
    private static IEnumerable<char> numberRange = Enumerable.Range('0', 10).Select(i => (char)i);
    private static IEnumerable<char> upperCaseRange = Enumerable.Range('A', 26).Select(i => (char)i);
    private static IEnumerable<char> lowerCaseRange = Enumerable.Range('a', 26).Select(i => (char)i);
    private static IEnumerable<char> characterRange = numberRange.Concat(upperCaseRange).Concat(lowerCaseRange);

    public int PasswordAttempts { get; private set; } = 0;

    public IEnumerator<string> GetEnumerator() {
      foreach(var c1 in characterRange) {
        foreach (var c2 in characterRange) {
          foreach (var c3 in characterRange) {
            foreach (var c4 in characterRange) {
              PasswordAttempts++;
              yield return $"{c1}{c2}{c3}{c4}";
            }
          }
        }
      }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
  }
}
