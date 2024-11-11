using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class ProgressManager : MonoBehaviour
{
    public Image gauge; // UI 슬라이더 참조
    public TMP_Text gaugeText;
    public List<Character_2> characters; // 캐릭터 리스트
    public GameObject finish;

    private float maxTotalProgress = 100f;

    void Start()
    {
        maxTotalProgress = characters.Count * 100f; // 캐릭터 수에 따라 최대 진행률 설정
        foreach (var character in characters)
        {
            // 각 캐릭터의 진행률 변경 이벤트에 핸들러 등록
            character.OnProgressChanged += UpdateTotalProgress;
        }
    }

    void UpdateTotalProgress()
    {
        float currentTotalProgress = 0f;

        // 모든 캐릭터의 현재 진행률을 합산
        foreach (var character in characters)
        {
            currentTotalProgress += character.GetProgress() * 100; // 비율을 값으로 변환
        }

        // 합산된 진행률을 슬라이더에 반영
        gauge.fillAmount = (currentTotalProgress /maxTotalProgress);
        gaugeText.text = ((currentTotalProgress / maxTotalProgress) * 100).ToString() + "%"; // 슬라이더 값 설정
        if ( currentTotalProgress >= maxTotalProgress)
        {
            Debug.Log("progress is 100");
            finish.SetActive(true);
        }
        //gaugeText.text = progress.ToString();

    }

    void OnDestroy()
    {
        // 오브젝트가 파괴될 때 이벤트 핸들러 제거
        foreach (var character in characters)
        {
            character.OnProgressChanged -= UpdateTotalProgress;
        }
    }
}
