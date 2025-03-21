using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float moveX;
    private float moveY;
    private float moveSpeed = 15f; // �ƶ��ٶ�

    private int count;
    public TextMeshProUGUI countText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
    }

    // �����¼������շ��������
    public void OnMove(InputValue moveValue)
    {
        Vector2 moveVector = moveValue.Get<Vector2>();
        moveX = moveVector.x;
        moveY = moveVector.y;
    }

    // ������£�ֱ�������ٶ�
    public void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveX, 0.0f, moveY).normalized * moveSpeed;
        rb.velocity = movement; // ֱ�������ٶȣ��޹���
    }

    // ��ײ�����������ռ���
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pickup"))
        {
            Destroy(other.gameObject); // �����ռ���
            count += 1;
            SetCountText();
        }
    }

    // ���·�����ʾ
    public void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
    }
}