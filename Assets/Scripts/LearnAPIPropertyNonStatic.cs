using UnityEngine;

/// <summary>
/// �D�R�A�ݩ�
/// </summary>
public class LearnAPIPropertyNonStatic : MonoBehaviour
{
    // �R�A�P�D�R�A�t���G
    // 1.�w�q���
    // 2.����������P���O�ۦP
    // 3.���n�x�s����
    public Camera cam;
    public Transform tra;

    private void Start()
    {
        // �R�A��ӲաG
        print("��v���ƶq" + Camera.allCamerasCount);

        // �D�R�A�ݩ�
        // ���o�D�R�A�ݩʻy�k�G
        // ���W��.�D�R�A�ݩʦW��
        print("��v���`�סG" + cam.depth);

        // �]�w�D�R�A�ݩʻy�k�G
        // ���W��.�D�R�A�ݩʦW�� ���w ��;
        tra.position = new Vector3(5, 0, 0);
    }
}
