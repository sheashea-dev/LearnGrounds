using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class PlayerInventory : MonoBehaviour
{
    // NumberOfItems can only be set in this class, but other scripts can get the value (see it)
    public int NumberOfItems {  get; private set; }
    public UnityEvent<PlayerInventory> OnItemsCollected;
    public GameObject coinUiText;
    public AudioClip coinSFX;

    public void ItemsCollected()
    {
        /*
        When an item is collected, as called by the CollectableItem script,
        this method will be called by the event, increasing the number of items
        */
        NumberOfItems++;
        coinUiText.transform.DOScale(1.5f, 0.2f).OnComplete(() => coinUiText.transform.DOScale(1f, 0.2f));
        SoundManagerSO.PlaySoundFXClip(coinSFX, transform.position, 1f, 0f, 0f);
        OnItemsCollected.Invoke(this);
        Debug.Log("You collected an item!");
    }
}
