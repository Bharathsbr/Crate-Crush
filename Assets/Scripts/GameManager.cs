using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public List<GameObject> list;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI goText;
    public Button restart;
    private int score;
    private float spawnRate=1.0f;
    public bool isGameActive;
    public GameObject ts;



    IEnumerator SpawnObstacles()
    {
        while(isGameActive){
            yield return new WaitForSeconds(spawnRate);
            int index=Random.Range(0,list.Count);
            Instantiate(list[index]);
        }
    }

    public void UpdateScore(int newScore)
    {
        score+=newScore;
        scoreText.text="Score: "+score;
    }

    public void GameOver()
    {
        goText.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
        isGameActive=false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(float difficulty){
        isGameActive=true;
        StartCoroutine(SpawnObstacles());
        score=0;
        spawnRate=spawnRate/difficulty;
        UpdateScore(0);
        ts.gameObject.SetActive(false);
    }
}
