using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSymbolDestroy : MonoBehaviour
{
    public GameObject destroyEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(winchecker.gameOver){
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }   
    }
}
