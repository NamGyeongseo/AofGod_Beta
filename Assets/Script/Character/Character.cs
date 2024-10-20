using UnityEngine.AI;
using UnityEngine;
using System;
using UnityEngine.TextCore.Text;

public class Character : MonoBehaviour
{
    public NavMeshAgent agent; // 에이전트의 정보를 얻음
    Animator anim;

    bool Select = false;

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
    public void WorkEvent()
    {
        Debug.Log("일하기!");
        anim.SetBool("work", true);


    }

}