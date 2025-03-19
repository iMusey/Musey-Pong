using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmnipotentOne : MonoBehaviour
{
    // Stored Info

    // Paddles
    // Prefabs for loading
    public GameObject[] paddles = new GameObject[0];
    // Sprites for char select
    public Sprite[] sprites = new Sprite[0];

    // Players
    public List<PlayerScript> players = new List<PlayerScript>();
    public List<PlayerScript> currentPlayers = new List<PlayerScript>();


    // Static declaration
    public static OmnipotentOne instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        // on start import players from json save file??
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdatePlayerList()
    {

    }
}
