using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {
    
    #region Singleton

    public static GameManager Instance;

    private void Awake(){
        if(Instance == null) Instance = this;
    }

    #endregion

    public float currentScore = 0f;

    public bool isPlaying = false;

    public UnityEvent onPlay = new UnityEvent();
    public UnityEvent onGameOver = new UnityEvent();

    public void AddScore(int amount) {      //score
        currentScore += amount;
    }

    private void Update() {
        if(isPlaying){
            currentScore += Time.deltaTime;
        }
    }

    public void StartGame(){
        onPlay.Invoke();
        isPlaying = true;
        FindObjectOfType<CollectableSpawner>().StartSpawning();

    }

    public void GameOver() {
        onGameOver.Invoke();
        currentScore = 0;
        isPlaying = false;
        FindObjectOfType<CollectableSpawner>().StopSpawning();
    }

    public string PrettyScore () {
        return Mathf.RoundToInt(currentScore).ToString();
    }

}
