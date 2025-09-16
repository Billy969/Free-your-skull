using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VignetteEffect : MonoBehaviour
{
    public Volume volume;
    private Vignette vignette;

    void Start()
    {
        // Asegura que el volumen tenga una viñeta
        if (volume.profile.TryGet(out vignette))
        {
            vignette.intensity.value = 0.45f; // Valor inicial
        }
    }

    public void SetVignette(float intensity)
    {
        if (vignette != null)
            vignette.intensity.value = Mathf.Clamp01(intensity);
    }
}