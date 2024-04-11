using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private int maxScore;
    [SerializeField] private int noteGroupCreateScore = 10;
    private int score;
    private int nextNoteGroupUnlockCnt;
    [SerializeField] private float maxTime = 30f;
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
        while (currentTime < maxScore)
        {
            currentTime += Time.deltaTime;
            UIManager.Instance.OnTimerChange(currentTime, maxTime);
            yield return null;
        }
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
        }
        else
        {
            score--;
        }
        UIManager.Instance.OnScoreChange(this.score, maxScore);
    }

}