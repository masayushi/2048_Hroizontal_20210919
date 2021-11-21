using UnityEngine;
using System.Linq;

// 遊戲主要的邏輯是：先賦予每個操作方塊資料，再用一筆資料統整所有方塊資料(資料夾包住資料的概念)，接著才有辦法使用二維陣列帶入各個方塊內(即便二維陣列能夠處理多筆資料，但是也要用相同類型的資料，或者是將這些不同類型的資料包在一個資料類別內才能夠使用)

/// <summary>
/// 方向列舉：無、右、左、上、下
/// </summary>
public enum Driection
{
    None, Right, Left, Up, Down
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
    [Header("底圖區塊")]
    public Transform[] blocksEmpty;
    [Header("數字區塊")]
    public GameObject goNumberBlock;
    [Header("畫布 2048")]
    public Transform traCanvas2048;

    /// <summary>
    /// 私人欄位出現在屬性面板上
    /// </summary>
    [SerializeField]
    private Driection driection;


    /// <summary>
    /// 所有區塊資料
    /// </summary>

    // 這邊要套用我們自己設定的資料(BlockData)來讓BlockData的資料變得能夠套用進二維陣列內
    // 之所以用 new BlockData 是因為如果直接用BlockData的話系統會抓到空值
    // [4,4] = 4 x 4 (欄乘列)
    public BlockData[,] blocks = new BlockData[4, 4];

    private void Start()
    {
        Initialize();
    }

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
                result += "編號" + blocks[i, j].v2Index + "<color=red>數字：" + blocks[i, j].number + "</color> <color=green>" + blocks[i, j].goBlock + "</color>|";
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
        printBlockData();

        // 實例化(生成)API - (物件，父物件)
        GameObject tempBlock = Instantiate(goNumberBlock, traCanvas2048);
        // 生成區塊 的 指定座標
        tempBlock.transform.position = dataRandom.v2Position;
        // 資料儲存 的 生成區塊
        dataRandom.goBlock = tempBlock;
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
