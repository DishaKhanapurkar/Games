using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Scores : MonoBehaviour
{
    
    // Start is called before the first frame update
    public TextMeshProUGUI goldtext;
   
    public static int gold = 0;
    
    
    void Start()
    {
        goldtext.text= "Gold: "+ gold.ToString();
     

    }

    // Update is called once per frame
  public void AddPoint()
    {
        gold += 1;
        goldtext.text = "Gold: " + gold.ToString();

    }
  

}
   

