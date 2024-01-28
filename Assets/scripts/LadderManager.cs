using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LadderManager : MonoBehaviour
{
    public UnityEvent<int, int> OnNextTier; // send an event with the current tier when we progress to the next tier
    public UnityEvent<int> OnNextPhrase; // send an event with the current tier when we progress to the next phrase
    public UnityEvent OnCompletedTier;

    public int Tiers = 2;
    public int CurrentTier = 0;
    public int CurrentTierPhrase = 0;
    
    public List<Phrase.PhraseType> TierPhrases;

    private void Start()
    {
        TierPhrases = new List<Phrase.PhraseType>() { Phrase.PhraseType.Safe, Phrase.PhraseType.Safe, Phrase.PhraseType.Safe, Phrase.PhraseType.Sus};
    }

    public void NextTier()
    {
        if (CurrentTier >= Tiers)
        {
            GameManager.Instance.Win();
            return;
        }

        CurrentTier++;
        CurrentTierPhrase = 0;

        OnNextTier.Invoke(CurrentTier, CurrentTierPhrase);
    }

    public void NextPhrase()
    {
        if(CurrentTierPhrase >= TierPhrases.Count)
        {
            NextTier();
            return;
        }

        CurrentTierPhrase++;
        OnNextPhrase.Invoke(CurrentTier);
    }

    public Phrase.PhraseType GetCurrentPhraseType()
    {
        return TierPhrases[CurrentTierPhrase];
    }
}
