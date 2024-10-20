using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

public class ClickMove1 : MonoBehaviour
{
    public Camera cam;
    public List<Character> selectCharactor = new List<Character>();

    float distance = 10.0f;
    bool move = false;

    private GameObject selectedFurniture;

    private void Update()
    {
        OnMouseDown(); // ���콺 Ŭ�� �� ����Ǵ� �Լ�
        Remaining_(); // �̵��� �Ϸ�Ǿ����� Ȯ���ϴ� �Լ�
 
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ��Ŭ���� ���� ��
        {
            Debug.Log("��Ŭ��!");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // ī�޶� �������� ����ĳ��Ʈ ����

            if (Physics.Raycast(ray, out RaycastHit hit_fir)) // ����ĳ��Ʈ�� ���� ������Ʈ ������ hit_fir�� ����
            {
                Character character = hit_fir.collider.GetComponent<Character>();

                if (hit_fir.collider.gameObject.tag == "Character") // �±װ� ĳ�����̸� ����
                {
                    Debug.Log("ĳ���� Ŭ��!");
                    if (character != null)
                    {
                        character.ClickEvent(cam.transform); // ĳ������ ClickEvent ȣ��
                        selectCharactor.Add(character); // ĳ���� ���� ��Ͽ� �߰�
                    }
                }
                else if (selectCharactor.Count > 0 && hit_fir.collider.gameObject.tag == "Floor") // �ٴ� Ŭ�� ��
                {
                    move = true;
                    Debug.Log("�ٴ� Ŭ��!");

                    foreach (Character character1 in selectCharactor)
                    {
                        character1.MoveEvent(hit_fir.point); // ĳ���͵��� �̵�
                    }
                }
                else if (selectCharactor.Count > 0 && hit_fir.collider.gameObject.tag == "Object") //������Ʈ Ŭ�� ��
                {
                    move = true;
                    Debug.Log("������Ʈ Ŭ��!");


                    foreach (Character character1 in selectCharactor)
                    {
                        character1.MoveEvent(hit_fir.point); // ĳ���͵��� �̵�
                        character1.WorkEvent();
                    }
                }
            }
        }
    }

    public void Remaining_()
    {
        bool end = false;
        if (move) // ĳ���Ͱ� �̵� ���� ���� ����
        {
            foreach (Character character in selectCharactor)
            {
                // �̵��� �Ϸ�Ǿ����� Ȯ��
                if (character.agent.remainingDistance < 0.1f && !character.agent.pathPending)
                {
                    character.StopEvent(); // ĳ���Ͱ� �����ϸ� StopEvent ȣ��
                    end = true;
                    move = false;
                }

            }
            if ( end && selectCharactor.Count != 0)
            {
                selectCharactor.Clear();
               // �̵��� �Ϸ�Ǿ����Ƿ� move ���¸� false�� ����
               end = false;
            }
        }
    }
}
