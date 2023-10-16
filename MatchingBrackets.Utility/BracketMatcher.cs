namespace MatchingBrackets.Utility
{
    public class BracketMatcher : IBracketMatcher
    {
        private readonly Dictionary<char, char> _matchingBracketParis;

        public BracketMatcher()
        {
            this._matchingBracketParis = BracketMatchingCollection.BracketPairs;
        }

        public bool HasMatchingBracket(string strInput)
        {
            var stack = new Stack<char>();

            foreach (var item in strInput)
            {
                if (this._matchingBracketParis.ContainsKey(item))
                {
                    stack.Push(item);
                }
                else if (this._matchingBracketParis.ContainsValue(item))
                {
                    if (stack.Count == 0 || (this._matchingBracketParis[stack.Peek()] != item))
                    {
                        return false;
                    }
                    stack.Pop();
                }
            }

            return stack.Count == 0;
        }
    }
}
