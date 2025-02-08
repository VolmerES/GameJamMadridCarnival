using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource gameplay1Source; // Primer audio
    public AudioSource gameplay2Source; // Segundo audio
    private bool isPlayingGameplay1 = true; // Para controlar qué canción se está reproduciendo

    void Start()
    {
        // Inicia la primera canción
        gameplay1Source.Play();
        gameplay1Source.loop = false; // Desactivamos el loop porque haremos la transición manualmente

        // Iniciar la rutina para alternar las canciones
        StartCoroutine(SwapMusic());
    }

    System.Collections.IEnumerator SwapMusic()
    {
        while (true) // Se repetirá hasta que termine el juego
        {
            // Espera hasta que la canción actual termine
            yield return new WaitForSeconds(isPlayingGameplay1 ? gameplay1Source.clip.length : gameplay2Source.clip.length);

            // Alternar entre las canciones
            if (isPlayingGameplay1)
            {
                gameplay1Source.Stop();
                gameplay2Source.Play();
            }
            else
            {
                gameplay2Source.Stop();
                gameplay1Source.Play();
            }

            isPlayingGameplay1 = !isPlayingGameplay1; // Cambia el estado para la próxima vez
        }
    }

    public void StopMusic()
    {
        gameplay1Source.Stop();
        gameplay2Source.Stop();
        StopAllCoroutines(); // Detiene la alternancia de canciones
    }
}
