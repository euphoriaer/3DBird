using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButton : MonoBehaviour
{
    public BirdBase BirdBase;

    private void Awake()
    {
        BirdBase = GameObject.Find("bird").GetComponent<BirdBase>();
    }


    public void leftdown()
    {
        BirdBase.leftKeyB = true;
    }

    public void leftup()
    {
        BirdBase.leftKeyB = false;
    }

    public void rightdown()
    {
        BirdBase.rightKeyB = true;
    }

    public void rightup()
    {
        BirdBase.rightKeyB = false;
    }

    public void speedown()
    {
        BirdBase.fastFlyB = true;
    }

    public void speedup()
    {
        BirdBase.fastFlyB = false;
    }

    public void jumpdown()
    {
        BirdBase.jumpKeyB = true;
    }

    public void jumpup()
    {
        BirdBase.jumpKeyB = false;
    }
}