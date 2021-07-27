using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSprite : MonoBehaviour
{
    private Transform playerTransform;
    private SpriteRenderer thisSprite;
    private SpriteRenderer playerSprite;

    private Color color;

    [Header("时间控制参数")]
    public float activeTime; // 显示时间
    public float activeStart; // 开始显示的时间点

    [Header("不透明度控制")]
    public float alphaSet; // 初始值
    public float alphaMultiplier;
    private float alpha;

    private void OnEnable()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        thisSprite = GetComponent<SpriteRenderer>();
        playerSprite = playerTransform.GetComponent<SpriteRenderer>();

        alpha = alphaSet;

        thisSprite.sprite = playerSprite.sprite;

        transform.position = playerTransform.position;
        transform.localScale = playerTransform.localScale;
        transform.rotation = playerTransform.rotation;

        activeStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        alpha *= alphaMultiplier;

        color = new Color(0.5f, 0.5f, 0.9f, alpha);

        thisSprite.color = color;

        if(Time.time >= activeStart + activeTime)
        {
            // 返回对象池
            this.gameObject.SetActive(false);
        }
    }
}
