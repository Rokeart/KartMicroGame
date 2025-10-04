using KartGame.KartSystems;
using UnityEngine;
using static KartGame.KartSystems.ArcadeKart;

public class DoorKnockBack : MonoBehaviour
{
    [SerializeField] StatPowerup powerUp;
    [SerializeField] bool removeOnExit;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ArcadeKart arcadeKart = other.transform.GetComponentInParent<ArcadeKart>();
            if (arcadeKart != null)
            {
                
                powerUp.ElapsedTime = 0;
                Debug.Log("KnockBack");
                arcadeKart.AddPowerup(powerUp);
            }
        }
    }

}
