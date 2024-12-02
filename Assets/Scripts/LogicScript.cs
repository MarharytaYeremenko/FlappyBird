using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    private AudioSource audioSource;
    private AudioSource audioSourceButton;
    private AudioSource audioBirdDies;
    public bool birdIsAlive = true;
    private bool hasPlayed = false;


    [ContextMenu("Increase Score")]



    private void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();

        if (audioSources.Length > 1)
        {
            audioSource = audioSources[0];
            audioSourceButton = audioSources[1];
            audioBirdDies = audioSources[2];
        }
        else
        {
            Debug.LogError("Not enough AudioSource components on the object");
        }
    }

    public void PlayScoreSound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioSource for score sound is not assigned");
        }
    }
    public void PlayButtonSound()
    {
        if ( audioSourceButton != null)
        {
            audioSourceButton.Play();
        }
        else
        {
            Debug.LogError("AudioSource for button sound is not assigned");
        }
    }
    public void addScore(int scoreToAdd)
    {
        if (birdIsAlive)
        {
            playerScore = playerScore + scoreToAdd;
            scoreText.text = playerScore.ToString();
            PlayScoreSound();
        }
        else
        {
            Debug.Log("Cannot add score. Bird is not alive.");
        }
    }

public void restartGame()
    {
        StartCoroutine(RestartAfterSound());
    }

    private IEnumerator RestartAfterSound()
    {
        PlayButtonSound();
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void PlayBirdDiesSong()
    {
         if (!hasPlayed)
        {
            audioBirdDies.Play();
            hasPlayed = true;
        }
    }
    public void gameOver()
    {
        birdIsAlive = false;
        PlayBirdDiesSong();
        gameOverScreen.SetActive(true);

    }

    public void doExitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

}
