using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    public GameObject mensajeUI;// Asigna un objeto de texto UI en el Inspector
    public float tiempoVisible = 3.0f; // Duración en segundos

    void Start()
    {
        if (mensajeUI != null)
        {
            mensajeUI.gameObject.SetActive(true); // Muestra el texto
            Invoke("OcultarMensaje", tiempoVisible); // Llama a la función después de 5s
        }
    }

    void OcultarMensaje()
    {
        mensajeUI.gameObject.SetActive(false); // Oculta el texto
    }
}

