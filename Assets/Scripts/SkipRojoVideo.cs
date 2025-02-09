using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SkipRojoVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string escenaDestino = "Menu"; // Cambia por el nombre de la escena a la que quieres ir
    public float tiempoMantener = 2.0f; // Tiempo que hay que mantener ESC
    private float tiempoPresionado = 0f; 
    public GameObject mensajeUI;
    public Image fadePanel;  // Panel de transición
    public float fadeDuration = 1.5f; // Duración del fade-out

    void Start()
    {
        videoPlayer.loopPointReached += IniciarFadeOut;
        if (fadePanel != null)
        {
            fadePanel.color = new Color(0, 0, 0, 0);
            fadePanel.gameObject.SetActive(true);
        }
    }

    void IniciarFadeOut(VideoPlayer vp)
    {
        StartCoroutine(FadeOutAndChangeScene());
    }
    IEnumerator FadeOutAndChangeScene()
    {
        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadePanel.color = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, t / fadeDuration);
            yield return null;
        }
        videoPlayer.Stop();
        SceneManager.LoadScene(escenaDestino); // Cambia de escena al finalizar el fade-out
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
        IniciarFadeOut(videoPlayer);
    }
}

