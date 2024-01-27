using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GuessManager : MonoBehaviour
{
    public string phrase;
    public string answer;
    private const string defaultGuesses = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private char[] _guessList;

    public Dropdown GuessDropdown;
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
        GuessDropdown = GetComponent<Dropdown>();
        GuessDropdown.options = _guessList.Select(x => new Dropdown.OptionData { text = x.ToString() }).ToList();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
