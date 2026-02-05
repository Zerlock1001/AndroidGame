using UnityEngine;

public class BrushController : MonoBehaviour
{
    public float brushSpeed = 1f;
    public static float balance = 0f;
    public float balanceAddSpeed = 100f;
    public float maxBalance = 100f;
    //public float continueTime = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ControlBrush();
        Eat();
        OpenBook();
    }
    void ControlBrush()
    {
        bool isMoving = false;
        if(Input.GetKey(KeyCode.A))
        {
            balance -= balanceAddSpeed * Time.deltaTime;
            if(balance >= - maxBalance){
                transform.position += new Vector3(-brushSpeed * Time.deltaTime, 0, 0);
                isMoving = !isMoving;
            }
            else{
                balance = - maxBalance;
            }
            //等于：transform.position = transform.position + new Vector3(-brushSpeed * Time.deltaTime, 0, 0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            balance += balanceAddSpeed * Time.deltaTime;
            if(balance <= maxBalance){
                transform.position += new Vector3(brushSpeed * Time.deltaTime, 0, 0);
                isMoving = !isMoving;
            }
            else{
                balance = maxBalance;
            }
        }
        if(isMoving){
            AndroidGameManager.AddCleanValue(Mathf.Abs(balance/1.3f) * Time.deltaTime);
        }
    }
    public static void ResetBalance(){
        balance = 0;
    }
    public void Eat(){
        if(Input.GetKeyDown(KeyCode.E)){
            //吃草
        }
    }
    public void OpenBook(){
        if(Input.GetKeyDown(KeyCode.B)){
            //打开书
        }
    }
}
