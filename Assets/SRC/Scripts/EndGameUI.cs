using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameUI : MonoBehaviour
{
    [SerializeField] private GameObject EndMenuUI;

    public static EndGameUI instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void ActiveEndMenu()
    {
        EndMenuUI.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
