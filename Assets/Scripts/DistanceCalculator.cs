using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{
    public Transform playerSymbol;
    public GameObject targetObject;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        distance = Vector3.Distance (transform.position, playerSymbol.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Debug.Log(distance);
        if(GameObject.FindWithTag("TargetSymbol")==null && GameObject.FindWithTag("Target") == null){
            Instantiate(targetObject, transform.position, Quaternion.identity);
        }
    }
}
