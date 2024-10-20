using UnityEngine.AI;
using UnityEngine;
using System;
using UnityEngine.TextCore.Text;

public class Character : MonoBehaviour
{
    public NavMeshAgent agent; // ������Ʈ�� ������ ����
    Animator anim;

    bool Select = false;

    public void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        
    }

    public void ClickEvent(Transform look)
    {
        transform.LookAt(look); // ĳ���� Ŭ�� �� ���� ���� �ϱ�
        anim.SetBool("click", true); // ĳ���� Ŭ�� �� Ŭ�� �ִϸ��̼� ���
        Select = true; // ĳ���� ���� ������ ǥ��

        Debug.Log("ĳ���� ���õ�");
    }

    public void MoveEvent(Vector3 hit_fir)
    {
        agent.SetDestination(hit_fir); // �������� �̵�
        anim.SetBool("click", false);
        anim.SetBool("move", true);

        Select = false;
        

    }

    public void StopEvent()
    {
            Debug.Log("���� ����!");
            anim.SetBool("move", false);
 
        
    }
    public void WorkEvent()
    {
        Debug.Log("���ϱ�!");
        anim.SetBool("work", true);


    }

}