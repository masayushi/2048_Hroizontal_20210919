using UnityEngine;


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
    #endregion

    #region 公開方法
    /// <summary>
    /// 攻擊方法
    /// </summary>
    public void Attack()
    {
        print("發動攻擊，攻擊力為：" + attack);
    }
    #endregion
}
