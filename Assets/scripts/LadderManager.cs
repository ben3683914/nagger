using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LadderManager : MonoBehaviour
{
    public UnityEvent<int, int> OnNextTier; // send an event with the current tier when we progress to the next tier
    public UnityEvent<int> OnNextPhrase; // send an event with the current tier when we progress to the next phrase
    public UnityEvent<int> OnCompletedTier; // send an event when you complete a tier

    public int Tiers = 2;
    public int CurrentTier = 0;
    public int CurrentTierIndex = 0;
    
    public List<Phrase.PhraseType> TierPhrases;

    private void Start()
    {
        TierPhrases = new List<Phrase.PhraseType>() { Phrase.PhraseType.Safe, Phrase.PhraseType.Safe, Phrase.PhraseType.Safe, Phrase.PhraseType.Sus};
    }

    public void NextPhrase()
    {
        if (CurrentTierIndex >= TierPhrases.Count-1)
        {
            NextTier();
        }
        else
        {
            CurrentTierIndex++;
        }

        GameManager.Instance.GameState.ChangeState(new SpinnerState());
        OnNextPhrase.Invoke(CurrentTier);
    }

    public void NextTier()
    {
        CurrentTier++;
        CurrentTierIndex = 0;

        if (CurrentTier >= Tiers)
        {
            GameManager.Instance.GameState.ChangeState(new WinState());
            return;
        }

        OnNextTier.Invoke(CurrentTier, CurrentTierIndex);
    }

    public Phrase.PhraseType GetCurrentPhraseType()
    {
        return TierPhrases[CurrentTierIndex];
    }
}
