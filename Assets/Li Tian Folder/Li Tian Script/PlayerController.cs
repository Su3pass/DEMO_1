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
    private float moveSpeed = 15f; // 移动速度

    private int count;
    public TextMeshProUGUI countText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
    }

    // 输入事件：接收方向键输入
    public void OnMove(InputValue moveValue)
    {
        Vector2 moveVector = moveValue.Get<Vector2>();
        moveX = moveVector.x;
        moveY = moveVector.y;
    }

    // 物理更新：直接设置速度
    public void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveX, 0.0f, moveY).normalized * moveSpeed;
        rb.velocity = movement; // 直接设置速度，无惯性
    }

    // 碰撞触发：处理收集物
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pickup"))
        {
            Destroy(other.gameObject); // 销毁收集物
            count += 1;
            SetCountText();
        }
    }

    // 更新分数显示
    public void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
    }
}