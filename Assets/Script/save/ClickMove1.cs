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
        OnMouseDown(); // 마우스 클릭 시 실행되는 함수
        Remaining_(); // 이동이 완료되었는지 확인하는 함수
 
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 좌클릭을 했을 때
        {
            Debug.Log("좌클릭!");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 카메라를 기준으로 레이캐스트 생성

            if (Physics.Raycast(ray, out RaycastHit hit_fir)) // 레이캐스트에 맞은 오브젝트 정보를 hit_fir에 저장
            {
                Character character = hit_fir.collider.GetComponent<Character>();

                if (hit_fir.collider.gameObject.tag == "Character") // 태그가 캐릭터이면 실행
                {
                    Debug.Log("캐릭터 클릭!");
                    if (character != null)
                    {
                        character.ClickEvent(cam.transform); // 캐릭터의 ClickEvent 호출
                        selectCharactor.Add(character); // 캐릭터 선택 목록에 추가
                    }
                }
                else if (selectCharactor.Count > 0 && hit_fir.collider.gameObject.tag == "Floor") // 바닥 클릭 시
                {
                    move = true;
                    Debug.Log("바닥 클릭!");

                    foreach (Character character1 in selectCharactor)
                    {
                        character1.MoveEvent(hit_fir.point); // 캐릭터들을 이동
                    }
                }
                else if (selectCharactor.Count > 0 && hit_fir.collider.gameObject.tag == "Object") //오브젝트 클릭 시
                {
                    move = true;
                    Debug.Log("오브젝트 클릭!");


                    foreach (Character character1 in selectCharactor)
                    {
                        character1.MoveEvent(hit_fir.point); // 캐릭터들을 이동
                        character1.WorkEvent();
                    }
                }
            }
        }
    }

    public void Remaining_()
    {
        bool end = false;
        if (move) // 캐릭터가 이동 중일 때만 실행
        {
            foreach (Character character in selectCharactor)
            {
                // 이동이 완료되었는지 확인
                if (character.agent.remainingDistance < 0.1f && !character.agent.pathPending)
                {
                    character.StopEvent(); // 캐릭터가 도착하면 StopEvent 호출
                    end = true;
                    move = false;
                }

            }
            if ( end && selectCharactor.Count != 0)
            {
                selectCharactor.Clear();
               // 이동이 완료되었으므로 move 상태를 false로 설정
               end = false;
            }
        }
    }
}
