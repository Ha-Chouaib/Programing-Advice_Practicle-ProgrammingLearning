namespace _09_30_RemoveInvalidParentheses
{
    //[problem]
    /*
        Problem: Remove the minimum number of invalid parentheses to make the string valid.

        Example:
        Input: "(()))"
        Output: "()" or "(())"
     */
    internal class Program
    {

        //[Solution 1]
        static string ReturnValidParentheses(string input)
        {
            Stack<char> open = new Stack<char>();
            Stack<char> close = new Stack<char>();
            string OpenParentheses = "";
            string closeParentheses = "";
            foreach (char c in input)
            {
                if (c == '(')
                {
                    open.Push(c);
                }
                if (c == ')')
                {

                    close.Push(c);
                }
            }
            int diff = 0;
            if(open.Count > close.Count)
            {
                diff = open.Count - close.Count;
                while (diff > 0)
                {
                    open.Pop(); diff--;
                }
            }
            if (open.Count < close.Count)
            {
                diff = - open.Count + close.Count;
                while (diff > 0)
                {
                    close.Pop(); diff--;
                }
            }
            while(open.Count > 0)
            {
                OpenParentheses += open.Pop();
                closeParentheses += close.Pop();
            }

            return OpenParentheses + closeParentheses;
        }
        //[Solution 2]-(Optimized)
        static string RemoveInvalidParentheses(string s)
        {
            Stack<int> stack = new Stack<int>();
            HashSet<int> invalidIndices = new HashSet<int>();


            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else if (s[i] == ')')
                {
                    if (stack.Count == 0)
                    {
                        invalidIndices.Add(i);
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
            }


            while (stack.Count > 0)
            {
                invalidIndices.Add(stack.Pop());
            }


            char[] result = new char[s.Length - invalidIndices.Count];
            int index = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (!invalidIndices.Contains(i))
                {
                    result[index++] = s[i];
                }
            }


            return new string(result);
        }

        static void Main(string[] args)
        {
            string Input = "(((()))";

            Console.WriteLine($"Input:[{Input}].");
            Console.WriteLine($"Output:[{ReturnValidParentheses(Input)}].");
            Console.WriteLine($"Output:[{RemoveInvalidParentheses(Input)}].");
        }
    }
}
