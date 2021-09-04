using ContextMenuDemo.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Telerik.Blazor.Components;

namespace ContextMenuDemo.Pages
{
    public partial class Index
    {
        public List<Student> Students { get; set; }
        public List<Data.ContextMenuItem> MenuItems { get; set; }
        public List<Student> SelectedStudents { get; set; } = new();
      
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public bool ShowModal { get; set; } = false;
        public Command SelectedCommand { get; set; }

        protected override void OnInitialized()
        {
            SetMenuItems();
            LoadData();


            base.OnInitialized();
        }



        private void SetSelectedStudents(IEnumerable<Student> selectedStudents)
        {
            SelectedStudents = selectedStudents.ToList();
        }
        private void SetMenuItems()
        {
            MenuItems = new List<ContextMenuItem>()
            {
                new ContextMenuItem
                {
                    Text = "Update",
                    Icon = "edit",
                    Command = Command.Update
                },
                new ContextMenuItem
                {
                    Separator = true
                },
                new ContextMenuItem
                {
                    Text = "Delete",
                    Icon = "delete",
                     Command = Command.Delete
                }           
            };
        }

        private void HandleClick(Data.ContextMenuItem item)
        {
            switch (item.Command)
            {
                case Command.Update:
                    ShowModal = true;
                   // DataProvider.Update(SelectedStudents);
                    break;
                case Command.Delete:
                    ShowModal = true;
                   


                    break;
                default:
                    break;
            }
            SelectedCommand = item.Command;
            //NavigationManager.NavigateTo("/", true);

        }

        private void LoadData()
        {
            Students = DataProvider.GetStudents();
        }

        private void OnVisibilityChange(bool showModal)
        {
            ShowModal = showModal;
        }
        private void OnStudentsDelete(int[] idsToDelete)
        {
            DataProvider.Remove(SelectedStudents);
            NavigationManager.NavigateTo("/", true);
        }
        private void OnUpdateStudent(Student student)
        {
            DataProvider.Update(student);
            NavigationManager.NavigateTo("/", true);
        }
        private void CreateHandler(GridCommandEventArgs args)
        {
            var newStudent = (Student)args.Item;
            DataProvider.Create(newStudent);
            NavigationManager.NavigateTo("/", true);
        }
    }
}
