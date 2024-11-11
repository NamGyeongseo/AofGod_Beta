using UnityEngine;
using UnityEngine.UI;

public class ItemButtonController : MonoBehaviour
{
    public Inventory inventory;             // 인벤토리 참조
    public InventoryUI inventoryUI;         // 인벤토리 UI 참조
    public FurnitureData itemToAdd;              // 버튼으로 추가할 아이템 참조
    public Button addButton;                // 버튼 컴포넌트 참조

    void Start()
    {
        // 버튼 클릭 이벤트에 메서드 연결
        addButton.onClick.AddListener(AddItemToInventory);
    }

    void AddItemToInventory()
    {
        if (itemToAdd != null)
        {
            inventory.AddItem(itemToAdd);       // 인벤토리에 아이템 추가
            inventoryUI.UpdateUI();             // UI 업데이트
            Debug.Log($"{itemToAdd.FurnitureName}이(가) 인벤토리에 추가되었습니다.");
        }
        else
        {
            Debug.LogWarning("아이템이 지정되지 않았습니다.");
        }
    }
}
