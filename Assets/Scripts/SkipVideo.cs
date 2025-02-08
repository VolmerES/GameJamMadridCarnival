using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkipVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string escenaDestino = "Intro2";
    public float tiempoMantener = 2.0f;
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
        videoPlayer.Stop();
        SceneManager.LoadScene(escenaDestino);
    }
}

