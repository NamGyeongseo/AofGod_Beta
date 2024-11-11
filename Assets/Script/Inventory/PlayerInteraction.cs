using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Inventory inventory;
    public InventoryUI inventoryUI;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            var itemComponent = other.GetComponent<ItemComponent>();
            if (itemComponent != null)
            {
                inventory.AddItem(itemComponent.itemData);
                inventoryUI.UpdateUI(); // UI 업데이트
                Destroy(other.gameObject); // 아이템 오브젝트 제거
            }
        }
    }

}
