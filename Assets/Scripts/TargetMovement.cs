using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public float speed;
    private bool _isMoving;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _isMoving = false;
        Invoke("moveTarget", FindObjectOfType<targetSpawner>().randomTime); // randomize this 
    }

    private void FixedUpdate() {
       
    if(_isMoving)
    {
        transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
    }
    }
    
    private void moveTarget(){
        _isMoving = true;
        Invoke("moveTarget", FindObjectOfType<targetSpawner>().randomTime);      
    }
}
