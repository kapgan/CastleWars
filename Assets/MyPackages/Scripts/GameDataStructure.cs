using UnityEngine;
public class GameDataStructure : Singleton<GameDataStructure>
{

    public int PlayerLevel { get => GetIntPlayerData(_playerLevelName); set => SetIntPlayerData(_playerLevelName, value); }
    public int PlayerMoney { get => GetIntPlayerData(_playerMoneyName); set => SetIntPlayerData(_playerMoneyName, value); }

    private string _playerLevelName = "PlayerLevel";
    private string _playerMoneyName = "PlayerMoney";
    public void OnStart()
    {
        if (!CheckPlayerData())
        {
            InitializedPlayerPrefData();
        }
    }
    private bool CheckPlayerData()
    {
        if (PlayerPrefs.HasKey(_playerMoneyName))
            return false;
        if (PlayerPrefs.HasKey(_playerMoneyName))
            return false;

        return true;
    }
    private void InitializedPlayerPrefData() {

        SetIntPlayerData(_playerMoneyName, 1);
        SetIntPlayerData(_playerMoneyName, 0);
    }
    private int GetIntPlayerData(string dataName)
    {
        return PlayerPrefs.GetInt(dataName);
    }
    private void SetIntPlayerData(string dataName,int value)
    {
        PlayerPrefs.SetInt(dataName, value);
    }
}
