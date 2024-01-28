public class Phrase
{
    public string Answer { get; set; }
    public string Prompt { get; set; }
    public int Tier { get; set; }

    public Phrase(string prompt, string answer, int tier = 0)
    {
        Answer = answer;
        Prompt = prompt;
        Tier = tier;
    }   
}