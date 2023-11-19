using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    //ќб'Їкт, €кий буде вил≥тать з €блун≥
    public GameObject applePrefab;
    //швидк≥сть перем≥щенн€
    public float speed = 1f;
    //меж≥ перем≥щенн€ €блун≥
    public float leftAndRightEdge = 10f;
    //≤мов≥рн≥сть зм≥ни напр€ку руху
    public float chanceToChangeDirections = 0.1f;
    //ск≥льк≥ раз≥в у секунду буде кидать €блука
    public float secondsBetweenAppleDrops = 1f;

    // «апускаЇмо процес скиданн€ €блук
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

    // ѕерем≥щаЇмо €блуню
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime; //прив≥€зу до часу, а не до процесора FPS.
                                         //Time.deltaTime - дл€ кожного ѕ  буде стала величина
                                         //ѕерем≥щанн€ обЇкта буде однаковим дл€ ус≥х
        transform.position = pos;

        if(pos.x< -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);//перем≥щенн€ в право
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
