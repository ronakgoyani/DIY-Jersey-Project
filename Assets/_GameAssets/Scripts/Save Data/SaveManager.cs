using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class    SaveManager : MonoBehaviour
{
    public static SaveManager Instance { set; get; }
    public SaveState state;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Load();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            Reset();

        if (Input.GetKeyDown(KeyCode.S))
            UpdateState();

        if (SceneManager.GetActiveScene().buildIndex != 1)
            return;

        Save();
        Load();
    }

    public void Save()
    {
        PlayerPrefs.SetString("save", SaveHelper.Serialize<SaveState>(state));
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("save"))
        {
            state = SaveHelper.Deserialize<SaveState>(PlayerPrefs.GetString("save"));
        }
        else
        {
            state = new SaveState();
        }
    }

    public void UpdateState()
    {
        Save();
        Load();
    }

    public void Reset()
    {
        if (PlayerPrefs.HasKey("save"))
        {
            PlayerPrefs.DeleteKey("save");
        }
    }
}
