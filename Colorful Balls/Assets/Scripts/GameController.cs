using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [SerializeField] float totalTime = 30f;
    float currentTime;
	[SerializeField] Text timeDisplay;

    [SerializeField] Text fpsDisplay;
    float avgFPS;
    int framesCounted;

    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Text finalScoreText;

    private void Start()
    {
        currentTime = totalTime;
    }


    private void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            EndGame();
            return;
        }

        timeDisplay.text = "Time Left: " + Mathf.FloorToInt(currentTime);

        float currentFPS = 1 / Time.deltaTime;
        fpsDisplay.text = "FPS: " + Mathf.FloorToInt(currentFPS);

        //avgFPS = (avgFPS * (framesCounted - 1) + currentFPS) / framesCounted;
        //avgFPS -= avgFPS / framesCounted;
        //avgFPS += currentFPS / framesCounted;
        framesCounted++;
        avgFPS = avgFPS * (framesCounted - 1) / framesCounted + currentFPS / framesCounted;
        if (avgFPS == 0) avgFPS = currentFPS;
        Debug.Log("Average FPS: " + avgFPS);
    }


    void EndGame()
    {
        Destroy(timeDisplay.gameObject);
        Destroy(fpsDisplay.gameObject);
        Destroy(FindObjectOfType<Spawner>().gameObject);
        Ball[] balls = FindObjectsOfType<Ball>();
        for (int i = 0; i < balls.Length; i++) balls[i].Die();

        gameOverScreen.SetActive(true);
        finalScoreText.text = avgFPS.ToString();
    }
}
