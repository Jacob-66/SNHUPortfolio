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

namespace WPFRegisterStudent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Course choice;
        int currentCredits = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Course course1 = new Course("IT 145");
            Course course2 = new Course("IT 200");
            Course course3 = new Course("IT 201");
            Course course4 = new Course("IT 270");
            Course course5 = new Course("IT 315");
            Course course6 = new Course("IT 328");
            Course course7 = new Course("IT 330");


            this.comboBox.Items.Add(course1);
            this.comboBox.Items.Add(course2);
            this.comboBox.Items.Add(course3);
            this.comboBox.Items.Add(course4);
            this.comboBox.Items.Add(course5);
            this.comboBox.Items.Add(course6);
            this.comboBox.Items.Add(course7);


            this.textBox.Text = "";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            choice = (Course)(this.comboBox.SelectedItem);

            // TO DO - Create code to validate user selection (the choice object)
            // and to display an error or a registation confirmation message accordinlgy
            // Also update the total credit hours textbox if registration is confirmed for a selected course
            if (choice == null)
            {
                label3.Content = "Please select a course before proceeding.";
                return;
            }            
            else if (choice.IsRegisteredAlready())
            {
                label3.Content = $"You have already registered for this {choice.getName()} course.";
            }
            else if (currentCredits >= 9)
            {
                label3.Content = "You can not register for more than 9 credit hours.";
            }
            else 
            {
                this.listBox.Items.Add(choice);
                choice.SetToRegistered();
                label3.Content = $"Registration Confirmed for course {choice.getName()}.";                
                currentCredits += 3;
                textBox.Text = currentCredits.ToString();


            }

        }

    }
}
