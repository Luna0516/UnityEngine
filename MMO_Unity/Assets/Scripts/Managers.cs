using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers instance;
    public static Managers Inst
    {
        get
        {
            Init();

            return instance;
        }
    }

    InputManager input = new InputManager();
    public static InputManager Input
    {
        get
        {
            return Inst.input;
        }
    }

    ResourceManager resource = new ResourceManager();
    public static ResourceManager Resource
    {
        get
        {
            return Inst.resource;
        }
    }

    void Update()
    {
        input.OnUpdate();
    }

    private static void Init()
    {
        if (instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if(go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            instance = go.GetComponent<Managers>();
        }
    }
}