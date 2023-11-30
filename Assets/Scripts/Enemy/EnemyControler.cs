using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    public Animator animator; // ����������������
    private Vector3 previousPosition; // ��һ��λ��

    // Start is called before the first frame update
    void Start()
    {
        // ���ó�ʼλ��
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // ��ȡ��ǰλ��
        Vector3 currentPosition = transform.position;

        // ���㵱ǰλ������һ��λ�õľ���
        float distance = Vector3.Distance(currentPosition, previousPosition);

        // �ж��Ƿ��ƶ�
        bool IsMoving = distance > 0.01f; // ����һ����ֵ���ж��Ƿ��ƶ�

        // ����Animator����
        animator.SetBool("IsMoving", IsMoving);

        // ������һ��λ��
        previousPosition = currentPosition;
    }
}
