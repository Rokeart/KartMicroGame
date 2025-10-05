using UnityEngine;

public class DoorController : MonoBehaviour
{
    [Header("Hinge")]
    public Transform hinge;             // Único pivote de la puerta

    [Header("Config")]
    public float openAngle = 90f;       // Ángulo de apertura
    public float speed = 2f;            // Velocidad de rotación
    public float interval = 3f;         // Intervalo entre abrir/cerrar
    public float startOffset = 0f;      // Desfase inicial para desincronizar

    private bool isOpen = false;
    private float timer;

    private Quaternion closedRot;
    private Quaternion openRot;

    void Start()
    {
        // Guardar rotación inicial (cerrada)
        closedRot = hinge.localRotation;

        // Calcular rotación abierta (en el eje Y)
        openRot = closedRot * Quaternion.Euler(0, openAngle, 0);

        // Aplicar desfase inicial
        timer = startOffset;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            isOpen = !isOpen;
            timer = 0f;
        }

        // Transición suave entre cerrado y abierto
        if (isOpen)
        {
            hinge.localRotation = Quaternion.Lerp(hinge.localRotation, openRot, Time.deltaTime * speed);
        }
        else
        {
            hinge.localRotation = Quaternion.Lerp(hinge.localRotation, closedRot, Time.deltaTime * speed);
        }
    }
}
