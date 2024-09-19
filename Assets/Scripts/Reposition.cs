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
        float diffX = Mathf.Abs(playerPos.x - myPos.x);         // x�� �Ÿ�
        float diffY = Mathf.Abs(playerPos.y - myPos.y);         // y�� �Ÿ�

        Vector3 playerDir = GameManager.instance.player.inputVec;       // �÷��̾��� �̵� ���� ����
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;
    
        switch(transform.tag)
        {
            case "Ground":
                if(diffX > diffY)       // x�� ���� �Ÿ����̰� y�ຸ�� Ŭ ��� (x>y�����θ� �־��� ��)
                {
                    transform.Translate(Vector3.right * dirX * 100);         // ���� dirX �������� 72��ŭ ���Ͽ� �̵�
                }
                else if(diffX < diffY)       // y�� ���� �Ÿ����̰� x�ຸ�� Ŭ ��� (y>x�����θ� �־��� ��)
                {
                    transform.Translate(Vector3.up * dirY * 100);            // ���� dirY �������� 40��ŭ ���Ͽ� �̵�
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
