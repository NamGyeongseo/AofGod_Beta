using UnityEngine.AI;
using UnityEngine;
using System;
using UnityEngine.TextCore.Text;
using UnityEditor;

public class Character_2 : MonoBehaviour
{
    public event Action OnProgressChanged;
    private float maxProgress = 100f;
    private static float currentProgress = 0f;

    float DeskWork = 5f;
    float FlowerWork = 2f;

    public NavMeshAgent agent; // 에이전트의 정보를 얻음
    Animator anim;

    bool Select = false;
    bool Work = false;

    public void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        
    }

    public void ClickEvent(Transform look)
    {
        transform.LookAt(look); // 캐릭터 클릭 시 정면 보게 하기
        anim.SetBool("click", true); // 캐릭터 클릭 시 클릭 애니메이션 재생
        Select = true; // 캐릭터 선택 중임을 표시

        Debug.Log("캐릭터 선택됨");
    }

    public void MoveEvent(Vector3 hit_fir)
    {
        agent.SetDestination(hit_fir); // 목적지로 이동
        anim.SetBool("click", false);
        anim.SetBool("move", true);

        Select = false;
        

    }

    public void StopEvent()
    {
            Debug.Log("멈춤 실행!");
            anim.SetBool("move", false);
         


    }
    public void WorkEvent(RaycastHit hit_fir)
    {
        Debug.Log("일하기!");
        anim.SetBool("work", true);
        
        gameObject.transform.position = hit_fir.point;
        gameObject.transform.rotation = hit_fir.transform.rotation;

        if (hit_fir.collider.gameObject.tag =="Desk_1")
        {
            ExecuteTask(DeskWork);
            Invoke("Work_End", 10f);
        }
        if (hit_fir.collider.gameObject.tag == "Flower_1")
        {
            ExecuteTask(FlowerWork);
            Invoke("Work_End", 5f);
        }
    }

  

    public void Work_End()
    {
        Debug.Log("멈춤 실행!");
        anim.SetBool("work", false);
        
    }

   // public float GetProgress()
   // {
  //      return currentProgress / maxProgress;
   // }
    // 업무 실행 시 진행률을 업데이트
    public void ExecuteTask(float amount)
    {
        
        currentProgress += amount;
        currentProgress = Mathf.Clamp(currentProgress, 0, maxProgress); // 0에서 100%로 제한
        Debug.Log(amount);
        UI_Gauge.Instance.SetGauge(currentProgress);
    }
}