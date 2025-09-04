using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Gameplay gameplay; // Drag Gameplay GameObject into this slot in Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            gameplay.DamagePlayer(10);
        }
    }
}
