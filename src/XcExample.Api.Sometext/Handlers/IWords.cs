namespace XcExample.Api.Sometext.Handlers
{
    public interface IWords
    {
        string Lookup(short id);
        int Lookup(string word);
    }
}