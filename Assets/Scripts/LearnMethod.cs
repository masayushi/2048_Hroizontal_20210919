using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// summary �K�n
/// ��ƻ����A��ܦb VS �sĶ�����ܤW
/// </summary>
public class LearnMethod : MonoBehaviour
{
    // ��k Method�BFunction(�]�٬��禡)
    // �@�ΡG������������{�����e
    // �y�k�G
    // �׹���  �Ǧ^�������  ��k�W�� (�Ѽ�) { �{�����e(�t��k) }
    // �L�Ǧ^void
    // �R�W�ߺD�G�b Unity �ɡA�ߺD��k�H�j�g�}�Y
    // �ۭq��k�G���|�۰ʰ���

    public void Test()
    {
        print("�ڬO���դ�k~");
    }

    private void Start()
    {
        // �I�s��k
        // ��k�W��();
        Test();
        Test();
        Drive90();
        Drive150();

        // �I�s��k�G�޼�
        // ���w�]�Ȫ��Ѽƥi�H����g�A�t�η|�۰ʮM�J�w�]��
        Drive(70, "������");
        Drive(200, "�F�F�F");
        Drive(300);
        // ���D�P�d�ҡG�ɳt50�����p�U�A�w�]���ĬO?�A�S�ĭn���Y
        // ���w�w�]�Ȫ��Ѽƻy�k�G �ѼƦW�� �_�� ��
        Drive(50, effect: "���Y");
        // �p�G�����gDrive(50, (���Ĩt�η|�ۤv��J) "���Y") ���ܡA���Y�|�ܦ����ġC��]�O;

        int t = Ten();
        print("�Ǧ^��k�ȡG" + t);
        print("���ϥ��ܼ��x�s�Ǧ^�ȡG" + Ten());

        int damage = Damage(90, 30);
        print("90 �����O�P 30���m�O�ɪ��ˮ`�G" + damage);
    }

    // �����ݨD
    // ���񭵮�
    // �T���i�H�[�t�A�ɳt�� 90
    // �T���i�H�[�t�A�ɳt�� 150
    public void Drive90()
    {
        print("�}���A�ɳt�G" + 90);
        print("����");
    }

    public void Drive150()
    {
        print("�}���A�ɳt�G" + 150);
        print("����");
    }

    // �w�q��k
    // �ѼơG������� �ѼƦW�� ���w �w�]��(���w�P�w�]�ȥi��i����A�D���n || �w�]�ȥ����g�b�A�����̥k��)
    // �Ѽƥi�H�L����Aex�G�Ѽ�1�A�Ѽ�2�A......�A�Ѽ�N
    public void Drive(int speed, string sound = "�y�y�y", string effect = "�ǹ�")
    {
        print("�}���A�ɳt�G" + speed);
        print("����" + sound);
        print("�S�ġG" + effect);
    }

    // ���Ǧ^��������k�����ϥ�return�Ǧ^
    public int Ten()
    {
        return 10;
    }


    // summary �D���n���ܭ��n !!
    /// <summary>
    /// �p��ˮ`�ȡG�����O - ���m�O = �ˮ`��
    /// </summary>
    /// <param name="attack">�����O</param>
    /// <param name="defence">���m�O</param>
    /// <returns>��ڶˮ`��</returns>
    // 90 - 30 = 60
    public int Damage(int attack, int defence)
    {
        return attack - defence;
    }

}