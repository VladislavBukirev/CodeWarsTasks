using NUnit.Framework;

namespace CodeWars_Tasks
{
    public static class RangeExtraction
    {
        public static string Extract(int[] args)
        {
            var sequenceCounter = 0;
            var result = new LinkedList<string?>();
            var stack = new Stack<double>();
            foreach (var number in args)
            {
                var sequence = new LinkedList<string>();
                var other = new LinkedList<string>();
                if (stack.Count != 0)
                {
                    if (number != stack.First() + 1 && sequenceCounter == 2)
                        sequenceCounter = 0;
                    if (number == stack.First() + 1)
                    {
                        if (sequenceCounter == 0)
                        {
                            sequenceCounter = 2;
                            stack.Push(number);
                            continue;
                        }

                        if (sequenceCounter == 1)
                            sequenceCounter = 0;
                        else
                        {
                            sequenceCounter++;
                        }
                    }

                    if (number != stack.First() + 1 && sequenceCounter >= 3)
                    {
                        var last = stack.Pop();
                        sequenceCounter--;
                        while (sequenceCounter != 1)
                        {
                            stack.Pop();
                            sequenceCounter--;
                        }

                        sequence.AddLast(stack.Pop() + "-");
                        sequence.AddLast(last.ToString());
                        while (stack.Count != 0)
                        {
                            other.AddFirst(stack.Pop().ToString());
                        }

                        while (other.Count != 0)
                        {
                            result.AddLast(other.First());
                            result.AddLast(",");
                            other.RemoveFirst();
                        }

                        while (sequence.Count != 0)
                        {
                            result.AddLast(sequence.First());
                            sequence.RemoveFirst();
                        }

                        sequenceCounter = 0;
                        result.AddLast(",");
                        stack.Push(number);
                        continue;
                    }

                    if (number == args[^1] && sequenceCounter >= 3)
                    {
                        stack.Push(number);
                        var last = stack.Pop();
                        sequenceCounter--;
                        while (sequenceCounter != 1)
                        {
                            stack.Pop();
                            sequenceCounter--;
                        }

                        sequence.AddLast(stack.Pop() + "-");
                        sequence.AddLast(last.ToString());
                        while (stack.Count != 0)
                        {
                            other.AddFirst(stack.Pop().ToString());
                        }

                        while (other.Count != 0)
                        {
                            result.AddLast(other.First());
                            result.AddLast(",");
                            other.RemoveFirst();
                        }

                        while (sequence.Count != 0)
                        {
                            result.AddLast(sequence.First());
                            sequence.RemoveFirst();
                        }

                        sequenceCounter = 0;
                        continue;
                    }
                }

                stack.Push(number);
            }

            var a = "";
            if (stack.Count != 0)
            {
                while (stack.Count != 1)
                    result.AddFirst(stack.Pop().ToString());
                result.AddFirst(stack.Pop() + ",");
            }

            foreach (var str in result)
            {
                a += str;
            }

            return a;
        }
    }

    [TestFixture]
    public class RangeExtractorTest
    {
        [Test(Description = "Simple tests")]
        public void SimpleTests()
        {
            Assert.AreEqual("1,2", RangeExtraction.Extract(new[] { 1, 2 }));
            Assert.AreEqual("1-3", RangeExtraction.Extract(new[] { 1, 2, 3 }));

            Assert.AreEqual(
                "-6,-3-1,3-5,7-11,14,15,17-20",
                RangeExtraction.Extract(
                    new[] { -6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20 })
            );

            Assert.AreEqual(
                "-3--1,2,10,15,16,18-20",
                RangeExtraction.Extract(new[] { -3, -2, -1, 2, 10, 15, 16, 18, 19, 20 })
            );
        }
    }
}