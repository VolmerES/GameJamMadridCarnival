using UnityEngine;
using System.Collections;

public class CambioDisfrazTemporal : MonoBehaviour
{
    public Material disfrazMaterial; // Material del disfraz
    private Material materialOriginal;
    private SkinnedMeshRenderer personajeRenderer; // Cambia a SkinnedMeshRenderer

    void Start()
    {
        personajeRenderer = GetComponentInChildren<SkinnedMeshRenderer>(); // Busca en hijos
        if (personajeRenderer != null)
        {
            materialOriginal = personajeRenderer.material; // Guarda el material original
        }
        else
        {
            Debug.LogError("No se encontró un SkinnedMeshRenderer en el personaje.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ObjetoDisfraz") && personajeRenderer != null)
        {
            StartCoroutine(CambiarDisfrazTemporal());
            Destroy(other.gameObject);
        }
    }

    IEnumerator CambiarDisfrazTemporal()
    {
        personajeRenderer.material = disfrazMaterial;
        yield return new WaitForSeconds(5);
        personajeRenderer.material = materialOriginal;
    }
}
