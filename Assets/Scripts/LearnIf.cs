using UnityEngine;

public class LearnIf : MonoBehaviour
{
    public bool openDoor;

<<<<<<< Updated upstream
=======
<<<<<<< HEAD
    public int score = 99;

    // �}�l�ƥ�
    private void Start()
    {
        // �P�_�� if
        // �y�k
        // �p�G (���L��) { ���L�� ���� true �|���� �@�� �{�����e }
        // �_�h { ���L�� ���� false �|���� �{�����e }
=======
>>>>>>> Stashed changes
    /// <summary>
    /// �P�_�� if
    /// </summary>
    private void Start()
    {
        // �P�_�� if else
        // �y�k�G
        // �p�G (���L��(�u��true�~Ū����)) { ���L�� ���� true�� �|���� �{�����e}
        // �_�h { ���L�� ���� false �|���� �{�����e}
<<<<<<< Updated upstream
=======
>>>>>>> f425232ad980edd4d8ecf3f6b5b9f0f6a2b64500
>>>>>>> Stashed changes
        if (true)
        {
            print("���L�� true");
        }
<<<<<<< Updated upstream

=======
<<<<<<< HEAD
=======

>>>>>>> f425232ad980edd4d8ecf3f6b5b9f0f6a2b64500
>>>>>>> Stashed changes
        if (false)
        {
            print("���L�� false");
        }

<<<<<<< Updated upstream
        // openDoor == true �P opendoor
=======
<<<<<<< HEAD
        // openDoor == true �P openDoor
=======
        // openDoor == true �P opendoor
>>>>>>> f425232ad980edd4d8ecf3f6b5b9f0f6a2b64500
>>>>>>> Stashed changes
        if (openDoor)
        {
            print("�}��");
        }
        else
        {
            print("����");
        }
    }

<<<<<<< Updated upstream
=======
<<<<<<< HEAD
    // ��s�ƥ�G�@���������Q�� 60FPS
    private void Update()
    {
        // �p�G���� >= 60�� �ή�
        if (score >= 60)
        {
            print("�ή�");
        }

        // �p�G���� >= 40�� �i�ɦ�
        // �y�k�Gelse if (���L��) { ���L�� �� true �ɰ��� }
        // else if ��b if �U�� else �W��A�i�H�L����
        else if (score >= 40)
        {
            print("�i�ɦ�");
        }
        
        // �p�G���� < 40��  ����
        else
        {
            print("����");
        }
    }
=======
>>>>>>> f425232ad980edd4d8ecf3f6b5b9f0f6a2b64500
>>>>>>> Stashed changes
}
