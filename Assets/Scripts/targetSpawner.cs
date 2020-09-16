using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class targetSpawner : MonoBehaviour
{
    public GameObject[] obsticle;
    public Transform mainPlayerPos;
    public float distance;
    public float timeToCalculate;
    public float minTime, maxTime;
    public int randomTime , randomNumber;
    private int randomType;


    void Start()
    {
        distance = Vector3.Distance (transform.position, mainPlayerPos.position);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(GameObject.FindWithTag("Target")==null ){
            randomTime = (int)Random.Range(minTime, maxTime);
            randomType = (int)Random.Range(0, 10);
            if(randomType >= 5){
                randomNumber = -1 * (int)Random.Range(11 , 16);
            }
            else{
                randomNumber = (int)Random.Range(11 , 16);
            }
            
            timeToCalculate = 0f;
            Instantiate(obsticle[Random.Range(0, obsticle.Length)],  new Vector2(6.25f, transform.position.y), Quaternion.identity);
            timeToCalculate = distance / FindObjectOfType<TargetMovement>().speed;
        }
    }

   
}

