using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButtonHandler : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;

    public void PressSaveAndExit()
    {
        Time.timeScale = 1f;
        scoreManager.SaveScore();
        SceneManager.LoadScene(0);
    }

    public void PressMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
