using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public int max;
    public int index = 0;
    public Image current;
    public Image next;
    public Image prev;
    public Button right;
    public Button left;

    public Image[] UIparts = new Image[5];

    public PlayerScript owner;
    // used for positioning in game (p1 on left, p2 on right, etc.)
    public int ownerNum;

    // Start is called before the first frame update
    void Start()
    {
        max = OmnipotentOne.instance.paddles.Length - 1;
        right.onClick.AddListener(Right);
        left.onClick.AddListener(Left);
        ChangeSprites();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ChangeSprites()
    {
        current.sprite = OmnipotentOne.instance.sprites[index];
        next.sprite = OmnipotentOne.instance.sprites[IRight()];
        prev.sprite = OmnipotentOne.instance.sprites[ILeft()];
    }

    private int IRight()
    {
        int i = index;

        if (i == max)
        {
            i = 0;
        }
        else
        {
            i++;
        }
        return i;
    }

    private int ILeft()
    {
        int i = index;

        if (i == 0)
        {
            i = max;
        }
        else
        {
            i--;
        }
        return i;
    }

    void Right()
    {
        index = IRight();
        ChangeSprites();
        if (owner != null)
        {
            owner.paddle = index;
        }
    }

    void Left()
    {
        index = ILeft();
        ChangeSprites();
        if (owner != null)
        {
            owner.paddle = index;
        }
    }
}
