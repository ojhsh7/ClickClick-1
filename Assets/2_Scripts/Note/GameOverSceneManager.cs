using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneManager : MonoBehaviour
{
    // ���� ���� ó��
    public void GameOver()
    {
        // ���� ���� �� ó���� �۾��� ���⿡ �߰��մϴ�.
        Debug.Log("GameOVER");

        // ���� ���� �� �ٸ� ������ �̵��մϴ�. (��: ���� ���� ȭ��)
        SceneManager.LoadScene("main");
    }
}
 
    

