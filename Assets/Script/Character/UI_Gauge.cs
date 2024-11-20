using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Gauge : MonoBehaviour
{
    public Image gauge; // UI 슬라이더
    public TMP_Text gaugeText;
    public GameObject Finish;
    public Character_2 character; // Character_2 참조

    void Start()
    {
       
        if (character != null)
        {
            // Character_2의 OnProgressChanged 이벤트에 대한 핸들러 등록
            character.OnProgressChanged += UpdateProgress;
            
        }
    }

    void UpdateProgress()
    {
        // Character_2에서 currentProgress 값 비율로 슬라이더 업데이트
        float progress = character.GetProgress(); // GetProgress 메소드 사용
        gauge.fillAmount = progress; // 슬라이더 값 설정
        gaugeText.text = progress.ToString() ;
    
    }

    void OnDestroy()
    {
        // 오브젝트가 파괴될 때 이벤트 핸들러 제거
        if (character != null)
        {
            character.OnProgressChanged -= UpdateProgress;
        }
    }
}