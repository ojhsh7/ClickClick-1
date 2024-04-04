using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private int maxScore;
    private int score;
    private void Awake()
    {
        Instance = this;
        UIManager.Instance.OnScoreChange(this.score, maxScore);
    }
    public void CalculateScore(bool isApple)
    {
        if (isApple)

        {
            score++;
        }
        else
        {
            score--;
        }

        UIManager.Instance.OnScoreChange(this.score, maxScore);
    }
}
