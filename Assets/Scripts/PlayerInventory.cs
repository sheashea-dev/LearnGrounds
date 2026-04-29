using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    // NumberOfItems can only be set in this class, but other scripts can get the value (see it)
    public int NumberOfItems {  get; private set; }
    public UnityEvent<PlayerInventory> OnItemsCollected;

    public void ItemsCollected()
    {
        /*
        When an item is collected, as called by the CollectableItem script,
        this method will be called by the event, increasing the number of items
        */
        NumberOfItems++;
        OnItemsCollected.Invoke(this);
        Debug.Log("You collected an item!");
    }
}
