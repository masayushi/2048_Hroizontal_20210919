using UnityEngine;

public class LearnAPIPropertyStatic : MonoBehaviour
{
    private void Start()
    {
        // �R�A�ݩ� Static Property
        // ���o�R�A�ݩ�
        // �y�k�G���O�W��.�R�A�ݩʦW��
        print("�H���ȡG" + Random.value);
        print(Camera.allCamerasCount);

        // �]�w�R�A�ݩ�
        // �y�k�G���O�W��.�R�A�ݩʦW�� ���w ��;
        Cursor.visible = false;
        // Mathf.PI = 9.99999;            // �u�n�� Read Only ���ȳ�������]�w �� ��Ū�ݩ�
    }

}
