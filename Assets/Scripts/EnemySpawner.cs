using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] obsticle;
    public float timer;   // the frequency of spawning gameobject
    public float obsticleSpeed;
    public GameObject Zero;

    private List<Vector3> listPos = new List<Vector3>(); //this verible is used to randomize y axis position of enemy spawn  



    private PlayerController pc;
    void Start()
    {

            int i = -2;
            while (i <= 2)
            {
                Vector2 pos = transform.position + new Vector3(0, i);
                listPos.Add(pos);
                i += 1;
            }
            StartCoroutine(spawnObs());
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator spawnObs()
    {
        if (!winchecker.gameOver)
        {
            yield return new WaitForSeconds(timer);
            int indexPosObs = Random.Range(0, listPos.Count);
            if (Random.value <= .1) // probability of instantiating zero 
            {
                int indexPositionGold = Random.Range(0, listPos.Count);
                while (indexPositionGold == indexPosObs)
                {
                    indexPositionGold = Random.Range(0, listPos.Count);
                }
                Instantiate(Zero, listPos[indexPositionGold] + new Vector3(1, 0, 0), Quaternion.identity);
            }


            GameObject currentObs = Instantiate(obsticle[Random.Range(0, obsticle.Length)], listPos[indexPosObs] + new Vector3(1, 0, 0), Quaternion.identity);
            StartCoroutine(spawnObs());
        }

        else
        {
            obsticleSpeed = 0;
        }
    }
}
