using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Scanner scanner;
    public Vector2 inputVec;       // �÷��̾� �̵� ����
    Rigidbody2D rigid;      // �÷��̾� ���� ȿ��
    SpriteRenderer sprite;  // ��������Ʈ ������ ����
    Animator anim;          // �÷��̾� �ִϸ��̼�

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
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;       // �÷��̾��� �̵� ���� ����
        rigid.MovePosition(rigid.position + nextVec);       // �÷��̾��� ��ġ �̵�
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
