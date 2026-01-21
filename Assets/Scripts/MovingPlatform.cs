using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Define the Player GameObject, we're letting the script know what it is
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        /*
        "Parenting" the player to the platform here, or making the player a "Child" of the platform
        essentially attaches it, as the child will move along with the parent
        */
        if (other.gameObject == player)
        {
            Debug.Log("Player attached to the moving platform!");
            player.transform.parent = transform; // Setting a game object's "parent" is basically the same as attaching the object to it
        }
    }

    private void OnTriggerExit(Collider other)
    {
        /*
        OnTriggerExit is useful for undoing or reversing the action you trigger in OnTriggerEnter
        like parenting objects or having a sound play only while inside the trigger zone
        */
        if (other.gameObject == player)
        {
            Debug.Log("Player detached from the moving platform!");
            player.transform.parent = null;
        }
    }
}
