using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private int maxScore;
    [SerializeField] private int noteGroupCreateScore = 10;
    private bool isGameClear = false;
    private bool isGameOver = false;

    private int score;
    private int nextNoteGroupUnlockCnt;


    [SerializeField] private float maxTime = 30f;
    public bool IsGameDone
    {
        get
        {
            if (isGameClear || isGameOver)
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
        SceneManager.LoadScene("PlayScence");
    }
}