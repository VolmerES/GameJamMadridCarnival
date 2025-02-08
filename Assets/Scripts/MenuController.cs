using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.instance.LoadScene("Demo"); // Carga la escena del juego
    }

    public void QuitGame()
    {
        GameManager.instance.QuitGame(); // Sale del juego
    }
}
