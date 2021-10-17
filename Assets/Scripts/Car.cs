// �ޥ�Unity API
using UnityEngine;

// class - ���O (�Ź�)  /  Car - �ɦW�A�W�ٻݭn�ۦP�B�j�p�g�]���@�P
public class Car : MonoBehaviour
{
    #region ���y�k�P�|�j������
    // �{����� Field - �@�άO�x�s���
    // �y�k�榡�G
    // �׹��� ������� ���W�� ���w(=) �w�]�� �����Ÿ�(;)
    // �`�Υ|�j�������
    // 1. ��� �S���p���I�����t��� int     �w�]�� 0
    // 2. �B�I�� ���p���I�����t��� float   �w�]�� 0
    // 3. �r�� ��r��T  string    �w�]�� �ŭ�
    // 4. ���L�� �O�P�_ true�Bfalse  bool  �w�]�� false
    // �׹���
    // �p�H �ȭ������O�s�� Unity ���|���}��� private (�w�])
    // ���} �Ҧ����O�ҥi�s�� Unity �|���}��� public

    // ����ݩ� Attritube
    // �y�k�榡�G
    // [�ݩʦW��(��)] - ������b���e���Ϊ̬O�W�@��
    // 1. ���D Header (�r��)
    // 2. ���� Tooltip (�r��)

    [Header("�T����CC��"), Range(1000, 5000)]
    public int cc = 2000;
    [Tooltip("�o�O�T�������q�A�d��O 3 ~ 15"), Range(3, 15)]
    public float weight = 3.5f;
    public string brand = "BMW";
    public bool hasSkyWindow = true;
    #endregion

    #region �C���`�Ϊ��������
    // �C�� Color
    public Color color1;
    public Color colorRed = Color.red;
    public Color colorCustom = new Color(0, 0, 1);
    public Color colorCustomAlpga = new Color(0, 1, 0, 0.3f);
    // �y�� Vector
    // Vector �� 2 - 4 ��
    public Vector2 v2;
    public Vector2 v2One = Vector2.one;
    public Vector2 v2Custom = new Vector2(7, 9);
    public Vector3 v3Custom = new Vector3(1, 2, 3);
    public Vector4 v4Custom = new Vector4(1, 2, 3, 4);
    // �ץ� KeyCode
    public KeyCode kc;
    public KeyCode kcW = KeyCode.W;
    public KeyCode kcML = KeyCode.Mouse0;

    // �C������ GameObject �������w�w�]��
    public GameObject carBox;
    public GameObject caroil;
    // ���� Component �������w�w�]��
    public Transform traBox;
    public SpriteRenderer sprBox;
    public Camera cam;
    #endregion
}
