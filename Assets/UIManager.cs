using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private GameObject startMenuUI;
    [SerializeField] private GameObject gameOverUI;

    private GameManager gm;

    private void Start(){
        gm = GameManager.Instance;
        gm.onGameOver.AddListener(ActivateGameOverUI); 
    }

    public void PlayButtonHandler(){
    AudioManager.instance.PlaySFX(AudioManager.instance.play);
    AudioManager.instance.PlayBackgroundMusic(); //  Retorna a música de fundo
    gm.StartGame();       
    startMenuUI.SetActive(false);
    }

    public void ActivateGameOverUI() {
        AudioManager.instance.StopMusicWithFade(); //  Fade-out na música
        AudioManager.instance.PlaySFX(AudioManager.instance.gameover); //  Game Over
        gameOverUI.SetActive(true);
    }

    private void Update(){
        scoreUI.text = gm.PrettyScore();
    }
}
