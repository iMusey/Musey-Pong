using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class PlayerDataController : MonoBehaviour
{

    public CharacterSelector charSelector;

    // buttons
    public Button addNewPlayer;
    public GameObject addBtn;
    public Button confirmNewPlayer;
    public GameObject confirmBtn;

    public TMP_Dropdown playerList;
    public TextMeshProUGUI currentPlayerName;
    public PlayerScript currentPlayer;
    public TextMeshProUGUI nameInput;

    public bool addingPlayer = false;
    public GameObject playerPrefab;


    // rebinding shit
    // UI bits
    
    public TMP_InputField textR;
    public TMP_InputField textL;
    public TMP_InputField textS;


    // Start is called before the first frame update
    void Start()
    {
        addNewPlayer.onClick.AddListener(NewPlayerStart);
        confirmNewPlayer.onClick.AddListener(ConfirmNewPlayer);

        /*
        // Add all players to Dropdown
        List<Dropdown.OptionData> pNames = new List<Dropdown.OptionData>();
        foreach (PlayerScript p in OmnipotentOne.instance.players)
        {
            pNames.Add(new Dropdown.OptionData { text = p.username });
        }
        playerList.AddOptions(pNames);
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlayer != null && !addingPlayer)
        {
            if (currentPlayer.username == currentPlayerName.text)
            {
                foreach (PlayerScript p in OmnipotentOne.instance.players)
                {
                    if (p.username == currentPlayerName.text)
                    {
                        currentPlayer = p;
                        break;
                    }
                }

                // display player details
                charSelector.owner = currentPlayer;
                textR.text = currentPlayer.right.ToString();
                textL.text = currentPlayer.left.ToString();
                textS.text = currentPlayer.special.ToString();

                foreach (Image i in charSelector.UIparts)
                {
                    Color c = currentPlayer.color;
                    i.color = new Color(c.r, c.g, c.b, i.color.a);
                }
            }
        }
    }

    void UpdateDropdown()
    {
        // Add all players to Dropdown
        List<TMP_Dropdown.OptionData> pNames = new List<TMP_Dropdown.OptionData>();
        foreach (PlayerScript p in OmnipotentOne.instance.players)
        {
            pNames.Add(new TMP_Dropdown.OptionData { text = p.username });
        }
        playerList.ClearOptions();
        playerList.AddOptions(pNames);
    } 

    public void NewPlayerStart()
    {
        addingPlayer = true;
        addBtn.SetActive(false);
        confirmBtn.SetActive(true);
    }

    public void ConfirmNewPlayer()
    {
        // Add playerscript to omni database
        PlayerScript newP = GameObject.Instantiate(playerPrefab).GetComponent<PlayerScript>();
        newP.username = nameInput.text;
        newP.color = new Color((float)Random.Range(0, 1f), (float)Random.Range(0, 1f), (float)Random.Range(0, 1f));
        newP.right = (KeyCode)System.Enum.Parse(typeof(KeyCode), textR.text.Trim(), true);
        newP.left = (KeyCode)System.Enum.Parse(typeof(KeyCode), textL.text.Trim(), true);
        newP.special = (KeyCode)System.Enum.Parse(typeof(KeyCode), textS.text.Trim(), true);
        newP.wins = 0;

        foreach (PlayerScript p in OmnipotentOne.instance.players)
        {
            if (p.username == newP.username)
            {
                OmnipotentOne.instance.players.Remove(p);
                    break;
            }
        }

        currentPlayer = newP;
        OmnipotentOne.instance.players.Add(currentPlayer);
        UpdateDropdown();

        addingPlayer = false;
        addBtn.SetActive(true);
        confirmBtn.SetActive(false);
    }

}
