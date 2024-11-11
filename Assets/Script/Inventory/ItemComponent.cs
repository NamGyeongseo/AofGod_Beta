using UnityEngine;

public class ItemComponent : MonoBehaviour
{
    [SerializeField]
    public FurnitureData itemData; // 참조할 ScriptableObject 아이템 데이터
    public FurnitureData ItemData { set { itemData = value; } }

    public int Work;

    private void Awake()
    {
        if (itemData != null)  // Null 체크를 추가해 안전성 확보
        {
            Work = itemData.WorkRange;  // 클래스 필드 Work에 할당
        }
        else
        {
            Debug.LogWarning("itemData가 설정되지 않았습니다!");
        }
    }
}
