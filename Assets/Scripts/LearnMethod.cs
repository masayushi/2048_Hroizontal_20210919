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
        Drive(70);
        Drive(200);
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
    // �ѼơG������� �ѼƦW��
    public void Drive(int speed)
    {
        print("�}���A�ɳt�G" + speed);
        print("����");
    }
}
