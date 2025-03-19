using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button twoPlayerBtn;
    public Button threePlayerBtn;
    public Button fourPlayerBtn;
    public Button quitBtn;

    // Start is called before the first frame update
    void Start()
    {
        twoPlayerBtn.onClick.AddListener(TwoPlayer);
        threePlayerBtn.onClick.AddListener(ThreePlayer);
        fourPlayerBtn.onClick.AddListener(FourPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CharacterSelect()
    {
        Debug.Log("char select");
        SceneManager.LoadScene(1);
    }

    public void TwoPlayer()
    {
        Debug.Log("2");
        CharacterSelect();
    }

    public void ThreePlayer()
    {
        Debug.Log("3");
        CharacterSelect();
    }

    public void FourPlayer()
    {
        Debug.Log("4");
        CharacterSelect();
    }
}
