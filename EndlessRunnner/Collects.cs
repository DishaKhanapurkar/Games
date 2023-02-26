using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Collects : MonoBehaviour
{
    
    Vector3 originalPos;
    
    [SerializeField]
    Transform playerposition;
    [SerializeField]
    Transform goldposition;
  
    public float speed;
    
    
    private static int count;
    
    private CharacterController controller;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(1, 4);// 1 2 3 constant speed
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
       // GameManager.Instance.startgame();
        if (GameManager.isgamepause == false)
        {
            
            GameManager.Instance.direction.z = GameManager.Instance.speed;

            // Move our position a step closer to the target.
            var step = GameManager.Instance.speed * Time.deltaTime; // calculate distance to move
            if (this.gameObject.name == "diamond (1)" || this.gameObject.name == "diamond (5)" || this.gameObject.name == "Grenade")
            {
                transform.position = Vector3.MoveTowards(transform.position, GameManager.Instance.endposition[0].position, step);

                //Check if the position of the cube and sphere are approximately equal.
                if (Vector3.Distance(transform.position, GameManager.Instance.endposition[0].position) < 0.1f)
                {
                    // Swap the position of the cylinder.
                    transform.position = new Vector3(GameManager.Instance.startposition[0].transform.position.x, GameManager.Instance.startposition[0].transform.position.y, GameManager.Instance.startposition[0].transform.position.z);
                    GameManager.Instance.speed = 5;//Random.Range(3, 8);
                }
                if (Vector3.Distance(playerposition.position, transform.position) < 0.1f)
                {
                    // Swap the position of the cylinder.
                    transform.position = new Vector3(GameManager.Instance.startposition[0].transform.position.x, GameManager.Instance.startposition[0].transform.position.y, GameManager.Instance.startposition[0].transform.position.z);
                    GameManager.Instance.speed = 5;//Random.Range(3, 8);
                }


            }

            if (this.gameObject.name == "diamond (2)" || this.gameObject.name == "diamond (3)" || this.gameObject.name == "Grenade (2)")
            {
                transform.position = Vector3.MoveTowards(transform.position, GameManager.Instance.endposition[1].position, step);

                //Check if the position of the cube and sphere are approximately equal.
                if (Vector3.Distance(transform.position, GameManager.Instance.endposition[1].position) < 0.1f)
                {
                    // Swap the position of the cylinder.
                    transform.position = new Vector3(GameManager.Instance.startposition[1].transform.position.x, GameManager.Instance.startposition[1].transform.position.y, GameManager.Instance.startposition[1].transform.position.z);
                    GameManager.Instance.speed = 5;//Random.Range(3, 8);
                }
                if (Vector3.Distance(playerposition.position, transform.position) < 0.1f)
                {
                    // Swap the position of the cylinder.
                    transform.position = new Vector3(GameManager.Instance.startposition[1].transform.position.x, GameManager.Instance.startposition[1].transform.position.y, GameManager.Instance.startposition[1].transform.position.z);
                    GameManager.Instance.speed = 5;//Random.Range(3, 8);
                }
            }
            if (this.gameObject.name == "diamond (4)" || this.gameObject.name == "diamond (5)")
            {
                transform.position = Vector3.MoveTowards(transform.position, GameManager.Instance.endposition[2].position, step);

                //Check if the position of the cube and sphere are approximately equal.
                if (Vector3.Distance(transform.position, GameManager.Instance.endposition[2].position) < 0.1f)
                {
                    // Swap the position of the cylinder.
                    transform.position = new Vector3(GameManager.Instance.startposition[2].transform.position.x, GameManager.Instance.startposition[2].transform.position.y, GameManager.Instance.startposition[2].transform.position.z);
                    GameManager.Instance.speed = 5;//Random.Range(3, 8);
                }
                if (Vector3.Distance(playerposition.position, transform.position) < 0.1f)
                {
                    // Swap the position of the cylinder.
                    transform.position = new Vector3(GameManager.Instance.startposition[2].transform.position.x, GameManager.Instance.startposition[2].transform.position.y, GameManager.Instance.startposition[2].transform.position.z);
                    GameManager.Instance.speed = 5;//Random.Range(3, 8);
                }
            }

        }
    }

}
   

    




