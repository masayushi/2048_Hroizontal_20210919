using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnProperty : MonoBehaviour
{
    // ���
    public int passwordField = 123456789;

    // �ݩ� Property
    // �y�k�G
    // �׹���  �������  �ݩʦW�� { �s���l }
    // �۰ʹ�@
    // get ���o
    // set �]�w
    public int passwordProperty { get; set; }

    // ��Ū�ݩʡG�u����o�S�w����@���
    // public int myPasswordProperty { get; } <- �o�˼g���ܴN�Q�T�w�F
    // => �H�ڹF Lambda ��C# 6.0��~��ϥ�(���L�{�bUnity�u�䴩7.0��}�l��C#)
    public int myPasswordProperty { get => 999; }

    // ��Ū����g�k
    // get �ݨϥ�����r return �Ǧ^

    public string nameCharacter
    {
        get
        {
            print("�ڦb�ݩ� name Charater ��!!");
            return "yushi";
        }
    }

    // �߼g����g�k (�C���s�@�W���֥ΰ߼g)
    // Set �ϥ�����r value ��J��
    public float attack
    {
        set
        {
            print("�����O�G" + value);
        }
    }


    void Start()
    {
        // �s�� Set �����
        // �y�k�G
        // �ݩʦW�� ���w �ȡG
        passwordProperty = 777;

        // ���o Get ����� 
        // �y�k�G
        // �ݩʦW��
        print("�ݩʦW�١G" + passwordProperty);

        // myPasswordProperty = 999; // ��Ū�ݩʤ���Q�]�w�A�ҥH�o�g�k�O����
        print("�ڪ��ݩʱK�X�G" + myPasswordProperty);

        print(nameCharacter);

        // print(attack);            // �߼g�ݩʤ������bprint���Ǧ^�A�ҥH�o�O���~�g�k  
        attack = 999.9f;
    }
}
