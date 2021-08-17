using UnityEngine;

public class CarController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RunWithLog("Start");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, 0.1f));
    }

    private void RunWithLog(string data)
    {
        Debug.Log(data);
    }
}
