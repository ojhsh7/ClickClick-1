using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private int maxScore;
    [SerializeField] private int noteGroupCreateScore = 10;
    [SerializeField] private GameObject gameclearObj;
    [SerializeField] private GameObject gameOverObj;
    private int score;
    private int nextNoteGroupUnlockCnt;
    [SerializeField] private float maxTime = 30f;
    public bool IsGameDone
    {
        get
        {
            if (gameclearObj.activeSelf || gameOverObj.activeSelf)
                return true;
            else return false;

        }
    } 
    


    private void Awake()
    {
  

        Instance = this;

    }
    private void Start()
    {
        UIManager.Instance.OnScoreChange(this.score, maxScore);
        NoteManager.Instance.Create();

        gameclearObj.SetActive(false);
        gameOverObj.SetActive(false);
        StartCoroutine(TimerCourout());
    }
   
    IEnumerator TimerCourout()
    {
        float currentTime = 0f;
        while (currentTime < maxTime)
        {
            currentTime += Time.deltaTime;
            UIManager.Instance.OnTimerChange(currentTime, maxTime);
            yield return null;
            if (IsGameDone)
            {
                yield break;
            }
        }
        Debug.Log(  "Game Over......" );

        gameOverObj.SetActive(true);
    }
    public void CalculateScore(bool isApple)
    {
        if (isApple)

        {
            score++;
            nextNoteGroupUnlockCnt++;

            if(noteGroupCreateScore <= nextNoteGroupUnlockCnt)
            {
                nextNoteGroupUnlockCnt = 0;
                NoteManager.Instance.CreateNoteGroup();
            }
            if (maxScore < score) 
            {
                Debug.Log("Game Clear!...... ");
                gameclearObj.SetActive (true);
            }
        }
        else
        {
            score--;
        }
        UIManager.Instance.OnScoreChange(score, maxScore);
    }
    public void Restart()
    {
        Debug.Log("Game Restart!...... ");
        SceneManager.LoadScene(0);
    }
}