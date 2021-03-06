using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.Events;  // 引用 Unity 事件 命名空間

// 遊戲主要的邏輯是：先賦予每個操作方塊資料，再用一筆資料統整所有方塊資料(資料夾包住資料的概念)，接著才有辦法使用二維陣列帶入各個方塊內(即便二維陣列能夠處理多筆資料，但是也要用相同類型的資料，或者是將這些不同類型的資料包在一個資料類別內才能夠使用)

/// <summary>
/// 方向列舉：無、右、左、上、下
/// </summary>
public enum Direction
{
    None, Right, Left, Up, Down
}

/// <summary>
/// 回合狀態：我方、敵方
/// </summary>
public enum StateTurn
{
    My, Enemy
}



/// <summary>
///  2048 系統，包含：
///  儲存每個區塊資料
///  管理隨機生成
///  滑動控制
///  數字合併的判定
///  遊戲機制的判定
/// </summary>
public class System2048 : MonoBehaviour
{
    #region 公開欄位
    [Header("底圖區塊")]
    public Transform[] blocksEmpty;
    [Header("數字區塊")]
    public GameObject goNumberBlock;
    [Header("畫布 2048")]
    public Transform traCanvas2048;
    [Header("數字相同合併事件")]
    public OnSameNumberCombine onSameNumberCombine;
    #endregion

    // 系統 序列化：將類別資料顯示在屬性面板上
    [System.Serializable]
    public class OnSameNumberCombine : UnityEvent<float> { }

    #region 私人欄位
    /// <summary>
    /// 私人欄位出現在屬性面板上
    /// </summary>
    [SerializeField]
    private Direction direction;
    [SerializeField]
    private StateTurn stateTurn;

    /// <summary>
    /// 所有區塊資料
    /// </summary>
    // 這邊要套用我們自己設定的資料(BlockData)來讓BlockData的資料變得能夠套用進二維陣列內
    // 之所以用 new BlockData 是因為如果直接用BlockData的話系統會抓到空值
    // [4,4] = 4 x 4 (欄乘列)
    private BlockData[,] blocks = new BlockData[4, 4];

    /// <summary>
    /// 點擊、按下時的座標
    /// </summary>
    private Vector3 posDown;

    /// <summary>
    /// 放開時的座標
    /// </summary>
    private Vector3 posUp;

    /// <summary>
    /// 是否按下左鍵
    /// </summary>
    private bool isClinkMouse;
    #endregion


    #region 事件
    private void Start()
    {
        Initialize();
    }

    private void Update()
    {

        if (stateTurn == StateTurn.My) CheckDirection();
    }
    #endregion

    #region 私人方法
    /// <summary>
    /// 初始化資料
    /// Initialize = 初始化
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
    /// 輸出區塊二維陣列資料
    /// </summary>
    private void printBlockData()
    {
        string result = "";

        for (int i = 0; i < blocks.GetLength(0); i++)
        {
            for (int j = 0; j < blocks.GetLength(1); j++)
            {
                // 編號、數字與座標
                // result += "編號" + blocks[i, j].v2Index + "<color=red>數字：" + blocks[i, j].number + "</color> <color=green>" + blocks[i, j].v2Position + "</color>|";
                // 編號、數字與物件

                // 三元運算子
                // 語法：布林值 ? 值 A ： 值B;
                // 當布林值為 true 結果為 值 A
                // 當布林值為 false 結果為 值 B
                result += "編號" + blocks[i, j].v2Index + "<color=red>數字：" + blocks[i, j].number + "</color> <color=green>" + (blocks[i, j].goBlock ? "有" : "一") + "</color>|";
            }
            result += "\n";
        }
        print(result);
    }


    /// <summary>
    /// 建立隨機數字區塊
    /// 判斷所有區塊內沒有數字的區塊 - 區塊數字為零
    /// 隨機挑選一個區塊，並生成數字放到該區塊內
    /// </summary>
    private void CreateRandomNumberBlock()
    {
        var equalZero =
            from BlockData data in blocks
            where data.number == 0
            select data;

        print("為零的資料有幾筆：" + equalZero.Count());

        int randomIndex = Random.Range(0, equalZero.Count());
        print("隨機編號：" + randomIndex);

        // 選出隨機區塊的編號 這邊會把陣列的x軸跟y軸分開寫
        BlockData dataRandom = blocks[equalZero.ToArray()[randomIndex].v2Index.x, equalZero.ToArray()[randomIndex].v2Index.y];
        //將數字 2 輸入到隨機區塊內 值得注意的是 第一顆方塊的編號也是 0 ，所以直接算的話要再+1!
        dataRandom.number = 2;

        // 實例化(生成)API - (物件，父物件)
        GameObject tempBlock = Instantiate(goNumberBlock, traCanvas2048);
        // 生成區塊 的 指定座標
        tempBlock.transform.position = dataRandom.v2Position;
        // 資料儲存 的 生成區塊
        dataRandom.goBlock = tempBlock;
        printBlockData();
    }

