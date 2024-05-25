using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gm;
    public float difficulty;
    void Start()
    {
        button=GetComponent<Button>();
        gm=GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty(){
        gm.StartGame(difficulty);
    }
}
