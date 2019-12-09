﻿using System;
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
using System.Windows.Threading;

namespace Menu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            digitalTimer();
        }

        private void digitalTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += tickevent;
            timer.Start();

        }

        private void tickevent(object sender, EventArgs e)
        {
            
            timeLbl.Text = DateTime.Now.ToString(@"HH\:mm\:ss");
            dateLbl.Text = DateTime.Now.ToString(@"yyyy\-MM\-dd");
        }

        private void addRekord_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Add();           
        }

        private void editRekord_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Edit();            
        }

        private void deleteRekord_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Del();            
        }

        private void SearchRekord_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Search();            
        }
                
    }
}
