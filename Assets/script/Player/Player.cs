using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("기본 속도")]
    [SerializeField] private float speed = 10.0f; // 기본 속도 변수
    [Header("달리기 속도")]
    [SerializeField] private float runSpeed = 1.5f; // 달리기 속도 변수
    [Header("점프 파워")]
    [SerializeField] private float jumpPower = 5.0f; // 점프 파워 변수

    private float hAxis;    // 앞뒤 
    private float vAxis;    // 좌우

    bool isRun;    // shift 눌렸는지 아닌지 확인
    bool isJump;    // spaceBar 눌렸는지 아닌지 확인
    
    Vector3 moveVec;
    Rigidbody rigid;
    
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    
    public void PlayerController() //플레이어 움직임 제어 함수
    {
        GetInput();
        Move();
        Turn();
        Jump();
    }
    public void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        isRun = Input.GetButton("Run");
        isJump = Input.GetButtonDown("Jump");
    }

    public void Move()//플레이어 움직임
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        if (isRun)
            transform.position += moveVec * (speed * runSpeed * Time.deltaTime);//달리기 속도
        else
            transform.position += moveVec * (speed * Time.deltaTime);//걷기(외부에서 설정)
    }

    public void Turn()//플레이어가 움직임에 따라 몸 돌기
    {
        transform.LookAt(transform.position + moveVec);
    }

    void Jump()//점프
    {
        if (isJump)
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJump= true;
        }
    }
}
