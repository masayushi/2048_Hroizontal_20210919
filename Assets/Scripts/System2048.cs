using UnityEngine;
using System.Linq;

// �C���D�n���޿�O�G���ᤩ�C�Ӿާ@�����ơA�A�Τ@����Ʋξ�Ҧ�������(��Ƨ��]���ƪ�����)�A���ۤ~����k�ϥΤG���}�C�a�J�U�Ӥ����(�Y�K�G���}�C����B�z�h����ơA���O�]�n�άۦP��������ơA�Ϊ̬O�N�o�Ǥ��P��������ƥ]�b�@�Ӹ�����O���~����ϥ�)

/// <summary>
/// ��V�C�|�G�L�B�k�B���B�W�B�U
/// </summary>
public enum Driection
{
    None, Right, Left, Up, Down
}




/// <summary>
///  2048 �t�ΡA�]�t�G
///  �x�s�C�Ӱ϶����
///  �޲z�H���ͦ�
///  �ưʱ���
///  �Ʀr�X�֪��P�w
///  �C������P�w
/// </summary>
public class System2048 : MonoBehaviour
{
    [Header("���ϰ϶�")]
    public Transform[] blocksEmpty;
    [Header("�Ʀr�϶�")]
    public GameObject goNumberBlock;
    [Header("�e�� 2048")]
    public Transform traCanvas2048;

    /// <summary>
    /// �p�H���X�{�b�ݩʭ��O�W
    /// </summary>
    [SerializeField]
    private Driection driection;


    /// <summary>
    /// �Ҧ��϶����
    /// </summary>

    // �o��n�M�Χڭ̦ۤv�]�w�����(BlockData)����BlockData������ܱo����M�ζi�G���}�C��
    // ���ҥH�� new BlockData �O�]���p�G������BlockData���ܨt�η|���ŭ�
    // [4,4] = 4 x 4 (�歼�C)
    public BlockData[,] blocks = new BlockData[4, 4];

    private void Start()
    {
        Initialize();
    }

    /// <summary>
    /// ��l�Ƹ��
    /// Initialize = ��l��
    /// </summary>
    private void Initialize()
    {
        for (int i = 0; i < blocks.GetLength(0); i++)
        {
            for (int j = 0; j < blocks.GetLength(1); j++)
            {
                blocks[i, j] = new BlockData();

                blocks[i, j].v2Index = new Vector2Int(i, j);

                blocks[i, j].v2Position = blocksEmpty[i * blocks.GetLength(1) + j].position;
            }
        }
        printBlockData();
        CreateRandomNumberBlock();
        CreateRandomNumberBlock();
    }

    /// <summary>
    /// ��X�϶��G���}�C���
    /// </summary>
    private void printBlockData()
    {
        string result = "";

        for (int i = 0; i < blocks.GetLength(0); i++)
        {
            for (int j = 0; j < blocks.GetLength(1); j++)
            {
                // �s���B�Ʀr�P�y��
                // result += "�s��" + blocks[i, j].v2Index + "<color=red>�Ʀr�G" + blocks[i, j].number + "</color> <color=green>" + blocks[i, j].v2Position + "</color>|";
                // �s���B�Ʀr�P����
                result += "�s��" + blocks[i, j].v2Index + "<color=red>�Ʀr�G" + blocks[i, j].number + "</color> <color=green>" + blocks[i, j].goBlock + "</color>|";
            }
            result += "\n";
        }
        print(result);
    }


    /// <summary>
    /// �إ��H���Ʀr�϶�
    /// �P�_�Ҧ��϶����S���Ʀr���϶� - �϶��Ʀr���s
    /// �H���D��@�Ӱ϶��A�åͦ��Ʀr���Ӱ϶���
    /// </summary>
    private void CreateRandomNumberBlock()
    {
        var equalZero =
            from BlockData data in blocks
            where data.number == 0
            select data;

        print("���s����Ʀ��X���G" + equalZero.Count());

        int randomIndex = Random.Range(0, equalZero.Count());
        print("�H���s���G" + randomIndex);

        // ��X�H���϶����s�� �o��|��}�C��x�b��y�b���}�g
        BlockData dataRandom = blocks[equalZero.ToArray()[randomIndex].v2Index.x, equalZero.ToArray()[randomIndex].v2Index.y];
        //�N�Ʀr 2 ��J���H���϶��� �ȱo�`�N���O �Ĥ@��������s���]�O 0 �A�ҥH�����⪺�ܭn�A+1!
        dataRandom.number = 2;
        printBlockData();

        // ��Ҥ�(�ͦ�)API - (����A������)
        GameObject tempBlock = Instantiate(goNumberBlock, traCanvas2048);
        // �ͦ��϶� �� ���w�y��
        tempBlock.transform.position = dataRandom.v2Position;
        // ����x�s �� �ͦ��϶�
        dataRandom.goBlock = tempBlock;
    }

}

/// <summary>
/// �ާ@�Ϫ�������
/// �C�Ӱ϶����C������B�y�СB�s���B�Ʀr(�ާ@����W��ܪ��Ʀr)
/// </summary>
public class BlockData
{
    /// <summary>
    /// �϶������Ʀr����
    /// </summary>
    public GameObject goBlock;
    /// <summary>
    /// �϶��y��(�]���O2D�ҥH��Vector2)
    /// </summary>
    public Vector2 v2Position;
    /// <summary>
    /// �϶��s���G�G���}�C���s��
    /// </summary>
    public Vector2Int v2Index;
    /// <summary>
    /// �϶��Ʀr�G�w�]��0�A�Ϊ� 2�B4�B8...2048
    /// </summary>
    public int number;
}
