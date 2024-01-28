using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;
using UnityEngine.UIElements;
using System.Text;

public class GuessManager : MonoBehaviour
{
    private const string defaultGuesses = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private char[] _guessList;
    public string phrase;
    public string answer;
    public int guesscount = 0;

    public TMP_Dropdown GuessDropdown;
    public UnityEngine.UI.Button Button;
    public TMP_Text GuessText;
    public TMP_Text AnswerText;

    public char[] guessList
    {
        get => _guessList;
        set
        {
            if (value == null || value.Length > 0)
            {
                _guessList = defaultGuesses.ToCharArray();
            }
            else
            {
                _guessList = value;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        guessList = _guessList;
        AnswerText.text = new string(' ', phrase.Length);
        phrase = phrase.ToUpper();
        GuessDropdown.options = _guessList.Select(x => new TMP_Dropdown.OptionData { text = x.ToString() }).ToList();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddGuesses(int guesses)
    {
        guesscount += guesses;

        UpdateUI();
    }

    public void Guess()
    {
        Button.interactable = false;
        var guessLetter = GuessDropdown.options[GuessDropdown.value].text[0];

        if (phrase.Contains(guessLetter))
        {
            var answerString = new StringBuilder(AnswerText.text);
            for (int i = 0; i < phrase.Length; i++)
            {
                answerString[i] = phrase[i] == guessLetter ? phrase[i] : answerString[i];
            }
            AnswerText.text = answerString.ToString();
        }
        guessList = guessList.Where(x => x != guessLetter).ToArray();

        guesscount--;

        UpdateUI();

        Button.interactable = true;
    }

    private void UpdateUI()
    {
        var enableUI = guesscount > 0;
        GuessText.text = $"Guesses Left: {guesscount}";

        Button.enabled = enableUI;
        GuessDropdown.enabled = enableUI;
        GuessText.enabled = enableUI;
    }

}
