using UnityEngine;

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
    public string SpriteName { get; set; }



    public Phrase(string prompt, string answer, int tier = 0, PhraseType type = PhraseType.Safe, string spriteName = null)
    {
        Answer = answer;
        Prompt = prompt;
        Tier = tier;
        Type = type;
        SpriteName = spriteName;
    }   
}