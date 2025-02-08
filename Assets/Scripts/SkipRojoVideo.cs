using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkipRojoVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string escenaDestino = "Menu"; // Cambia por el nombre de la escena a la que quieres ir
    public float tiempoMantener = 2.0f; // Tiempo que hay que mantener ESC
    private float tiempoPresionado = 0f; 
    public GameObject mensajeUI;

    void Start()
    {
        videoPlayer.loopPointReached += CambiarEscena;
    }

    void CambiarEscena(VideoPlayer vp)
    {
        SceneManager.LoadScene(escenaDestino); 
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) // Si se mantiene pulsado ESC
        {
            tiempoPresionado += Time.deltaTime;

            if (mensajeUI != null)
            {
                mensajeUI.SetActive(true); // Muestra el mensaje
            }

            if (tiempoPresionado >= tiempoMantener) // Si pasa el tiempo necesario
            {
                SaltarVideo();
            }
        }
        else
        {
            tiempoPresionado = 0f; // Resetea el tiempo si se deja de pulsar
            if (mensajeUI != null)
            {
                mensajeUI.SetActive(false); // Oculta el mensaje
            }
        }
    }

    void SaltarVideo()
    {
        videoPlayer.Stop(); // Detiene el video
        SceneManager.LoadScene(escenaDestino); // Cambia de escena
    }
}

