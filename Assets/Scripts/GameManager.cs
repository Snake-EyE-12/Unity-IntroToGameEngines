using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject titleUI;
    [SerializeField] private GameObject hudUI;
    [SerializeField] private GameObject gameWonUI;
    
    [SerializeField] private TMP_Text finalWonScoreUI;

    [SerializeField] private TMP_Text scoreUI;
    [SerializeField] private TMP_Text livesUI;
    [SerializeField] private TMP_Text timerUI;
    [SerializeField] private Slider healthUI;


    [SerializeField] private GameObject gameOverUI;

    [SerializeField] private TMP_Text finalScoreUI;


    [SerializeField] private FloatVariable health;
    [Header("Events")]
    [SerializeField] IntEvent scoreEvent; 
    [SerializeField] VoidEvent gameStartEvent;
    [SerializeField] GameObjectEvent respawnEvent;
    [SerializeField] private GameObject respawn;

    private Transform startingLocation;
    private void Start() {
        startingLocation = respawn.transform;
    }
    
    public enum State
    {
        Title,
        Start,
        Reset,
        Play,
        Over,
        None,
        Won
    }
    public float timer = 0;
    public int lives = 3;
    public int score = 0;

    public int Lives { get { return lives;} set {lives = value; livesUI.text = "Lives: " + lives.ToString();}}
    public int Score { get { return score;} set {score = value; scoreUI.text = score.ToString();}}
    public float Timer { get { return timer;} set {timer = value; timerUI.text = Mathf.Ceil(timer).ToString();}}

    public void GoAgain() {

        ChangeState(State.None);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnGameWon() {
        ChangeState(State.Won);
    }

    public void OnPlayerDied() {
        Lives--;
        if(Lives == 0) ChangeState(State.Over);
        else ChangeState(State.Reset);
        
    }
    public void OnStartGame() {
        ChangeState(State.Start);
        gameStartEvent.RaiseEvent();

    }
    public void OnAddPoints(int points) {
        Score += points;
    }

    private void Update() {

        healthUI.value = health.value / 100.0f;
        if(Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }



        switch(currentState) {
            case State.Title: {
                if(true) {
                    titleUI.SetActive(true);
                    hudUI.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
                break;
            }
            case State.Start: {
                titleUI.SetActive(false);
                Lives = 3;
                Timer = 0;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                
                ChangeState(State.Reset);
                break;
            }
            case State.Reset: {
                health.value = 100.0f;
                respawnEvent.RaiseEvent(respawn);
                ChangeState(State.Play);
                break;
            }
            case State.Play: {
                Timer = Timer += Time.deltaTime;
                break;
            }
            case State.Over: {
                if(currentState != previousState) {
                    gameOverUI.SetActive(true);
                    hudUI.SetActive(false);
                    finalScoreUI.text = "Final Score: " + Mathf.Clamp((Score - (int)Timer), 0, int.MaxValue);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    
                }
                break;
            }
            case State.Won: {
                if(currentState != previousState) {
                    gameWonUI.SetActive(true);
                    hudUI.SetActive(false);
                    finalWonScoreUI.text = "Final Score: " + Score;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    
                }
                break;
            }
        }
    }
    private State previousState;
    private State currentState = State.Title;
    private void ChangeState(State state) {
        previousState = currentState;
        currentState = state;
    }
}
