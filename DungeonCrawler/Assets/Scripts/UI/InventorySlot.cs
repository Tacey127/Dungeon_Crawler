using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Button selectionButton;
    [SerializeField] Image icon;

    [SerializeField] Button closeButton;
    [SerializeField] Image closeImage;

    public Inventory inventory;

    Item item;
    public void AddItem(Item newItem)
    {
        item = newItem;

        //text.text = item.name;
        //text.enabled = true;
        icon.sprite = item.icon;

        closeImage.enabled = true;

        selectionButton.interactable = true;
        closeButton.interactable = true;
    }

    public void ClearSlot()
    {
        //text.text = "";
       // text.enabled = false;

        icon.sprite = null;
        icon.enabled = false;

        closeImage.enabled = false;

        selectionButton.interactable = false;
        closeButton.interactable = false;
    }

    public void OnSelectionButton()
    {
        Debug.Log("ItemSelected");
        item.Use();
    }

    public void OnRemoveButton()
    {
        Debug.Log("ItemRemoved");
        inventory.Remove(item);
    }

}
