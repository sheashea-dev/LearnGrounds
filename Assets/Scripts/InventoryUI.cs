using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    // This script will have our UI score update as we collect each item.

    private TextMeshProUGUI itemText;

    void Start()
    {
        itemText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateItemText(PlayerInventory playerInventory)
    {
        /*
        Here we access the NumberOfItems variable from the PlayerInventory script
        and have it shown as a readable string in the UI
        */
        itemText.text = playerInventory.NumberOfItems.ToString();
    }

}
