namespace SSY;

public static class SSYConsts
{
    public const string DbTablePrefix = "App";

    public const string DbSchema = null;
    public class Endpoints
    {
        public class Collections
        {
            private const string Base = "/Collection";
            public const string GetCollectionTimeline = $"{Base}/{nameof(GetCollectionTimeline)}";
        }
    }
}
