using UnityEngine;
/*
Attach to each enemy and it will do damage to the player on collision
*/
public class EnemyCombat : MonoBehaviour
{
    public bool playerInRange;
    public float attackDamage = 40f;
    [SerializeField] private PlayerCombat playerCombat; // Reference the script on the player to access our players health
    [SerializeField] private Healthbar healthbar;

    private void Awake()
    {
        playerInRange = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            DoDamage(attackDamage);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerInRange = false;
    }

    private void DoDamage(float damage)
    {
        if (playerInRange)
        {
           playerCombat.currentHealth -= damage; // Deduct damage value from the players health when the trigger is entered
           healthbar.UpdateHealthBar(playerCombat.maxHealth, playerCombat.currentHealth);
           Debug.Log("Player damaged");
        }
    }
}
