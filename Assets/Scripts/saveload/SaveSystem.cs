using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    public static void SavePlayer(MoneyManager money, BallSpawner levelYeah, DamageVelocityIdleUpgrade upgradeLevelsYeah, ShopButtons ballZ, UnlockScript unlockLevel,
        PotionManager potion,
        ComboMultiplier combo,
        IdleManager idleTime,
        WealthButtons wB)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/settings.cg";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(money, levelYeah, upgradeLevelsYeah, ballZ, unlockLevel,potion,combo,idleTime,wB);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/settings.cg";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("SaveFile not found in" + path);
            return null;
        }
    }
}
