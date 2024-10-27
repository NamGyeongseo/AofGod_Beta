using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Gauge : MonoBehaviour
{
    // 싱글턴 인스턴스 설정
    public static UI_Gauge Instance { get; private set; }

    // 게이지 및 텍스트 UI 요소 참조
    public Image gauge; // 채워지는 이미지(게이지)
    public TextMeshProUGUI gaugeText; // 진행률 텍스트

    private void Awake()
    {
    }

    private void Start()
    {
        // 초기 진행률 설정
        SetGauge(0f);
    }

    // 진행률을 설정하는 메서드
    public void SetGauge(float progress)
    {
        gauge.fillAmount = progress; // 이미지의 채워진 정도를 설정 (0~1 사이 값)
        gaugeText.text = $"{(progress * 100):0}%"; // 진행률을 텍스트로 표시 (예: 75%)
    }
}
