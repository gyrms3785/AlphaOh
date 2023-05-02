namespace solution.src.model;

public static class DefaultValue
{
    public static readonly Unit DefaultCharList = new ('0', '1', '2', '3', '4', '5', '6', '7', '8', '9');
    public const int DefaultCharSize = 4;


    public static readonly Verdict[] VerdictCandidate =
    {
        new (0, 0),
        new (0, 1),
        new (0, 2),
        new (0, 3),
        new (0, 4),
        new (1, 0),
        new (1, 1),
        new (1, 2),
        new (1, 3),
        new (2, 0),
        new (2, 1),
        new (2, 2),
        new (3, 0),
        new (4, 0),
    };
}