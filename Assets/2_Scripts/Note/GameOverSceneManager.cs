using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneManager : MonoBehaviour
{
    // 게임 오버 처리
    public void GameOver()
    {
        // 게임 오버 후 처리할 작업을 여기에 추가합니다.
        Debug.Log("GameOVER");

        // 게임 오버 후 다른 씬으로 이동합니다. (예: 게임 오버 화면)
        SceneManager.LoadScene("main");
    }
}
 
    

