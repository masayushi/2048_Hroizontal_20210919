using UnityEngine;

public class LearnAPIStaticMethod : MonoBehaviour
{
    private void Start()
    {
        // �R�A��k
        // �I�s�R�A��k�y�k�G
        // �I�s�R�A��k�W��(�������޼�);
        float f = Random.Range(3.5f, 7.5f);
        print("�H���d��3.5f ~ 7.5f" + f);
        // ���h�� Declaration �N����k���h����k�G�h�ةI�s�覡
        int rInt = Random.Range(1, 3); // 1�B2
        print("�H����� 1 ~ 2 " + rInt);
    }

    private void Update()
    {
        bool space = Input.GetKeyDown(KeyCode.Space);
        print("���a�O�_���ťիءG" + space);
    }
}
