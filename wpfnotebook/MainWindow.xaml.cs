using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpfnotebook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // 宣告判斷使用的變數
        string fileName = "";
        string newFileName = "";
        string nowText = "";
        string savedText = "";

        private void newBtn_Click(object sender, RoutedEventArgs e)
        {
            if (savedText != nowText)
            {
                if (MessageBox.Show("Save configuration changes and exit?", "OK or Cancel", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Save();
                    textArea.Text = "";
                }
                else
                {
                    textArea.Text = "";
                }
            }
            else
            {
                textArea.Text = "";
            }
        }

        private void openBtn_Click(object sender, RoutedEventArgs e)
        {
            if (savedText != nowText)
                if (MessageBox.Show("Save configuration changes and exit?", "OK or NO", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Save();
                    Open();
                }
                else
                {
                    Open();
                }
            else
            {
                Open();
            }
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (fileName == newFileName)
            {
                Save();
            }
            else
            {
                System.IO.File.WriteAllText(fileName, textArea.Text);
                savedText = nowText;
            }
        }

        private void saveAs_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void smallSize_Click(object sender, RoutedEventArgs e)
        {
            textArea.FontSize--;
        }

        private void normalSize_Click(object sender, RoutedEventArgs e)
        {
            textArea.FontSize = 15;
        }

        private void largeSize_Click(object sender, RoutedEventArgs e)
        {
            textArea.FontSize++;
        }
        private void colorToBlack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // 改變主題顏色
            textArea.Background = Brushes.DimGray;
            textArea.Foreground = Brushes.LightGray;
            fileNametxt.Foreground = Brushes.LightGray;
            
        }

        private void colorToWhite_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // 改變主題顏色
            textArea.Background = Brushes.White;
            textArea.Foreground = Brushes.DimGray;
            fileNametxt.Foreground = Brushes.DimGray;
            

        }
        
        
        
        // SAVE
        void Save()
        {

            // 產生開啟檔案視窗
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();

            // 顯示視窗
            Nullable<bool> result = dlg.ShowDialog();

            // 當按下開啟之後的反應
            if (result == true)
            {
                // 儲存檔案
                System.IO.File.WriteAllText(dlg.FileName, textArea.Text);

                // 取得檔案路徑
                fileName = dlg.FileName;

                // 獲取資料
                savedText = nowText; ;

                // 顯示文件名字
                fileNametxt.Text = dlg.SafeFileName + ".txt";
            }
        }
        // OPEEEEEEEEEEN
        void Open()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                textArea.Text = System.IO.File.ReadAllText(dlg.FileName);
                fileName = dlg.FileName;
                savedText = textArea.Text;
                fileNametxt.Text = dlg.SafeFileName + ".txt";
            }
        }
    }
}

