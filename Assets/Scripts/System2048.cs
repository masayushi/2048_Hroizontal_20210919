using UnityEngine;
using System.Linq;
using UnityEngine.UI;

// �C���D�n���޿�O�G���ᤩ�C�Ӿާ@�����ơA�A�Τ@����Ʋξ�Ҧ�������(��Ƨ��]���ƪ�����)�A���ۤ~����k�ϥΤG���}�C�a�J�U�Ӥ����(�Y�K�G���}�C����B�z�h����ơA���O�]�n�άۦP��������ơA�Ϊ̬O�N�o�Ǥ��P��������ƥ]�b�@�Ӹ�����O���~����ϥ�)

/// <summary>
/// ��V�C�|�G�L�B�k�B���B�W�B�U
/// </summary>
public enum Direction
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
    #region ���}���
    [Header("���ϰ϶�")]
    public Transform[] blocksEmpty;
    [Header("�Ʀr�϶�")]
    public GameObject goNumberBlock;
    [Header("�e�� 2048")]
    public Transform traCanvas2048;
    #endregion

    #region �p�H���
    /// <summary>
    /// �p�H���X�{�b�ݩʭ��O�W
    /// </summary>
    [SerializeField]
    private Direction direction;

    /// <summary>
    /// �Ҧ��϶����
    /// </summary>
    // �o��n�M�Χڭ̦ۤv�]�w�����(BlockData)����BlockData������ܱo����M�ζi�G���}�C��
    // ���ҥH�� new BlockData �O�]���p�G������BlockData���ܨt�η|���ŭ�
    // [4,4] = 4 x 4 (�歼�C)
    private BlockData[,] blocks = new BlockData[1, 4];

    /// <summary>
    /// �I���B���U�ɪ��y��
    /// </summary>
    private Vector3 posDown;

    /// <summary>
    /// ��}�ɪ��y��
    /// </summary>
    private Vector3 posUp;

    /// <summary>
    /// �O�_���U����
    /// </summary>
    private bool isClinkMouse;
    #endregion


    #region �ƥ�
    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        CheckDirection();
    }
    #endregion

    #region �p�H��k
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

                // �T���B��l
                // �y�k�G���L�� ? �� A �G ��B;
                // ���L�Ȭ� true ���G�� �� A
                // ���L�Ȭ� false ���G�� �� B
                result += "�s��" + blocks[i, j].v2Index + "<color=red>�Ʀr�G" + blocks[i, j].number + "</color> <color=green>" + (blocks[i, j].goBlock ? "��" : "�@") + "</color>|";
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

        // ��Ҥ�(�ͦ�)API - (����A������)
        GameObject tempBlock = Instantiate(goNumberBlock, traCanvas2048);
        // �ͦ��϶� �� ���w�y��
        tempBlock.transform.position = dataRandom.v2Position;
        // ����x�s �� �ͦ��϶�
        dataRandom.goBlock = tempBlock;
        printBlockData();
    }

    private void CheckDirection()
    {
        #region ��L����
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Direction.Up;
            CheckAndMoveBlock();
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Direction.Left;
            CheckAndMoveBlock();
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Direction.Down;
            CheckAndMoveBlock();
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Direction.Right;
            CheckAndMoveBlock();
        }
        #endregion

        #region �ƹ��BĲ������
        if (!isClinkMouse && Input.GetKeyDown(KeyCode.Mouse0))
        {
            isClinkMouse = true;
            posDown = Input.mousePosition;
            print("���U�᪺�y�СG" + posDown);
        }
        else if (isClinkMouse && Input.GetKeyUp(KeyCode.Mouse0))
        {
            isClinkMouse = false;
            posUp = Input.mousePosition;
            print("��}�᪺�y�СG" + posUp);

            // 1. �p��V�q�� ��}�ɪ��y�� - ���U�᪺�y��
            Vector3 directionValue = posUp - posDown;
            print("�V�q�ȡG" + directionValue);
            // 2. �ഫ�� 0 ~ 1 ����
            print("�ഫ�᪺�ȡG" + directionValue.normalized);

            // ��V X �P��V Y �������
            float xAbs = Mathf.Abs(directionValue.normalized.x);
            float yAbs = Mathf.Abs(directionValue.normalized.y);
            // �p�G X > Y �N�|��������V
            if (xAbs > yAbs)
            {
                if (directionValue.normalized.x > 0) direction = Direction.Right;
                else direction = Direction.Left;
                CheckAndMoveBlock();
            }
            // �p�G Y > X �N�|��������V
            else if (yAbs > xAbs)
            {
                if (directionValue.normalized.y > 0) direction = Direction.Up;
                else direction = Direction.Down;
                CheckAndMoveBlock();
            }
        }
        #endregion
    }

    /// <summary>
    /// �ˬd�ò��ʰ϶�
    /// </summary>
    private void CheckAndMoveBlock()
    {
        print("�ثe����V�G" + direction);
        switch (direction)
        {
            case Direction.Right:
                break;
            case Direction.Left:
                for (int i = 0; i < blocks.GetLength(0); i++)
                {
                    for (int j = 0; j < blocks.GetLength(1); j++)
                    {
                        BlockData blockOriginal = new BlockData();     // ��l���Ʀr���϶�
                        BlockData blockCheck = new BlockData();        // �ˬd���䪺�϶�
                        bool canMove = false;                          // �O�_�i�H���ʰ϶�
                        bool sameNumber = false;                       // �Ʀr�O�_�ۦP
                        blockOriginal = blocks[i, j];

                        // �p�G �Ӱ϶����Ʀr ���s �N �~��(���L���j��A����U�@�Ӱj��)
                        if (blockOriginal.number == 0) continue;

                        for (int k = j - 1; k >= 0; k--)
                        {
                            print("�ˬd���ơG" + k);

                            if (blocks[i, k].number == 0)
                            {
                                blockCheck = blocks[i, k];
                                canMove = true;
                            }
                            else if (blocks[i, k].number == blockOriginal.number)
                            {
                                blockCheck = blocks[i, k];
                                canMove = true;
                                sameNumber = true;
                            }
                        }
                        if (canMove)
                        {
                            // �N�쥻�����󲾰ʨ��ˬd�Ʀr���s���϶���m
                            // �N�쥻���Ʀr�k�s�A�ˬd�Ʀr�ɤW
                            // �N�쥻������M�šA�ˬd����ɤW
                            blockOriginal.goBlock.transform.position = blockCheck.v2Position;

                            if (sameNumber)
                            {
                                int number = blockCheck.number * 2;
                                blockCheck.number = number;

                                Destroy(blockOriginal.goBlock);
                                blockCheck.goBlock.transform.Find("�Ʀr").GetComponent<Text>().text = number.ToString();
                            }
                            else
                            {
                                blockCheck.number = blockOriginal.number;
                                blockCheck.goBlock = blockOriginal.goBlock;
                            }
                            blockOriginal.number = 0;
                            blockOriginal.goBlock = null;
                        }
                    }
                }
                printBlockData();
                break;
            case Direction.Up:
                break;
            case Direction.Down:
                break;
        }
    }
    #endregion
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