    private void CheckDirection()
    {
        #region 鍵盤控制
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

        #region 滑鼠、觸控控制
        if (!isClinkMouse && Input.GetKeyDown(KeyCode.Mouse0))
        {
            isClinkMouse = true;
            posDown = Input.mousePosition;
            print("按下後的座標：" + posDown);
        }
        else if (isClinkMouse && Input.GetKeyUp(KeyCode.Mouse0))
        {
            isClinkMouse = false;
            posUp = Input.mousePosition;
            print("放開後的座標：" + posUp);

            // 1. 計算向量值 放開時的座標 - 按下後的座標
            Vector3 directionValue = posUp - posDown;
            print("向量值：" + directionValue);
            // 2. 轉換成 0 ~ 1 的值
            print("轉換後的值：" + directionValue.normalized);

            // 方向 X 與方向 Y 取絕對值
            float xAbs = Mathf.Abs(directionValue.normalized.x);
            float yAbs = Mathf.Abs(directionValue.normalized.y);
            // 如果 X > Y 就會為水平方向
            if (xAbs > yAbs)
            {
                if (directionValue.normalized.x > 0) direction = Direction.Right;
                else direction = Direction.Left;
                CheckAndMoveBlock();
            }
            // 如果 Y > X 就會為垂直方向
            else if (yAbs > xAbs)
            {
                if (directionValue.normalized.y > 0) direction = Direction.Up;
                else direction = Direction.Down;
                CheckAndMoveBlock();
            }
        }
        #endregion
    }

    [Header("敵人回合事件")]
    public UnityEvent onEnemyTurn;

    /// <summary>
    /// 檢查並移動區塊
    /// </summary>
    private void CheckAndMoveBlock()
    {
        print("目前的方向：" + direction);
        BlockData blockOriginal = new BlockData();     // 原始有數字的區塊
        BlockData blockCheck = new BlockData();        // 檢查旁邊的區塊
        bool canMove = false;                          // 是否可以移動區塊
        bool sameNumber = false;                       // 數字是否相同
        int sameNumberCount = 0;                       // 相同數字合併次數
        bool canMoveBlockAll = false;                   // 是否全部可以移動區塊

        switch (direction)
        {
            case Direction.Right:

                for (int i = 0; i < blocks.GetLength(0); i++)
                {
                    sameNumberCount = 0;

                    for (int j = blocks.GetLength(1) - 2; j >= 0; j--)
                    {

                        blockOriginal = blocks[i, j];

                        // 如果 該區塊的數字 為零 就 繼續(跳過此迴圈，執行下一個迴圈)
                        if (blockOriginal.number == 0) continue;

                        for (int k = j + 1; k < blocks.GetLength(1) - sameNumberCount; k++)
                        {
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
                                sameNumberCount++;
                            }

                            // 否則 如果 檢查區塊 的數字 與 原本區塊 的數字 不相同 就不移動、數字不相同並中斷
                            else if (blocks[i, k].number != blockOriginal.number)
                            {
                                break;
                            }
                        }
                        if (canMove)
                        {
                            canMoveBlockAll = true;                // 全部區塊內可以移動
                            canMove = false;
                            MoveBlock(blockOriginal, blockCheck, sameNumber);
                            sameNumber = false;
                        }
                    }
                }

                break;

            case Direction.Left:

                for (int i = 0; i < blocks.GetLength(0); i++)
                {

                    sameNumberCount = 0;

                    for (int j = 1; j < blocks.GetLength(1); j++)
                    {

                        blockOriginal = blocks[i, j];

                        // 如果 該區塊的數字 為零 就 繼續(跳過此迴圈，執行下一個迴圈)
                        if (blockOriginal.number == 0) continue;

                        for (int k = j - 1; k >= 0 + sameNumberCount; k--)
                        {

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
                                sameNumberCount++;
                            }
                            else if (blocks[i, k].number != blockOriginal.number)
                            {
                                break;
                            }
                        }
                        if (canMove)
                        {
                            canMoveBlockAll = true;
                            canMove = false;
                            MoveBlock(blockOriginal, blockCheck, sameNumber);
                            sameNumber = false;
                        }
                    }
                }

                break;
            case Direction.Up:

