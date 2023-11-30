using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    public Animator animator; // 动画控制器的引用
    private Vector3 previousPosition; // 上一个位置

    // Start is called before the first frame update
    void Start()
    {
        // 设置初始位置
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 获取当前位置
        Vector3 currentPosition = transform.position;

        // 计算当前位置与上一个位置的距离
        float distance = Vector3.Distance(currentPosition, previousPosition);

        // 判断是否移动
        bool IsMoving = distance > 0.01f; // 设置一个阈值来判断是否移动

        // 更新Animator参数
        animator.SetBool("IsMoving", IsMoving);

        // 更新上一个位置
        previousPosition = currentPosition;
    }
}
