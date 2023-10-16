namespace MatchingBrackets.Test
{
    public class MatchingBracketsUnitTest
    {
        private IBracketMatcher bracketMatcher;

        public MatchingBracketsUnitTest()
        {
            this.bracketMatcher = new BracketMatcher();
        }

        [Theory]
        [Trait("BracketMatcher", "All True")]
        [InlineData("<>", true)]
        [InlineData("", true)]
        [InlineData("[<abc>]{def}xyz", true)]
        [InlineData("A<B>C<D>E", true)]
        [InlineData("<abc...xyz>", true)]
        public void Open_And_Closed_Bracket_And_No_Brackets(string input, bool expected)
        {
            var result = this.bracketMatcher.HasMatchingBracket(input);
            
            Assert.Equal(result, expected);
        }


        [Theory]
        [Trait("BracketMatcher", "All False")]
        [InlineData("><", false)]
        [InlineData("<<>", false)]
        [InlineData("<<<<<", false)]
        [InlineData(">>>", false)]
        [InlineData("<<abc>def>xyz>", false)]
        public void Closed_Bracket_Cant_Proceed_All_Open_Brackets(string input, bool expected)
        {
            var result = this.bracketMatcher.HasMatchingBracket(input);

            Assert.Equal(result, expected);
        }
    }
}