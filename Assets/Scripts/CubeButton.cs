
using UnityEngine;
using UnityEngine.UI;


public class CubeButton : MonoBehaviour
{
    private static CubeButton _instance;
    public static CubeButton Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<CubeButton>();
                if (_instance == null)
                {
                    _instance = new GameObject().AddComponent<CubeButton>();
                }
            }
            return _instance;
        }
    }
    [SerializeField] private Button diceButton;
    [SerializeField] private GameObject diceAnimation;
    [SerializeField] private Sprite[] diceNumbers;
    private bool _cubeWait = false;
    public int cubeNumber = -1;
    public bool CubeWait
    {
        get { return _cubeWait; }
        set { _cubeWait = value;
            _cubeWait = value;
        }
    }
    private Animator anim;
    private void Start()
    {
        anim = diceAnimation.GetComponent<Animator>();

    }
    public void GenerateRandomNumber()
    {
        //Debug.Log(cubeDone);
        //Debug.Log(playerController.moveDone);
        if (!_cubeWait)
        {
            int num = UnityEngine.Random.Range(1, 7);
            _cubeWait = true;
            cubeNumber = num;
            DiceClicked();
        }


    }
    public void DiceClicked()
    {
        anim.Play("rolling");
        Invoke("SetDiceNumber", anim.GetCurrentAnimatorStateInfo(0).length);

    }
    void SetDiceNumber()
    {
        anim.SetInteger("DiceNumber", cubeNumber);
    }
}
