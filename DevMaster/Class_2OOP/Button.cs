public class Button:Window
{
    public string color{set;get;}
    public override void DrawWindow(){
        Console.WriteLine($"{top} {left} {color}");
    }

}