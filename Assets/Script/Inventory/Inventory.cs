using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<FurnitureData> items = new List<FurnitureData>(); // 아이템 리스트

    // 아이템 추가 메서드
    public void AddItem(FurnitureData newItem)
    {
        items.Add(newItem);
        Debug.Log($"{newItem.FurnitureName}이(가) 인벤토리에 추가되었습니다.");
    }

    // 아이템 제거 메서드
    public void RemoveItem(FurnitureData item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log($"{item.FurnitureName}이(가) 인벤토리에서 제거되었습니다.");
        }
    }

    // 인벤토리의 모든 아이템을 출력하는 메서드 (디버깅용)
    public void DisplayInventory()
    {
        Debug.Log("인벤토리 목록:");
        foreach (var item in items)
        {
            Debug.Log($"아이템: {item.FurnitureName} | 설명: {item.FurnitureName}");
        }
    }
}