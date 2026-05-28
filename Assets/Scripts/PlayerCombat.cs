using UnityEngine;
/*
 Attach to player to handle its health and death
 */

public class PlayerCombat : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    //public GameObject gameOverUI;
    //public GameObject gameWinUI;
    public Camera cam;
    public PlayerInventory playerInventory;

    void Start()
    {
        //gameOverUI.SetActive(false);
        currentHealth = maxHealth;
        playerInventory = GetComponent<PlayerInventory>();
    }

    void Update()
    {
        if (currentHealth <= 0f)
        {
            PlayerDie();
        } 

        if (playerInventory.NumberOfItems == 15)
        {
            WinGame();
        }
    }

    private void PlayerDie()
    {
        cam.transform.parent = null; // Remove camera from player just to prevent errors
        gameObject.SetActive(false); // Disabling the object instead of destroying will prevent errors
        //gameOverUI.SetActive(true);
    }

    public void WinGame()
    {
        cam.transform.parent = null;
        gameObject.SetActive(false); 
        //gameWinUI.SetActive(true);
    }
}
