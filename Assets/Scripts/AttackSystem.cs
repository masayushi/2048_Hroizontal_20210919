using UnityEngine;


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
    #endregion

    #region ���}��k
    /// <summary>
    /// ������k
    /// </summary>
    public void Attack()
    {
        print("�o�ʧ����A�����O���G" + attack);
    }
    #endregion
}
