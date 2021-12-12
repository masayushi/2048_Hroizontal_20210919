using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ��q�t��
/// �޲z��q�B���˻P���`
/// </summary>
public class HealthSystem : MonoBehaviour
{
    [Header("��q"), Range(0, 500)]
    public float hp = 100;
    [Header("�n�����q�P���")]
    public Text textHp;
    public Image imgHp;
    [Header("�y���ˮ`���������")]
    public string tagDamageObject;
    [Header("�ʵe�Ѽ�")]
    public string parameterDamage = "����Ĳ�o";
    public string parameterDead = "���`Ĳ�o";

    private float hpMax;
    private Animator ani;

    // ����ƥ�G�b Start ���e����@���A�B�z��l��
    private void Awake()
    {
        hpMax = hp;
        ani = GetComponent<Animator>();
    }

    // �I���ƥ�G��ӸI�����䤤�@�Ӧ��Ŀ� is trigger
    // Enter �I���}�l�ɰ��榹�ƥ�@��
    // collision �I�쪫�󪺸I����T
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == tagDamageObject) Hurt(10);
        {

        }
    }

    /// <summary>
    /// ����
    /// </summary>
    /// <param name="damage">�����쪺�ˮ`</param>
    public void Hurt(float damage)
    {
        hp -= damage;
        textHp.text = "HP " + hp;
        imgHp.fillAmount = hp / hpMax;
        ani.SetTrigger(parameterDamage);
    }
}
