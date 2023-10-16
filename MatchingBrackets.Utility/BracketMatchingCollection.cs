namespace MatchingBrackets.Utility
{
    public class BracketMatchingCollection
    {

        private static readonly Dictionary<char, char>  _bracketPairCollection = new Dictionary<char, char>();

        /// <summary>
        /// In the context of a standard computer keyboard. 
        /// Here are the commonly known bracket characters: 
        /// * Angle Brackets '<' (open) '>' (close) 
        /// * Parentheses '(' (open) ')' (close) 
        /// * Square Brackets '[' (open) ']' (close)
        /// * Curly Braces '{' (open) '}' (close)
        /// </summary>
        static BracketMatchingCollection()
        {
            _bracketPairCollection.Add('<', '>');
            _bracketPairCollection.Add('(', ')');
            _bracketPairCollection.Add('[', ']');
            _bracketPairCollection.Add('{', '}');

        }

        public static Dictionary<char, char> BracketPairs
        {
            get { return _bracketPairCollection; }
        }
    }
}