using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class OrcaScript : MonoBehaviour
{
    // Start is called before the first frame update

    
    [SerializeField] private float speedY;

    [SerializeField] private bool MoveUP;
    [SerializeField] private bool stop = true;

 

    // Update is called once per frame
    void Update()
    {
        
            if (MoveUP && !stop)
            {
                transform.position += speedY * Time.deltaTime * transform.up;
            }
        
       
            if (!MoveUP && !stop)
            {
                transform.position += -speedY * Time.deltaTime * transform.up;
            }
        

        
    }

    public void STOP() { //call at the warning
        stop = true;
    }

    public void goDown() //call in the middle
    {
        MoveUP = false;
        stop = false;
    }

    public void goUp() //call at the beginning
    {
        MoveUP = true;
        stop = false;
    }
}
