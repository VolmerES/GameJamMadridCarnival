using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SkipVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string escenaDestino = "Intro2";
    public float tiempoMantener = 2.0f;
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
        if (Input.GetKey(KeyCode.Escape))
        {
            tiempoPresionado += Time.deltaTime;

            if (mensajeUI != null)
            {
                mensajeUI.SetActive(true);
            }

            if (tiempoPresionado >= tiempoMantener)
            {
                SaltarVideo();
            }
        }
        else
        {
            tiempoPresionado = 0f;
            if (mensajeUI != null)
            {
                mensajeUI.SetActive(false);
            }
        }
    }

    void SaltarVideo()
    {
        IniciarFadeOut(videoPlayer);
    }
}

