using UnityEngine;
using UnityEngine.UI;
using System.Collections;   // 引用 系統 集合 API：協同程序 Coroutine
using UnityEngine.Events;


/// <summary>
/// 攻擊系統：近距離
/// </summary>
public class AttackSystem : MonoBehaviour
{
    #region 公開欄位
    [Header("基礎攻擊力")]
    public float attack = 10;
    [Header("攻擊目標")]
    public GameObject goTarget;
    [Header("攻擊力介面")]
    public Text textAttack;
    [Header("延遲攻擊"), Range(0, 10)]
    public float delayAttack = 1;
    [Header("延遲傳送傷害"), Range(0, 5)]
    public float delaySendDamage = 0.5f;
    [Header("動畫參數")]
    public string parameterAttack = "攻擊觸發";
    #endregion

    #region 欄位：保護 Protected
    // public 允許任何類別存取
    // private 允許此類別存取
    // protected 允許子類別存取
    protected HealthSystem targetHealthSystem;
    protected Animator ani;

    #endregion

    #region 事件
    private void Awake()
    {
        textAttack.text = "ATK" + attack;
        ani = GetComponent<Animator>();
        targetHealthSystem = goTarget.GetComponent<HealthSystem>();
    }
    #endregion

    [Header("攻擊完成事件")]
    public UnityEvent onAttackFinish;

    #region 公開方法
    /// <summary>
    /// 攻擊方法
    /// </summary>
    // virtual 虛擬：允許子類別複寫
    public virtual void Attack()
    {
        // 啟動  協同程序
        StartCoroutine(DelayAttack());
    }

    private IEnumerator DelayAttack()
    {
        // 延遲攻擊 1 秒
        yield return new WaitForSeconds(delayAttack);
        // 攻擊動畫
        ani.SetTrigger(parameterAttack);
        // 延遲 0.5 秒
        yield return new WaitForSeconds(delaySendDamage);
        // 傳送傷害
        targetHealthSystem.Hurt(attack);
        onAttackFinish.Invoke();
    }
    #endregion
}
