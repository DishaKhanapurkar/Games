using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //public GameObject panel;
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    //public static bool isgamepause = false;
    public static int jumpforce = 10;
    public TextMeshProUGUI countText;
    public int count;
    //public GameObject resume;
    public float speed;
    bool Isjump;
    //public GameObject gameoverpanel;
   // public GameObject restartbutton;
    public GameObject quitbutton;
    public Animator animator;
    public CharacterController controller;
    public Vector3 direction;
    public int desiredLane = 2;//0: left 1:middle 2:right
    public float laneDistance = 4;
    public int jumpForce;
    public Transform[] startposition, endposition;
    public player playerobj;
    public Scores scoreScript;


    //public TextMeshProUGUI tg;
   // public TextMeshProUGUI gametext;

    //public static bool isgameover = false;


    public TextMeshProUGUI tg;
    public TextMeshProUGUI gametext;
    public GameObject restartbutton;
    public GameObject panel;
    public static bool isgamepause = false;
    public static bool isgameover = false;




    private void Awake()
    {

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        countText.text = string.Empty;
    }
    void Start()
    {
        isgameover = false;
        panel.SetActive(false);
        restartbutton.SetActive(false);
        isgamepause = false;

    }
    public void OnClickQuit()
    {
        Debug.Log("Its a quit of game");
        Application.Quit();
    }
    /*public void OnClickRestart()
    {
        Scores.gold = 0;
        GameManager.Instance.panel.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }*/
    public void OnClickRestart()
    {
        Scores.gold = 0;
        panel.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
    void Update()
    {
        if (isgameover)
        {

            panel.SetActive(true);
            restartbutton.SetActive(true);
            gametext.text = "Game Over!!";
            isgamepause = true;
            GameManager.Instance.animator.SetBool("ispause", true);
        }
        else
        {
            isgameover = false;
            panel.SetActive(false);
            restartbutton.SetActive(false);
            isgamepause = false;

        }


    }
}
