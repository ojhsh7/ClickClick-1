using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
    public static Replay instance;

    [SerializeField] public GameObject GameOver;
    [SerializeField] public GameObject GameClear;
    public void Start()
    {
        Debug.Log($"myTime" + GameManager.myTime);
        Debug.Log($"minTime" + GameManager.minTime);

        Debug.Log($"GameOver : {GameManager.Instance.IsGameOver()} ,GameClear : {GameManager.Instance.IsGameClear()}");

        if (GameManager.Instance.IsGameOver())
        {
            GameOver.SetActive(true);
            GameClear.SetActive(false);
        }
        else
        {
            GameOver.SetActive(false);
            GameClear.SetActive(true);
        }
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene("Main");
    }



}
