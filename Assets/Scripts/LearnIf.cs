using UnityEngine;

public class LearnIf : MonoBehaviour
{
    public bool openDoor;

    /// <summary>
    /// �P�_�� if
    /// </summary>
    private void Start()
    {
        // �P�_�� if else
        // �y�k�G
        // �p�G (���L��(�u��true�~Ū����)) { ���L�� ���� true�� �|���� �{�����e}
        // �_�h { ���L�� ���� false �|���� �{�����e}
        if (true)
        {
            print("���L�� true");
        }

        if (false)
        {
            print("���L�� false");
        }

        // openDoor == true �P opendoor
        if (openDoor)
        {
            print("�}��");
        }
        else
        {
            print("����");
        }
    }

}
