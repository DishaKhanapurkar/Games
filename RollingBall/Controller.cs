using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText,winTextObject;
    public GameObject restartbutton, resumebutton, menupanel ,quitbutton;
    private int count;
    private Rigidbody rb;
    bool isGameover;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
       
        menupanel.SetActive(false);
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.gameObject.SetActive(false);
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 10)
        {
            menupanel.SetActive(false);
            resumebutton.SetActive(false);
            restartbutton.SetActive(false);
            winTextObject.gameObject.SetActive (true);
            winTextObject.text = "You Win !!! Yeah!!!";
        }
        if(isGameover)
        {
            menupanel.SetActive(true);
            restartbutton.SetActive(true);
            resumebutton.SetActive(false);
            winTextObject.gameObject.SetActive(true);
            winTextObject.text = "Game Over!!";

        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("PickUp"))
        {
            //other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            count = count + 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Distroy"))
        {
            isGameover = true;
            this.enabled = false;
            SetCountText();
            Debug.Log("----- Destroy ----");
        }

    }

    public void OnClickRestart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("minigame");
    }
    public void OnClickResume()
    {
        this.enabled = true;
        menupanel.SetActive(false);

    }
    public void OnClickPause()
    {
        menupanel.SetActive(true);
        this.enabled = false;
        restartbutton.SetActive(true);
       

    }
    public void OnClickQuit()
    {
        Debug.Log("Its a quit of game");
        Application.Quit();
    }
}
