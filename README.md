# Simple Snake Game made with C# .NET WPF framework. 

![GIF Snake App working.](Images/gif1.gif)

*Figure 1 - The Snake App Example*

I made a simple snake app in C# using .NET's WPF framework. This application utilises assets to create the grids and the snake. 

```c#
 private void DrawGrid()
 {
     for (int row = 0; row < _rows; row++)
     {
         for (int column = 0; column < _columns; column++)
         {
             Grid gridValue = gameState._Grid[row, column];
             _images[row, column].Source = GridToImage[gridValue];
         }
     }
 }
```
*Figure 2 - Draw Grid Loop Method*

The code block above is a method that contains 2 loops, both for the rows and columns of the grid. The purpose of the method is that method looks for a specific grid asset, which is a small hollow box. This asset is repeated across, until it creates a grid. 
