using UnityEngine;

/// <summary>
/// �P�_�� Switch
/// </summary>
public class LearnSwitch : MonoBehaviour
{
    public string equipment;

    private void Start()
    {
        // Switch�y�k�G
        // switch (�n�P�_�����)
        // {
        //      case ��1�G
        //          �{�����e;
        //          break;
        //      case ��2�G
        //          �{�����e;
        //          break;
        //      default�G            // ���Ƥ��ŦX�W�� case
        //          �{�����e;
        //          break;
        // }

        switch (equipment)
        {
            case "�M�l":
                print("���⥿�����M�l");
                break;
            case "�e�l":
                print("���⥿�����e�l");
                break;
            default:
                print("������������O�Z��");
                break;
        }
    }
}
