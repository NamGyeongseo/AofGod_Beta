using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture_: MonoBehaviour
{
    [SerializeField]
    private FurnitureData furnitureData;
    public FurnitureData FurnitureData { set { furnitureData = value; } }

    public int Work;

    private void Awake()
    {
        if (furnitureData != null)  // Null 체크를 추가해 안전성 확보
        {
            Work = furnitureData.WorkRange;  // 클래스 필드 Work에 할당
        }
        else
        {
            Debug.LogWarning("FurnitureData가 설정되지 않았습니다!");
        }
    }
}
