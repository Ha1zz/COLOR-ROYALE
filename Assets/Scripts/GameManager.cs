using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TMP_Text playerScore;
    public TMP_Text dogScore;
    public TMP_Text catScore;
    public TMP_Text lionScore;
    public TMP_Text penguinScore;

    public GameObject ObjectToSpanwn;
    public int numberOfObjects = 10;

    public GameObject[] cubeArray;

    //
    private int playerNumber;
    private int dogNumber;
    private int catNumber;
    private int lionNumber;
    private int penguinNumber;

    // 
    public GameObject winLabel;
    public GameObject loseLabel;
    public GameObject pauseLabel;
    public GameObject instructionLabel;

    // Time Coundown
    public int countdownTime = 60;
    public TMP_Text countdownText;

    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
        Time.timeScale = 1;
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
        pauseLabel.SetActive(false);
        instructionLabel.SetActive(false);
        cubeArray = new GameObject[numberOfObjects];
        SpawnCube();
    }


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(CountDownOne());
    }

    // Update is called once per frame
    void Update()
    {
        if (countdownTime <= 0)
        {
            CalculateScore();
        }
    }
   

    public void AddScore(string name)
    {
        audioSource.Play();
        switch (name)
        {
            case "Chicken":
                playerNumber++;
                playerScore.text = playerNumber.ToString();
                break;
            case "Dog":
                dogNumber++;
                dogScore.text = dogNumber.ToString();
                break;
            case "Cat":
                catNumber++;
                catScore.text = catNumber.ToString();
                break;
            case "Penguin":
                penguinNumber++;
                penguinScore.text = penguinNumber.ToString();
                break;
            case "Lion":
                lionNumber++;
                lionScore.text = lionNumber.ToString();
                break;
            default:
                break;
        }
    }

    public void SubtractScore(string name)
    {
        switch (name)
        {
            case "Chicken":
                playerNumber--;
                playerScore.text = playerNumber.ToString();
                break;
            case "Dog":
                dogNumber--;
                dogScore.text = dogNumber.ToString();
                break;
            case "Cat":
                catNumber--;
                catScore.text = catNumber.ToString();
                break;
            case "Penguin":
                penguinNumber--;
                penguinScore.text = penguinNumber.ToString();
                break;
            case "Lion":
                lionNumber--;
                lionScore.text = lionNumber.ToString();
                break;
            default:
                break;
        }
    }

    void SpawnCube()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            int randomX = Random.Range(-70, 70);
            int randomZ = Random.Range(-70, 70);
            cubeArray[i] = Instantiate(ObjectToSpanwn, new Vector3(randomX, 2.15f, randomZ), Quaternion.identity);
            //cubeArray[i] = Instantiate(ObjectToSpanwn, new Vector3(randomX, 2.15f, randomZ), Quaternion.identity, this.gameObject.transform);
        }
    }

    public void CalculateScore()
    {
        int[] scoreArray = { dogNumber, catNumber, lionNumber, penguinNumber };
        int playerScore = playerNumber;

        for (int i = 0 ; i<scoreArray.Length ; i++)
        {
            if (playerScore < scoreArray[i])
            {
                playerScore = scoreArray[i];
            }
        }
        if (playerScore != playerNumber)
        {
            Time.timeScale = 0;
            loseLabel.SetActive(true);
        }
        else
        {
            Time.timeScale = 0;
            winLabel.SetActive(true);
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseLabel.SetActive(false);
        instructionLabel.SetActive(false);
    }

    IEnumerator CountDownOne()
    {
        countdownTime--;
        countdownText.text = countdownTime.ToString();
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(CountDownOne());
    }
}
