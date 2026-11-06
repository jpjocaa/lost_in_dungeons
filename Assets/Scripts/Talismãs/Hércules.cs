using UnityEngine;

public class Hércules : MonoBehaviour
{
    public float Multp;
    public float lvl;
    public void nivel()
    {
        this.lvl = 0;

        if (lvl == 1) 
        {
            this.Multp = 1.2f;
        }

        else if (lvl == 2)
        {
            this.Multp = 1.4f;
        }

        else if (lvl == 3)
        {
            this.Multp = 1.6f;
        }

        else if (lvl == 4)
        {
            this.Multp = 1.8f;
        }

        else if (lvl >= 5)
        {
            this.Multp = 2f;
        }

        else 
        {
            this.Multp = 1f;
        }
    }
}
