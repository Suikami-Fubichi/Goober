using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScreen : MonoBehaviour
{
   public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
