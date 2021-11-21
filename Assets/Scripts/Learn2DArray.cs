using UnityEngine;
using System.Linq;  // Lin"Q" => Query �d�߻y�� - ��Ƭd��

/// <summary>
/// �{�ѤG���}�C
/// </summary>
public class Learn2DArray : MonoBehaviour
{
    // �Ʋߤ@���}�C
    public int[] numbers = { 1, 3, 7, 9, 10, 50 };

    // �ǲߤG���}�C�G�G���}�C���|��ܦb�ݩʭ��O(Inspector)�W�A���ˮM�� Odin �ۤv�g Editor( Odin���I�O)
    public int[,] blocks = { { 2, 4 }, { 6, 8 } };

    public string[,] objects = new string[4, 6];

    public int[,] scores = { { 70, 90 }, { 77, 30 }, { 10, 20 } };

    private void Start()
    {
        #region �}�C���s��

        // �@���}�C���s��
        numbers[4] = 99;
        print("�@���}�C�Ĥ�����ơG" + numbers[4]);

        // �G���}�C���s��
        print("�G���}�C�ĤG�C�Ĥ@�� 1, 0�G" + blocks[1, 0]);
        blocks[1, 0] = 14;
        print("�G���}�C�ĤG�C�Ĥ@�� 1, 0�G" + blocks[1, 0]);
        blocks[1, 1] = 200;
        print("�G���}�C�ĤG��ĤG�C 1, 1�G" + blocks[1, 1]);

        print("���ƤG���}�C�Ĥ@����(y�b)���סG" + scores.GetLength(0));
        print("���ƤG���}�C�ĤG����(x�b)���סG" + scores.GetLength(1));

        // result(���G��) = ""(�ŭ�)
        string result = "";

        for (int i = 0; i < scores.GetLength(0); i++)       // �]������ӭȡA�ҥH�ݭn�Ψ��for�j��
        {
            for (int j = 0; j < scores.GetLength(1); j++)   // �W�٤����Ĥ@��for�j��ۦP!!
            {
                result += scores[i, j] + "|";
            }
            result += "\n";
        }
        print(result);
        #endregion

        #region �}�C����Ʒj�M

        // �j�M numbers �@���}�C���j�󵥩� 10 �����
        // var �L������ƫ��A
        // form ���A in �}�C    - �q�}�C�j�M��ƨëO�s�� ���A
        // where ���A ����      - �P�_ ���A �O�_�ŦX����(�P�_��)
        // select ���A;         - ��� �ŦX���� ���A
        var numberGratgerTen =
            from int n in numbers
            where n >= 10
            select n;

        print("�ŦX >= 10 ����Ʀ��X���G" + numberGratgerTen.Count());

        for (int i = 0; i < numberGratgerTen.Count(); i++)
        {
            print(">= 10 ����Ƭ��G" + numberGratgerTen.ToArray()[i]);
        }

        // scores ���ή檺���Ʀ�����
        var nopass =
            from int no in scores
            where no < 60
            select no;

        for (int i = 0; i < nopass.Count(); i++)
        {
            print("���ή檺���Ƭ��G" + nopass.ToArray()[i]);
        }
        #endregion


    }
}
