using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private int maxScore;
    [SerializeField] private int noteGroupCreateScore = 10;

    public static int score;
    private int nextNoteGroupUnlockCnt;
    private bool isGameClear = false;
    private bool isGameOver = false;


    [SerializeField] private float maxTime = 30f;
    [HideInInspector] public static float myTime;
    [HideInInspector] public static float minTime;
    

    public bool IsGameClear()
    {
        return isGameClear;
    }
    public bool IsGameOver()
    {
        return isGameOver;
    }

    public bool IsGameDone
    {
        get
        {
            if (isGameClear || isGameOver)
            {


                float minTime = PlayerPrefs.GetFloat("minTime", 1000f);


                if (minTime > myTime)
                {
                    myTime = minTime;
                }
                return true;
            }
            else return false;

        }
    }



    private void Awake()
    {
        Instance = this;
        score = 0;
    }

    private void Start()
    {
        UIManager.Instance.OnScoreChange(score, maxScore);
        NoteManager.Instance.Create();

        
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
        Debug.Log("Game OVER");
        isGameOver = true;
        SceneManager.LoadScene("Game OVER");
    }
    public void CalculateScore(bool isApple)
    {
        if (isApple)

        {
            
            score++;
            nextNoteGroupUnlockCnt++;

            if (noteGroupCreateScore <= nextNoteGroupUnlockCnt)
            {
                nextNoteGroupUnlockCnt = 0;
                NoteManager.Instance.CreateNoteGroup();
            }
            if (maxScore < score)
            {
                Debug.Log("Game Clear!...... ");
                isGameClear = true;
                SceneManager.LoadScene("Game OVER");
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
        SceneManager.LoadScene("Game Start");
    }
}