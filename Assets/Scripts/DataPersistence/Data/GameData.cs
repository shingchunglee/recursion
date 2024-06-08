[System.Serializable]
public class GameData
{
  public World[] worlds;

  public GameData()
  {
    worlds = new World[4];

    for (int i = 0; i < 4; i++)
    {
      worlds[i] = new()
      {
        world = i,
        levels = new Level[4]
      };
      for (int j = 0; j < 4; j++)
      {
        worlds[i].levels[j] = new() { level = j, };
        if (i == 0 && j == 0)
        {
          worlds[i].isUnlocked = true;
          worlds[i].levels[j].isUnlocked = true;
        }
      }
    }
  }
}

[System.Serializable]
public class World
{
  public bool isUnlocked = false;
  public int world;
  public Level[] levels;
}

[System.Serializable]
public class Level
{
  public bool isUnlocked = false;
  public int level;
  public bool isCleared = false;
  public bool isCollectableCollected = false;
}