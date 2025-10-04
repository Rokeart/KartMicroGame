using UnityEngine;

public class MetroDoorController : MonoBehaviour
{
    [Header("Hinges")]
    public Transform leftHinge;
    public Transform rightHinge;

    [Header("Config")]
    public float openAngle = 90f;       // Ángulo de apertura
    public float speed = 2f;            // Velocidad de rotación
    public float interval = 3f;         // Intervalo entre abrir/cerrar
    public float startOffset = 0f;      // Desfase inicial para desincronizar

   
    private bool isOpen = false;
    private float timer;

    private Quaternion leftClosedRot, rightClosedRot;
    private Quaternion leftOpenRot, rightOpenRot;

    void Start()
    {
        // Guardar rotaciones iniciales (cerradas)
        leftClosedRot = leftHinge.localRotation;
        rightClosedRot = rightHinge.localRotation;

        // Calcular rotaciones abiertas
        leftOpenRot = leftClosedRot * Quaternion.Euler(0, -openAngle, 0);
        rightOpenRot = rightClosedRot * Quaternion.Euler(0, openAngle, 0);

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
            leftHinge.localRotation = Quaternion.Lerp(leftHinge.localRotation, leftOpenRot, Time.deltaTime * speed);
            rightHinge.localRotation = Quaternion.Lerp(rightHinge.localRotation, rightOpenRot, Time.deltaTime * speed);
        }
        else
        {
            leftHinge.localRotation = Quaternion.Lerp(leftHinge.localRotation, leftClosedRot, Time.deltaTime * speed);
            rightHinge.localRotation = Quaternion.Lerp(rightHinge.localRotation, rightClosedRot, Time.deltaTime * speed);
        }
    }

   
}