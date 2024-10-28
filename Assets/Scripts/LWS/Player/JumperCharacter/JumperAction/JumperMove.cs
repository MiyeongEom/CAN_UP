using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperMove : PlayerAction
{
    private JumperData _jumperData;

    private Rigidbody _rigidbody;


    // DoAction 재정의
    public override BTNodeState DoAction()
    {
        // JumperData, Rigidbody 가져오기
        _jumperData = GameObject.FindObjectOfType<JumperData>();

        _rigidbody = GameObject.FindObjectOfType<Rigidbody>();

        // A,D 입력시 이동 진행
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && !Input.GetKey(KeyCode.Space))
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            _rigidbody.velocity = new Vector3(horizontalInput * _jumperData.MoveSpeed, _rigidbody.velocity.y, _rigidbody.velocity.z);
            Debug.Log("이동 중");
            return BTNodeState.Running;
        }
        // 미 입력 시 Failure 반환
        else
        {
            return BTNodeState.Failure;
        }
    }
}