                for (int i = 0; i < blocks.GetLength(1); i++)
                {
                    sameNumberCount = 0;

                    for (int j = 1; j < blocks.GetLength(0); j++)
                    {

                        blockOriginal = blocks[j, i];

                        // 如果 該區塊的數字 為零 就 繼續(跳過此迴圈，執行下一個迴圈)
                        if (blockOriginal.number == 0) continue;

                        for (int k = j - 1; k >= 0 + sameNumberCount; k--)
                        {

                            if (blocks[k, i].number == 0)
                            {
                                blockCheck = blocks[k, i];
                                canMove = true;
                            }
                            else if (blocks[k, i].number == blockOriginal.number)
                            {
                                blockCheck = blocks[k, i];
                                canMove = true;
                                sameNumber = true;
                                sameNumberCount++;
                            }
                            else if (blocks[k, i].number != blockOriginal.number)
                            {
                                break;
                            }
                        }
                        if (canMove)
                        {
                            canMoveBlockAll = true;
                            canMove = false;
                            MoveBlock(blockOriginal, blockCheck, sameNumber);
                            sameNumber = false;
                        }
                    }
                }

                break;
            case Direction.Down:

                for (int i = 0; i < blocks.GetLength(1); i++)
                {
                    sameNumberCount = 0;

                    for (int j = blocks.GetLength(0) - 2; j >= 0; j--)
                    {

                        blockOriginal = blocks[j, i];

                        // 如果 該區塊的數字 為零 就 繼續(跳過此迴圈，執行下一個迴圈)
                        if (blockOriginal.number == 0) continue;

                        for (int k = j + 1; k < blocks.GetLength(0) - sameNumberCount; k++)
                        {

                            if (blocks[k, i].number == 0)
                            {
                                blockCheck = blocks[k, i];
                                canMove = true;
                            }
                            else if (blocks[k, i].number == blockOriginal.number)
                            {
                                blockCheck = blocks[k, i];
                                canMove = true;
                                sameNumber = true;
                                sameNumberCount++;
                            }
                            else if (blocks[k, i].number != blockOriginal.number)
                            {
                                break;
                            }
                        }
                        if (canMove)
                        {
                            canMoveBlockAll = true;
                            canMove = false;
                            MoveBlock(blockOriginal, blockCheck, sameNumber);
                            sameNumber = false;
                        }
                    }
                }

                break;
        }

        if (canMoveBlockAll)                     // 移動後生成下一顆區塊
        {
            onEnemyTurn.Invoke();
            stateTurn = StateTurn.Enemy;
            CreateRandomNumberBlock();
        }
        else
        {
            print("不能移動");
        }
    }
    #endregion

    #region 公開方法
    public void ChangeToMyTurn()
    {
        stateTurn = StateTurn.My;
    }
    #endregion

    /// <summary>
    /// 移動區塊
    /// </summary>
    /// <param name="blockOriginal">原始的區塊，要被移動的</param>
    /// <param name="blockCheck">檢查的區塊，原始區塊旁邊的區塊</param>
    /// <param name="sameNumber">是否相同數字</param>
    private void MoveBlock(BlockData blockOriginal, BlockData blockCheck, bool sameNumber)
    {
        #region 移動區塊
        // 將原本的物件移動到檢查數字為零的區塊位置
        // 將原本的數字歸零，檢查數字補上
        // 將原本的物件清空，檢查物件補上
        blockOriginal.goBlock.transform.position = blockCheck.v2Position;

        if (sameNumber)
        {
            int number = blockCheck.number * 2;
            blockCheck.number = number;

            Destroy(blockOriginal.goBlock);
            blockCheck.goBlock.transform.Find("數字").GetComponent<Text>().text = number.ToString();

            // 相同數字合併事件 觸發(合併後的數字)
            onSameNumberCombine.Invoke(number);
        }
        else
        {
            blockCheck.number = blockOriginal.number;
            blockCheck.goBlock = blockOriginal.goBlock;
        }
        blockOriginal.number = 0;
        blockOriginal.goBlock = null;
        #endregion

        printBlockData();
    }
}


/// <summary>
/// 操作區的方塊資料
/// 每個區塊的遊戲物件、座標、編號、數字(操作方塊上顯示的數字)
/// </summary>
public class BlockData
{
    /// <summary>
    /// 區塊內的數字物件
    /// </summary>
    public GameObject goBlock;
    /// <summary>
    /// 區塊座標(因為是2D所以用Vector2)
    /// </summary>
    public Vector2 v2Position;
    /// <summary>
    /// 區塊編號：二維陣列的編號
    /// </summary>
    public Vector2Int v2Index;
    /// <summary>
    /// 區塊數字：預設為0，或者 2、4、8...2048
    /// </summary>
    public int number;
}