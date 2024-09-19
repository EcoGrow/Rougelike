using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    Collider2D collider;

    void Awake()
    {
        collider = GetComponent<Collider2D>();
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (!coll.CompareTag("Area")) return;

        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = this.transform.position;
        float diffX = Mathf.Abs(playerPos.x - myPos.x);         // x축 거리
        float diffY = Mathf.Abs(playerPos.y - myPos.y);         // y축 거리

        Vector3 playerDir = GameManager.instance.player.inputVec;       // 플레이어의 이동 방향 저장
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;
    
        switch(transform.tag)
        {
            case "Ground":
                if(diffX > diffY)       // x축 간의 거리차이가 y축보다 클 경우 (x>y축으로만 멀어진 것)
                {
                    transform.Translate(Vector3.right * dirX * 100);         // 맵을 dirX 방향으로 72만큼 곱하여 이동
                }
                else if(diffX < diffY)       // y축 간의 거리차이가 x축보다 클 경우 (y>x축으로만 멀어진 것)
                {
                    transform.Translate(Vector3.up * dirY * 100);            // 맵을 dirY 방향으로 40만큼 곱하여 이동
                }
                break;

            case "Enemy":
                if(collider.enabled)
                {
                    transform.Translate(playerDir * 50 + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f));
                }
                break;
        }
    }
}
