using System.Reflection.Metadata;
using NUnit.Framework.Internal;

namespace TestProject1;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]

    [TestCase (1,1)]
    [TestCase (1,2)]
    [TestCase (2,3)]
    [TestCase (3,4)]
    [TestCase (5,5)]
    [TestCase (8,6)]
    [TestCase (13,7)]
    public void PozitifIndextestleri(int expected, int index)
    {
        Fibonacci  fibonacciGenerator = new Fibonacci () ;
        Assert.AreEqual (expected, fibonacciGenerator.getFibonacci(index));
    }

    [Test]
    [TestCase (701408733,44)]
    [Timeout (200)]
    public void HizTesti(int expected, int index)
    {
        Fibonacci  fibonacciGenerator = new Fibonacci () ;
        Assert.AreEqual (expected, fibonacciGenerator.getFibonacci(index));
    }

[Test]
[TestCase(48)]             // 48 için test, sınır aşımı bekleniyor
[TestCase(-1)]             // Negatif index olmaz
public void GecerliIndexTesti(int index)
{
    Fibonacci fibonacciGenerator = new Fibonacci();

    if (index == index) 
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            fibonacciGenerator.getFibonacci(index);
        });
    }

}


}


internal class Fibonacci
{
private Dictionary<int, int> memo = new Dictionary<int, int>();



internal int calculateFibonacci(int v)
{
    if (v < 3) return 1;

    if (memo.ContainsKey(v)) return memo[v];

    int result = getFibonacci(v - 1) + getFibonacci(v - 2);
    memo[v] = result;

    return result;
}

internal void checkIftheIndexIsValid(int v)
{
    if (v >= 48 || v <= 0 ) throw new ArgumentOutOfRangeException();
}

internal int getFibonacci(int v)
{

    checkIftheIndexIsValid(v); 
    
    return calculateFibonacci(v) ;

}
}