using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatTitle : MonoBehaviour
{
    public float floatAmplitude = 0.5f;  // 浮动的幅度
    public float floatSpeed = 1f;        // 浮动的速度
    private float startY;                // 初始的Y轴位置
    private float startX;                //初始x轴位置

    [Header("MoveGrid")] 
    public GameObject title;
    public GameObject O_o;
    

    void Start()
    {
        // 记录小球的初始Y轴位置
        startY = transform.position.y;
        startX = transform.position.x;
    }

    void Update()
    {
        // 使用正弦函数计算浮动的偏移量
        float newY = startY + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        float newX = startX + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;

        // 更新小球的Y轴位置，使其上下浮动
        transform.position = new Vector3(newX, newY, transform.position.z);
    }
}
