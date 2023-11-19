using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    //��'���, ���� ���� ������� � �����
    public GameObject applePrefab;
    //�������� ����������
    public float speed = 1f;
    //��� ���������� �����
    public float leftAndRightEdge = 10f;
    //��������� ���� ������� ����
    public float chanceToChangeDirections = 0.1f;
    //����� ���� � ������� ���� ������ ������
    public float secondsBetweenAppleDrops = 1f;

    // ��������� ������ �������� �����
    void Start()
    {
        Invoke("DropApple", 2);
    }

    private void DropApple()
    {
        GameObject apple = Instantiate(applePrefab);
        apple.transform.position = this.transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    // ��������� ������
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime; //������� �� ����, � �� �� ��������� FPS.
                                         //Time.deltaTime - ��� ������� �� ���� ����� ��������
                                         //���������� ����� ���� ��������� ��� ���
        transform.position = pos;

        if(pos.x< -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);//���������� � �����
        }
        else if(pos.x > leftAndRightEdge) {
            speed = -Mathf.Abs(speed);
        }
    }
    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}
