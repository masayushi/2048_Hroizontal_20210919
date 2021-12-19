using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/// <summary>
/// 血量系統
/// 管理血量、受傷與死亡
/// </summary>
public class HealthSystem : MonoBehaviour
{
    [Header("血量"), Range(0, 500)]
    public float hp = 100;
    [Header("要控制的血量與血條")]
    public Text textHp;
    public Image imgHp;
    [Header("造成傷害的物件標籤")]
    public string tagDamageObject;
    [Header("動畫參數")]
    public string parameterDamage = "受傷觸發";
    public string parameterDead = "死亡觸發";
    [Header("死亡事件")]
    public UnityEvent ondead;

    private float hpMax;
    private Animator ani;

    // 喚醒事件：在 Start 之前執行一次，處理初始值
    private void Awake()
    {
        hpMax = hp;
        ani = GetComponent<Animator>();
    }

    private void Start()
    {
        textHp.text = "HP " + hp;
        imgHp.fillAmount = 1;
    }

    // 碰撞事件：兩個碰撞器其中一個有勾選 is trigger
    // Enter 碰撞開始時執行此事件一次
    // collision 碰到物件的碰撞資訊
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == tagDamageObject)
        {
            Hurt(collision.GetComponent<Bullet>().attack);
        }
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">接受到的傷害</param>
    public void Hurt(float damage)
    {
        if (hp <= 0) return;                // 如果死亡就跳出

        hp -= damage;
        hp = Mathf.Clamp(hp, 0, hpMax);     // 夾住(hp，最小，最大)
        textHp.text = "HP " + hp;
        imgHp.fillAmount = hp / hpMax;
        ani.SetTrigger(parameterDamage);

        if (hp <= 0) Dead();
    }


    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {
        ondead.Invoke();
        ani.SetTrigger(parameterDead);
    }
}
