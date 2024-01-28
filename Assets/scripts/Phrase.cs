public class Phrase
{
    public string Answer { get; set; }
    public string Prompt { get; set; }

    public Phrase(string prompt, string answer)
    {
        Answer = answer;
        Prompt = prompt;
    }   
}