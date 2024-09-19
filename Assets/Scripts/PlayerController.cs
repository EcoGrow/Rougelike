using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Scanner scanner;
    public Vector2 inputVec;       // 플레이어 이동 벡터
    Rigidbody2D rigid;      // 플레이어 물리 효과
    SpriteRenderer sprite;  // 스프라이트 렌더러 제어
    Animator anim;          // 플레이어 애니메이션

    float speed = 3f;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
    }

    void FixedUpdate()
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;       // 플레이어의 이동 방향 벡터
        rigid.MovePosition(rigid.position + nextVec);       // 플레이어의 위치 이동
    }

    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);

        if(inputVec.x != 0)
        {
            sprite.flipX = inputVec.x < 0;
        }
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
