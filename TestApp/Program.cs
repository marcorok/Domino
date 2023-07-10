// See https://aka.ms/new-console-template for more information
using DominoGame.GameElements;
using System.Drawing.Text;


Player p1 = new Player();
Player p2 = new Player();
Board b = new Board(p1, p2);
b.InitializeGame();


Console.WriteLine("---BoneYard---");
//Print BoneYard
var boneYard = b.GetBoneYard();
foreach (var el in boneYard) { 
    Console.WriteLine(el); 
}

Console.WriteLine("---P1 Hand---");
PrintPlayerInitialTiles(p1);
Console.WriteLine("---P2 Hand---");
PrintPlayerInitialTiles(p2);

void PrintPlayerInitialTiles(Player p1)
{
    foreach (var el in p1.GetPlayableTiles().OrderBy(t => t.ValueA)) {
        Console.WriteLine(el);
    }
}