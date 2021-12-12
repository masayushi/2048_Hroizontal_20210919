using UnityEngine;


/// <summary>
/// �����t�ΡG���Z��
/// �~�ӡG�n�~�Ӫ����O(�����O)
/// �֦������O���Ҧ������G���B�ݩʡB��k�B�ƥ�
/// </summary>
public class AttackSystemFar : AttackSystem
{
    [Header("�ͦ��ɤl��m")]
    public Transform positionSpawn;
    [Header("�����ɤl")]
    public GameObject goAttackParticle;
    [Header("�ɤl�o�g�t��"), Range(0, 1500)]
    public float speed = 500;

    // override �Ƽg�G�Ƽg�����O virtual ����
    public override void Attack()
    {
        base.Attack();      // base �򩳡G�����O�����e
        print("���Z����");

        // �ͦ�(����A�y�СA����)
        // �ͦ�������W�٫��|��(clone)
        // Quaternion  �|����
        // identity    �s����
        GameObject tempAttack = Instantiate(goAttackParticle, positionSpawn.position, Quaternion.identity);
        tempAttack.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0));
    }
}
