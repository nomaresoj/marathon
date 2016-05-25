using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TresEnRaya
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        SolidColorBrush coloroff = new SolidColorBrush(Windows.UI.Colors.White);
        SolidColorBrush coloron = new SolidColorBrush(Windows.UI.Colors.Black);
        Board gameBoard;
        AI enemy;
        List<int> array1 = new List<int>();


        public MainPage()
        {
            gameBoard = new Board();
            enemy = new AI(gameBoard);
            this.InitializeComponent();
            Windows.UI.Xaml.Shapes.Rectangle tile;
            tile = (Windows.UI.Xaml.Shapes.Rectangle)this.FindName("c1_1");
            tile.Fill = coloron;
            gameBoard.setTile("c1_1", enemy.array2);
            
            clearBoard();

        }

        private async void Rectangle_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            int r;
            Windows.UI.Xaml.Shapes.Rectangle tile;
            gameBoard.setTile(((Windows.UI.Xaml.Shapes.Rectangle)sender).Name, array1);
            ((Windows.UI.Xaml.Shapes.Rectangle)sender).Fill = coloron;
            switchoff((Windows.UI.Xaml.Shapes.Rectangle)sender);
            if (array1.Count == enemy.array2.Count)
            {
                if (gameBoard.evaluateBoard(array1,enemy.array2) == false)
                {
                    var notification = new Windows.UI.Popups.MessageDialog("Has perdido!");
                    await notification.ShowAsync();
                    await clearBoard();
                    enemy.array2.Clear();
                    array1.Clear();
                    tile = (Windows.UI.Xaml.Shapes.Rectangle)this.FindName("c1_1");
                    tile.Fill = coloron;
                    gameBoard.setTile("c1_1", enemy.array2);
                }
                else
                {
                    await clearBoard();
                    array1.Clear();
                    enemy.nextMove(enemy.array2);
                    for (int k = 0; k < enemy.array2.Count; k++)
                    {
                        r = enemy.array2.ElementAt(k);
                        switch (r)
                        {
                            case 0:
                                await clearBoard();
                                tile = (Windows.UI.Xaml.Shapes.Rectangle)this.FindName("c0_0");
                                tile.Fill = coloron;
                                break;
                            case 1:
                                await clearBoard();
                                tile = (Windows.UI.Xaml.Shapes.Rectangle)this.FindName("c0_1");
                                tile.Fill = coloron;
                                break;
                            case 2:
                                await clearBoard();
                                tile = (Windows.UI.Xaml.Shapes.Rectangle)this.FindName("c0_2");
                                tile.Fill = coloron;
                                break;
                            case 3:
                                await clearBoard();
                                tile = (Windows.UI.Xaml.Shapes.Rectangle)this.FindName("c1_0");
                                tile.Fill = coloron;
                                break;
                            case 4:
                                await clearBoard();
                                tile = (Windows.UI.Xaml.Shapes.Rectangle)this.FindName("c1_1");
                                tile.Fill = coloron;
                                break;
                            case 5:
                                await clearBoard();
                                tile = (Windows.UI.Xaml.Shapes.Rectangle)this.FindName("c1_2");
                                tile.Fill = coloron;
                                break;
                            case 6:
                                await clearBoard();
                                tile = (Windows.UI.Xaml.Shapes.Rectangle)this.FindName("c2_0");
                                tile.Fill = coloron;
                                break;
                            case 7:
                                await clearBoard();
                                tile = (Windows.UI.Xaml.Shapes.Rectangle)this.FindName("c2_1");
                                tile.Fill = coloron;
                                break;
                            case 8:
                                await clearBoard();
                                tile = (Windows.UI.Xaml.Shapes.Rectangle)this.FindName("c2_2");
                                tile.Fill = coloron;
                                break;

                        }
                        
                    }
                }
                await clearBoard();
            }
        }
    
        public async void switchoff(Windows.UI.Xaml.Shapes.Rectangle tile)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            tile.Fill = coloroff;

        }

        private async   Task clearBoard()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            Windows.UI.Xaml.Shapes.Rectangle tile;

            tile = (Windows.UI.Xaml.Shapes.Rectangle)this.FindName("c0_0");
            tile.Fill = coloroff;
            tile = (Windows.UI.Xaml.Shapes.Rectangle)this.FindName("c0_1");
            tile.Fill = coloroff;
            tile = (Windows.UI.Xaml.Shapes.Rectangle)this.FindName("c0_2");
            tile.Fill = coloroff;

            tile = (Windows.UI.Xaml.Shapes.Rectangle)this.FindName("c1_0");
            tile.Fill = coloroff;
            tile = (Windows.UI.Xaml.Shapes.Rectangle)this.FindName("c1_1");
            tile.Fill = coloroff;
            tile = (Windows.UI.Xaml.Shapes.Rectangle)this.FindName("c1_2");
            tile.Fill = coloroff;

            tile = (Windows.UI.Xaml.Shapes.Rectangle)this.FindName("c2_0");
            tile.Fill = coloroff;
            tile = (Windows.UI.Xaml.Shapes.Rectangle)this.FindName("c2_1");
            tile.Fill = coloroff;
            tile = (Windows.UI.Xaml.Shapes.Rectangle)this.FindName("c2_2");
            tile.Fill = coloroff;
        }
    }
}