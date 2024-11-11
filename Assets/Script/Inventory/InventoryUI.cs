using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel; // 인벤토리 패널 UI
    public GameObject slotPrefab;     // 아이템 슬롯 프리팹
    public Inventory inventory;       // 인벤토리 클래스 참조
    public Button addItemButton;      // 아이템 추가 버튼
    public FurnitureData itemToAdd;        // 추가할 아이템

    void Start()
    {
        inventoryPanel.SetActive(false); // 인벤토리 시작 시 비활성화

        // 버튼 클릭 이벤트에 메서드 추가
        addItemButton.onClick.AddListener(AddItemToInventory);
    }

    public void UpdateUI()
    {
        // 기존 슬롯 제거
        foreach (Transform child in inventoryPanel.transform)
        {
            Destroy(child.gameObject);
        }

        // 인벤토리의 각 아이템을 UI에 추가
        foreach (var item in inventory.items)
        {
            GameObject slot = Instantiate(slotPrefab, inventoryPanel.transform);
            slot.transform.Find("ItemImage").GetComponent<Image>().sprite = item.icon;
            slot.transform.Find("ItemName").GetComponent<Text>().text = item.FurnitureName;
          
        }
    }

    public void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        UpdateUI();
    }

    // 버튼 클릭 시 아이템을 인벤토리에 추가하는 메서드
    private void AddItemToInventory()
    {
        if (itemToAdd != null)
        {
            inventory.AddItem(itemToAdd);
            UpdateUI(); // UI 업데이트
        }
    }
}
