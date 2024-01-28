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

    private void Awake()
    {
        InitializePhrases();
    }

    // Start is called before the first frame update
    void Start()
    {
        guessList = _guessList;
        GameManager.Instance.SpinManager.OnNeedleHit.AddListener(AddGuesses);

    }

    // call on enter to state
    public void StartPhrase(int tier)
    {
        setPhrase(0);
        AnswerText.text = Regex.Replace(phrase.Answer, @"\w", "#");
        GuessDropdown.options = _guessList.Select(x => new TMP_Dropdown.OptionData { text = x.ToString() }).ToList();
        UpdateUI();
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
        PromptText.text = phrase.Prompt; // i can't find the gameobject for this
    }

    private int GetNextPhrase(Phrase.PhraseType type)
    {
        if(type == Phrase.PhraseType.Safe)
        {
            // get next safe phrase
        }
        else
        {
            // get next sus phrase
        }
        return 0;
    }

    private void InitializePhrases()
    {
        var rand = new System.Random();

        NormalPhrases = new List<Phrase> {
            new Phrase("Fictional Characters","NICK FURY", 1),
            new Phrase("Fictional Characters","HOMER SIMPSON", 0),
            new Phrase("Fictional Characters","THE INCREDIBLE HULK", 1),
            new Phrase("Around The House","ADDRESS BOOK", 0),
            new Phrase("Around The House","ELECTRIC TOOTHBRUSH", 1),
            new Phrase("Around The House","PROFICIENTLY DISPLAYED AWARDS", 1),
            new Phrase("Event","COMIC BOOK CONVENTION", 1),
            new Phrase("Event","SUMMER VACATION", 0),
            new Phrase("Event","INDEPENDENCE DAY", 0),
            new Phrase("Food & Drink","AMERICAN CHEDDAR CHEESE", 1),
            new Phrase("Food & Drink","EAR OF CORN", 0),
            new Phrase("Food & Drink","LEMON POPPY SEED MUFFINS", 1),
            new Phrase("Occupation","BRAIN SURGEON", 0),
            new Phrase("Occupation","WEBMASTER", 1),
            new Phrase("Occupation","PERSONAL TRAINER", 0),
            new Phrase("Occupation","FBI AGENT", 0),
            new Phrase("Occupation","SCHOOL COUNSELOR", 1),
            new Phrase("Person","ALTAR BOY", 0),
            new Phrase("Person", "MORGAN FREEMAN", 1),
            new Phrase("Person", "DONALD TRUMP", 0),
            new Phrase("Person", "BARACK OBAMA", 0),
            new Phrase("Person","TAYLOR SWIFT", 0),
            new Phrase("Phrase","AHEAD OF THE GAME", 1),
            new Phrase("Phrase","HAVING A GREEN THUMB", 1),
            new Phrase("Phrase","ONCE IN A BLUE MOON", 1),
            new Phrase("On The Map","PARK AVENUE", 1),
            new Phrase("On The Map","BRITISH COLUMBIA", 1),
            new Phrase("On The Map","LOUISVILLE KENTUCKY", 1),
            new Phrase("New Slang", "No Cap", 1),
            new Phrase("New Slang", "On God", 1),
            new Phrase("Dance", "SALSA", 0),
            new Phrase("Dance", "THE JITTERBUG", 1),
            new Phrase("Dance", "THE GRIDDIE",1),
            new Phrase("Video Game", "MINECRAFT", 0),
            new Phrase("Video Game", "CALL OF DUTY", 0),
            new Phrase("Video Game", "AMONG US", 1),
            new Phrase("CITY", "LOUISVILLE KENTUCKY", 1),
            new Phrase("CITY", "NEW YORK CITY", 0),
            new Phrase("CITY", "CHICAGO", 0),
            new Phrase("CITY", "ATLANTA", 0),
            new Phrase("CITY", "LOS ANGELES", 1),
        };


        SusPhrases = new List<Phrase> {
            new Phrase("People That Annoy You","NAGGERS", 1, Phrase.PhraseType.Sus),
            new Phrase("Things That Gross You Out","MAGGOTS", 0, Phrase.PhraseType.Sus)
        };

        NormalPhrases = NormalPhrases.OrderBy(_ => rand.Next()).ToList();
        SusPhrases = SusPhrases.OrderBy(_ => rand.Next()).ToList();
    }
}
