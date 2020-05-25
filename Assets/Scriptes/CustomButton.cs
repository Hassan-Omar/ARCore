using UnityEngine.UI;


public class CustomButton : Button
{
    private bool flag = true;

    public void FixedUpdate()
    {
        if (IsPressed())
        {
            onClick.Invoke();
            if (flag)
            {
                flag = false;
            }

        }
        else
        {
            flag = true;
        }
    }
}
