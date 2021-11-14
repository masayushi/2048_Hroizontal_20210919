using UnityEngine.SceneManagement; // 引用 場景管理的資料
using UnityEngine.Audio;           // 引用 音效管理的資料
using UnityEngine;

/// <summary>
/// 開始畫面選單管理器 
/// 開始遊戲、設定、離開遊戲
/// </summary>
public class MenuManager : MonoBehaviour
{
    public AudioMixer mixer;

    // Unity 按鈕與程式溝通
    // 1. 公開的方法
    // 2. 按鈕設定點擊事件 On Click


    /// <summary>
    /// 開始遊戲
    /// </summary>
    public void StartGame(float delay)
    {
        // 使用繼承成員的語法：
        // 繼承類別的方法
        // 方法名稱(對應的引數)
        // 延遲 delay 秒後呼叫 方法
        Invoke("DelayStartGame", delay);
    }

    /// <summary>
    /// 延遲開啟遊戲
    /// </summary>
    private void DelayStartGame()
    {
        // 場景管理.載入場景(場景名稱)
        SceneManager.LoadScene("遊戲場景");
    }

    /// <summary>
    /// 設定遊戲BGM
    /// </summary>
    public void SettingGameBGM(float volume)
    {
        mixer.SetFloat("音量BGM", volume);
    }

    /// <summary>
    /// 設定遊戲BGX
    /// </summary>
    public void SettingGameBGX(float volume)
    {
        mixer.SetFloat("音量BGX", volume);
    }

    /// <summary>
    /// 離開遊戲
    /// </summary>
    public void QuitGame(float delay)
    {
        Invoke("DelayQuitGame", delay);
    }

    /// <summary>
    /// 延遲離開遊戲
    /// </summary>
    private void DelayQuitGame()
    {
        // 應用程式.離開();
        // Quit 不會在 Editor 執行，發布執行檔後只有在手機與PC平台才會(網頁也不會執行)
        Application.Quit();

        print("離開遊戲~");
    }
}
