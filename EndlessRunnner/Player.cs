using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TMPro;
using UnityEngine;

public class player : MonoBehaviour
{
    public float jumpforce = 10f;
    public float gravity = -20f;
    private Vector3 direction;
    public TextMeshProUGUI tg;
    public TextMeshProUGUI gametext;
    public GameObject restartbutton;
    public GameObject panel;

    public static bool isgameover = false;


    void Start()
    {

        GameManager.Instance.animator = GetComponent<Animator>();
        GameManager.Instance.controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {



        if (GameManager.isgamepause == false)
        {
            if (GameManager.Instance.controller.isGrounded)
            {
                direction.y = -1;
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    jump();
                }
            }
            else
            {
                direction.y += gravity * Time.deltaTime;
            }
            Debug.Log("value" + GameManager.isgameover);
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                GameManager.Instance.desiredLane++;
                if (GameManager.Instance.desiredLane == 3)
                    GameManager.Instance.desiredLane = 2;

            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                GameManager.Instance.desiredLane--;
                if (GameManager.Instance.desiredLane == -1)
                    GameManager.Instance.desiredLane = 0;
            }

            //Debug.Log("======= desiredlane ========" + GameManager.Instance.desiredLane);

            Vector3 targetposition = transform.position.z * transform.forward + transform.position.y * transform.up;
            if (GameManager.Instance.desiredLane == 0)
            {
                //  Debug.Log("++++++ desiredlane ++++++" + GameManager.Instance.desiredLane);
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Debug.Log("uparrow enter");


                    GameManager.Instance.animator.SetBool("Isjump", true);

                }
                else
                {
                    GameManager.Instance.animator.SetBool("Isjump", false);
                }

                targetposition += Vector3.left * GameManager.Instance.laneDistance;

            }
            else if (GameManager.Instance.desiredLane == 2)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    GameManager.Instance.animator.SetBool("Isjump", true);

                }
                else
                {
                    GameManager.Instance.animator.SetBool("Isjump", false);
                }
                targetposition += Vector3.right * GameManager.Instance.laneDistance;
            }
            else if (GameManager.Instance.desiredLane == 1)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    GameManager.Instance.animator.SetBool("Isjump", true);

                }
                else
                {
                    GameManager.Instance.animator.SetBool("Isjump", false);
                }

            }
            //transform.position = Vector3.Lerp(transform.position, targetposition, 80 * Time.deltaTime);
            transform.position = targetposition;
        }
    }
    private void OnTriggerEnter(Collider other)
    {


        //transform.position = new Vector3(GameManager.Instance.startposition[0].transform.position.x, GameManager.Instance.startposition[0].transform.position.y, GameManager.Instance.startposition[0].transform.position.z);
        if (other.gameObject.CompareTag("Gold"))
        {
            GameManager.Instance.scoreScript.AddPoint();
        }
        if (other.gameObject.CompareTag("Bomb"))
        {
            GameManager.isgameover = true;

        }
       // GameManager.Instance.startgame();





    }
    public void jump()
    {
        direction.y = jumpforce;
    }
}








