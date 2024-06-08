using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectableController : MonoBehaviour, IDataPersistance
{
    public UnityEvent OnPickUp;
    public bool isCollectableCollected = false;
    [SerializeField] private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (isCollectableCollected)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Trigger()
    {
        OnPickUp.Invoke();
        isCollectableCollected = true;
        DataPersistenceManager.Instance.SaveGame();
        Destroy(gameObject);
    }

    public void Load(GameData data)
    {
        var world = GameManager.Instance.levelData.world;
        var level = GameManager.Instance.levelData.level;
        this.isCollectableCollected = data.worlds[world].levels[level].isCollectableCollected;
    }

    public void Save(ref GameData data)
    {
        var world = GameManager.Instance.levelData.world;
        var level = GameManager.Instance.levelData.level;
        data.worlds[world].levels[level].isCollectableCollected = this.isCollectableCollected;
    }
}
