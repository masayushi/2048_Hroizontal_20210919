using UnityEngine.SceneManagement; // �ޥ� �����޲z�����
using UnityEngine.Audio;           // �ޥ� ���ĺ޲z�����
using UnityEngine;

/// <summary>
/// �}�l�e�����޲z�� 
/// �}�l�C���B�]�w�B���}�C��
/// </summary>
public class MenuManager : MonoBehaviour
{
    public AudioMixer mixer;

    // Unity ���s�P�{�����q
    // 1. ���}����k
    // 2. ���s�]�w�I���ƥ� On Click


    /// <summary>
    /// �}�l�C��
    /// </summary>
    public void StartGame(float delay)
    {
        // �ϥ��~�Ӧ������y�k�G
        // �~�����O����k
        // ��k�W��(�������޼�)
        // ���� delay ���I�s ��k
        Invoke("DelayStartGame", delay);
    }

    /// <summary>
    /// ����}�ҹC��
    /// </summary>
    private void DelayStartGame()
    {
        // �����޲z.���J����(�����W��)
        SceneManager.LoadScene("�C������");
    }

    /// <summary>
    /// �]�w�C��BGM
    /// </summary>
    public void SettingGameBGM(float volume)
    {
        mixer.SetFloat("���qBGM", volume);
    }

    /// <summary>
    /// �]�w�C��BGX
    /// </summary>
    public void SettingGameBGX(float volume)
    {
        mixer.SetFloat("���qBGX", volume);
    }

    /// <summary>
    /// ���}�C��
    /// </summary>
    public void QuitGame(float delay)
    {
        Invoke("DelayQuitGame", delay);
    }

    /// <summary>
    /// �������}�C��
    /// </summary>
    private void DelayQuitGame()
    {
        // ���ε{��.���}();
        // Quit ���|�b Editor ����A�o�������ɫ�u���b����PPC���x�~�|(�����]���|����)
        Application.Quit();

        print("���}�C��~");
    }
}
