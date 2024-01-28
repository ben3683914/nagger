public class Phrase
{
    public enum PhraseType
    {
        Safe,
        Sus
    }

    public string Answer { get; set; }
    public string Prompt { get; set; }
    public int Tier { get; set; }
    public PhraseType Type { get; set; }



    public Phrase(string prompt, string answer, int tier = 0, PhraseType type = PhraseType.Safe)
    {
        Answer = answer;
        Prompt = prompt;
        Tier = tier;
        Type = type;
    }   
}