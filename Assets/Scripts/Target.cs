using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Target : MonoBehaviour
{
    private float speed;
    public Text text; 
    private void Start() {
        speed = (FindObjectOfType<DistanceCalculator>().distance - .2f) / (FindObjectOfType<targetSpawner>().timeToCalculate + FindObjectOfType<targetSpawner>().randomTime);
        text = GetComponentInChildren<Text>();

        text.text = FindObjectOfType<targetSpawner>().randomNumber.ToString();
    }
    void FixedUpdate()
    {
        // Debug.Log(speed);
        transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
    }

   
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("PlayerSymbol")){
            Destroy(this.gameObject);
        }
    }
}
