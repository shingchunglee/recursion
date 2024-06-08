using System;
using System.IO;
using UnityEngine;

public class FileDataHandler
{
  private string dataDirPath = "";

  private string dataFileName = "";

  public FileDataHandler(string dataDirPath, string dataFileName)
  {
    this.dataDirPath = dataDirPath;
    this.dataFileName = dataFileName;
  }

  public GameData Load()
  {
    var fullPath = Path.Combine(dataDirPath, dataFileName);
    GameData loadedData = null;
    if (File.Exists(fullPath))
    {
      try
      {
        var json = File.ReadAllText(fullPath);
        loadedData = JsonUtility.FromJson<GameData>(json);
      }
      catch (Exception e)
      {
        Debug.LogError($"Error occured when trying to load data from {fullPath}.\n{e}");
      }
    }
    return loadedData;
  }

  public void Save(GameData data)
  {
    var fullPath = Path.Combine(dataDirPath, dataFileName);
    try
    {
      Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
      var json = JsonUtility.ToJson(data, true);
      File.WriteAllText(fullPath, json);
    }
    catch (Exception e)
    {
      Debug.LogError($"Error occured when trying to save data to {fullPath}.\n{e}");
    }
  }
}