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
        BirdBase.leftKeyBool = true;
    }

    public void leftup()
    {
        BirdBase.leftKeyBool = false;
    }

    public void rightdown()
    {
        BirdBase.rightKeyBool = true;
    }

    public void rightup()
    {
        BirdBase.rightKeyBool = false;
    }

    public void speedown()
    {
        BirdBase.fastFlyBool = true;
    }

    public void speedup()
    {
        BirdBase.fastFlyBool = false;
    }

    public void jumpdown()
    {
        BirdBase.jumpKeyBool = true;
    }

    public void jumpup()
    {
        BirdBase.jumpKeyBool = false;
    }
}