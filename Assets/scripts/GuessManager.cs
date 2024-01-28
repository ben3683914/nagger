using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;
using UnityEngine.UIElements;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

public class GuessManager : MonoBehaviour
{
    private const string defaultGuesses = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private char[] _guessList;

    public Phrase phrase;
    public int guesscount = 0;
    private List<Phrase> NormalPhrases;
    private List<Phrase> SusPhrases;
    public TMP_Dropdown GuessDropdown;
    public UnityEngine.UI.Button Button;
    public TMP_Text GuessText;
    public TMP_Text AnswerText;
    public TMP_Text PromptText;

    public char[] guessList
    {
        get => _guessList;
        set
        {
            if (value == null || value.Length == 0)
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
        InitializePhrases();
        guessList = _guessList;
        setPhrase(0);
        AnswerText.text = Regex.Replace(phrase.Answer, @"\w", "#");
        GuessDropdown.options = _guessList.Select(x => new TMP_Dropdown.OptionData { text = x.ToString() }).ToList();
        UpdateUI();

        GameManager.Instance.SpinManager.OnNeedleHit.AddListener(AddGuesses);

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

        if (phrase.Answer.Contains(guessLetter))
        {
            var answerString = new StringBuilder(AnswerText.text);
            for (int i = 0; i < phrase.Answer.Length; i++)
            {
                answerString[i] = phrase.Answer[i] == guessLetter ? phrase.Answer[i] : answerString[i];
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

        GuessDropdown.options = _guessList.Select(x => new TMP_Dropdown.OptionData { text = x.ToString() }).ToList();

    }

    private void setPhrase(int index)
    {
        phrase = NormalPhrases[index];
        phrase.Answer = phrase.Answer.ToUpper();
        PromptText.text = phrase.Prompt;
    }

    private void InitializePhrases()
    {
        var rand = new System.Random();

        NormalPhrases = new List<Phrase> {
            new Phrase("Fictional Characters","NICK FURY"),
            new Phrase("Fictional Characters","HOMER SIMPSON"),
            new Phrase("Fictional Characters","THE INCREDIBLE HULK"),
            new Phrase("Around The House","ADDRESS BOOK"),
            new Phrase("Around The House","ELECTRIC TOOTHBRUSH"),
            new Phrase("Around The House","PROFICIENTLY DISPLAYED AWARDS"),
            new Phrase("Event","COMIC BOOK CONVENTION"),
            new Phrase("Event","SUMMER VACATION"),
            new Phrase("Event","INDEPENDENCE DAY"),
            new Phrase("Food & Drink","AMERICAN CHEDDAR CHEESE"),
            new Phrase("Food & Drink","EAR OF CORN"),
            new Phrase("Food & Drink","LEMON POPPY SEED MUFFINS"),
            new Phrase("Occupation","BRAIN SURGEON"),
            new Phrase("Occupation","WEBMASTER"),
            new Phrase("Occupation","PERSONAL TRAINER"),
            new Phrase("Person","ALTAR BOY"),
            new Phrase("Person","FBI AGENT"),
            new Phrase("Person","SCHOOL COUNSELOR"),
            new Phrase("Phrase","AHEAD OF THE GAME"),
            new Phrase("Phrase","HAVING A GREEN THUMB"),
            new Phrase("Phrase","ONCE IN A BLUE MOON"),
            new Phrase("On The Map","PARK AVENUE"),
            new Phrase("On The Map","BRITISH COLUMBIA"),
            new Phrase("On The Map","LOUISVILLE KENTUCKY")
        };


        SusPhrases = new List<Phrase> {
            new Phrase("People That Annoy You","NAGGERS"),
            new Phrase("Things That Gross You Out","LOUISVILLE KENTUCKY")
        };

        NormalPhrases = NormalPhrases.OrderBy(_ => rand.Next()).ToList();
        SusPhrases = SusPhrases.OrderBy(_ => rand.Next()).ToList();

    }
}
