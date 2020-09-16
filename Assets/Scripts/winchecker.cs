using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winchecker : MonoBehaviour
{

    public static bool gameOver;
    private int randNum;
    public GameObject LevelupSound , deathSound;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            FindObjectOfType<PlayerController>().anim.SetTrigger("gameOver");
            
        }
        else
        {
            
        }

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            randNum = FindObjectOfType<targetSpawner>().randomNumber;

            if(randNum > 0){
                if (FindObjectOfType<PlayerController>()._playerVal < randNum)
                 {
                    gameOver = true;
                    Instantiate(deathSound, transform.position, Quaternion.identity);
                 }

                else
                {
                    FindObjectOfType<PlayerController>()._playerVal -= randNum;
                    uimanager.numberOfGates+=1;
                    gameOver = false;
                    Instantiate(LevelupSound, transform.position, Quaternion.identity);
                }
            }
            else{
                if (FindObjectOfType<PlayerController>()._playerVal > randNum)
                {
                    gameOver = true;
                    Instantiate(deathSound, transform.position, Quaternion.identity);
                }

                else
                {
                    FindObjectOfType<PlayerController>()._playerVal -= randNum;
                    uimanager.numberOfGates+=1;
                    gameOver = false;
                    Instantiate(LevelupSound, transform.position, Quaternion.identity);
                }
            }            
            
        }

    }



}
