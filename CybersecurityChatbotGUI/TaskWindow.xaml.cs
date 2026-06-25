using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace CybersecurityChatbotGUI
{
    public partial class TaskWindow : Window
    {
        private TaskManager taskManager;
        private ActivityLogger logger = new ActivityLogger(); // Initialized the logger instance

        
        public ObservableCollection<CyberTask> CyberTasks { get; set; }

        public TaskWindow()
        {
            InitializeComponent();

            taskManager = new TaskManager();

            CyberTasks = new ObservableCollection<CyberTask>(taskManager.GetAllTasks());

            
            lstTasks.ItemsSource = CyberTasks;
        }

        // CREATE TASK
        private void btnAddTask_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaskTitle.Text))
            {
                MessageBox.Show("Please enter a task title.", "Validation Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            taskManager.AddTask(txtTaskTitle.Text, txtTaskDescription.Text, txtReminder.Text);

            // Record the task creation event
            logger.LogAction($"Created new task: '{txtTaskTitle.Text}'");

            // Refresh the visual list on screen by pulling the updated dataset from storage
            CyberTasks.Clear();
            foreach (var task in taskManager.GetAllTasks())
            {
                CyberTasks.Add(task);
            }

            // Reset input boxes
            txtTaskTitle.Clear();
            txtTaskDescription.Clear();
            txtReminder.Clear();

            MessageBox.Show("Task added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // COMPLETE TASK
        private void btnCompleteTask_Click(object sender, RoutedEventArgs e)
        {
            // Check if the user has selected an item from the ListBox
            if (lstTasks.SelectedItem is CyberTask selectedTask)
            {
                taskManager.MarkAsComplete(selectedTask.Id);

                //  Record that the task was completed
                logger.LogAction($"Marked task as complete: '{selectedTask.Title}'");

                // Sync the UI collection with the updated storage file
                CyberTasks.Clear();
                foreach (var task in taskManager.GetAllTasks())
                {
                    CyberTasks.Add(task);
                }

                // Refresh the list display rendering
                lstTasks.Items.Refresh();

                MessageBox.Show("Task marked as complete!", "Status Update", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please select a task from the list to mark as complete.", "Selection Required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // DELETE TASK 
        private void btnDeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (lstTasks.SelectedItem is CyberTask selectedTask)
            {
                taskManager.DeleteTask(selectedTask.Id);

                //  Record the task deletion event
                logger.LogAction($"Deleted task: '{selectedTask.Title}'");

                // Remove from the bound visual list collection
                CyberTasks.Remove(selectedTask);

                MessageBox.Show("Task deleted successfully.", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please select a task from the list to delete.", "Selection Required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnMarkComplete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}