using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal interface IDataPersistance
{
  void Load(GameData data);
  void Save(ref GameData data);
}