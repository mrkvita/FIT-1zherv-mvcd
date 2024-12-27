using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       animator.SetFloat("Horizontal", Input.GetAxis("Horizontal")); 
        
       Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
       transform.position += horizontal * Time.deltaTime;
    }
    
    
}
