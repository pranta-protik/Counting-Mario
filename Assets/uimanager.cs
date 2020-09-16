using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class uimanager : MonoBehaviour
{
    public Text scoreText, bestScore, targetText;
    public GameObject replayButton;
    private Coroutine scoreCoroutine;
    private bool enableCheck;
    public static int numberOfGates;
    void Start()
    {
        numberOfGates = 0;
        enableCheck = true;
        replayButton.SetActive(false);
        scoreCoroutine = StartCoroutine(updateScoreManager(2));
    }

    // Update is called once per frame
    void Update()
    {
        targetText.text = FindObjectOfType<targetSpawner>().randomNumber.ToString();
        scoreText.text = scoremanager.Instance.score.ToString();
        bestScore.text = PlayerPrefs.GetInt("BestScore").ToString();


        if (winchecker.gameOver)
            Invoke("EnableButton", .5f);
    }


    IEnumerator updateScoreManager(float totalTime)
    {
        while (true)
        {
            if (!winchecker.gameOver)
            {
                scoremanager.Instance.ScoreUpdate(1);
                yield return new WaitForSeconds(totalTime);
            }
            yield return null;
        }
    }
    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        winchecker.gameOver = false;
    }
    public void EnableButton()
    {
        replayButton.SetActive(true);
    }

    IEnumerator waitandEnable()
    {
        yield return new WaitForSeconds(2f);
        enableCheck = true;
    }

}
