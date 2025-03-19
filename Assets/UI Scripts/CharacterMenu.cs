using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    public Button exit;
    public Button play;

    // Start is called before the first frame update
    void Start()
    {
        exit.onClick.AddListener(Exit);
        play.onClick.AddListener(PlayGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Exit()
    {
        SceneManager.LoadScene(0);
    }

    void PlayGame()
    {
        // set players' paddles to what they currently have selected
        // Send info to the omnipotent one


        Debug.Log("yay!");
        SceneManager.LoadScene(2);
    }
}
