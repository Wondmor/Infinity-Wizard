using ClearSky;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverForm : MonoBehaviour
{
    // Start is called before the first frame update
    //TODO Tween
    [SerializeField] private GameObject masks;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        masks.SetActive(false);

        menuButton.onClick.AddListener(OnMenuButtonClick);
        restartButton.onClick.AddListener(OnRestartButtonClick);
        quitButton.onClick.AddListener(OnQuitButtonClick);
    }

    private void OnEnable()
    {
        Health.GameOver += GameOver;
    }
    
    private void OnMenuButtonClick()
    {
        SceneManager.LoadScene("Start");
    }
    private void OnRestartButtonClick() 
    {
        SceneManager.LoadScene("Select_character"); 
    }
    private void OnQuitButtonClick() 
    {
        Application.Quit(); 
    }

    private void GameOver()
    {
        masks.SetActive(true);
    }

    private void OnDisable()
    {
        Health.GameOver -= GameOver;
    }
}
