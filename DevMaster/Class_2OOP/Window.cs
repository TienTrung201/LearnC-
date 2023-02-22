public class Window
{
    public int top {set;get;}
    public int left {set;get;}

    public virtual void DrawWindow(){
        Console.WriteLine($"{top} {left}");
    }

}