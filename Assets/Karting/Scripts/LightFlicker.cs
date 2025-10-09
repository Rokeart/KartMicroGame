using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    [Header("Config")]
    public Light targetLight;      // La luz que queremos hacer titilar
    public float interval = 0.5f;  // Tiempo entre encendido y apagado
    public bool startOn = true;    // ¿Empieza encendida?
    public float startOffset = 0f; // Desfase para desincronizar varias luces

    private float timer;
    private bool isOn;

    void Start()
    {
        // Si no asignaste una luz, intenta buscar una en el mismo GameObject
        if (targetLight == null)
            targetLight = GetComponent<Light>();

        isOn = startOn;
        if (targetLight != null)
            targetLight.enabled = isOn;

        timer = startOffset;
    }

    void Update()
    {
        if (targetLight == null) return;

        timer += Time.deltaTime;

        if (timer >= interval)
        {
            isOn = !isOn; // Cambia estado
            targetLight.enabled = isOn;
            timer = 0f;
        }
    }
}
