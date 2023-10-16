var serviceProvider = new ServiceCollection()
                            .AddSingleton<IBracketMatcher, BracketMatcher>()
                            .BuildServiceProvider();

var bracketMatcher = serviceProvider.GetService<IBracketMatcher>();

if (bracketMatcher is null)
    throw new ApplicationException("Unable to resolve IBracketMatcher");

var message = """
              Welcome to the Bracket Matcher App!
              
              Usage: Enter a string containing angle brackets to check if they are properly matched.
    
              Example: 
              You need to input without the quotes. e.g.
              "<abc>xyz"
              "><"
              "<<>"
              ">>>"
              Please press enter after your input.

              Press the "esc" if you want to exit.
              """;



var tryAgainMessage =
                    """
                    Do you want to try again? Y|N (N is the default)
                    """;
static void TryAgain(string anotherMessage, ref bool needsInput)
{
    Console.WriteLine(anotherMessage);

    var response = Console.ReadLine() ?? "N";

    if (response.Equals("n", StringComparison.OrdinalIgnoreCase) ||
        string.IsNullOrEmpty(response))
    {
        needsInput = false;
    }
}

Console.WriteLine(message);

bool needsInput = true;

do
{
    var input = Console.ReadLine() ?? "";

    var result = bracketMatcher.HasMatchingBracket(input);
    
    Console.WriteLine($"The result is '{result}' it is because there's a corresponding bracket.");

    TryAgain(tryAgainMessage, ref needsInput);
    
} while (needsInput);


Environment.Exit(0);
