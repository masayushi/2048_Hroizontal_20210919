using UnityEngine;

/// <summary>
/// 判斷式 Switch
/// </summary>
public class LearnSwitch : MonoBehaviour
{
    public string equipment;

    private void Start()
    {
        // Switch語法：
        // switch (要判斷的資料)
        // {
        //      case 值1：
        //          程式內容;
        //          break;
        //      case 值2：
        //          程式內容;
        //          break;
        //      default：            // 當資料不符合上面 case
        //          程式內容;
        //          break;
        // }

        switch (equipment)
        {
            case "刀子":
                print("角色正持有刀子");
                break;
            case "叉子":
                print("角色正持有叉子");
                break;
            default:
                print("角色持有的不是武器");
                break;
        }
    }
}
