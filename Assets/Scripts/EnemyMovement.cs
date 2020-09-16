using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private void Start() {
        Destroy(this.gameObject, 5f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.left * FindObjectOfType<EnemySpawner>().obsticleSpeed * Time.deltaTime;
        
    }
}
