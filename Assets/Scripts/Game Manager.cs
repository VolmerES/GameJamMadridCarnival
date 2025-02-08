using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Permite que el GameManager persista entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Cargar una escena por nombre
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Cargar la siguiente escena en la lista de Build Settings
    public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    // Recargar la escena actual
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Cargar la escena de Game Over
    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    // Cargar la escena de Victoria
    public void LoadVictory()
    {
        SceneManager.LoadScene("Victoria");
    }

    // Volver al Menú
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    // Salir del juego
    public void QuitGame()
    {
        Application.Quit();
    }
}
