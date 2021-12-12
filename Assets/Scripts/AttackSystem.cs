using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// �����t�ΡG��Z��
/// </summary>
public class AttackSystem : MonoBehaviour
{
    #region ���}���
    [Header("��¦�����O")]
    public float attack = 10;
    [Header("�����ؼ�")]
    public GameObject goTarget;
    [Header("�����O����")]
    public Text textAttack;
    #endregion

    #region �ƥ�
    private void Awake()
    {
        textAttack.text = "ATK" + attack;
    }
    #endregion

    #region ���}��k
    /// <summary>
    /// ������k
    /// </summary>
    // virtual �����G���\�l���O�Ƽg
    public virtual void Attack()
    {
        print("�o�ʧ����A�����O���G" + attack);
    }
    #endregion
}
