using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Demo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public ObservableCollection<Student> Students { get; set; }
        public ObservableCollection<Student> FilterStudents
        {
            get => _FilterStudents ?? (_FilterStudents = new ObservableCollection<Student>());
            set
            {
                _FilterStudents = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FilterStudents)));
            }
        }

        private ObservableCollection<Student> _FilterStudents;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainPage()
        {

            this.InitializeComponent();
            Students = new ObservableCollection<Student>()
            {
                  new Student { Name = "Cola", ID = 8 },
                  new Student { Name = "Tea", ID = 15 },
                  new Student { Name = "Mustard", ID = 10 },
                  new Student { Name = "Pickles", ID = 12 },
                  new Student { Name = "Carrots", ID = 14 },
                  new Student { Name = "Bok Choy", ID = 13 },
                  new Student { Name = "Peaches", ID = 22 },
                  new Student { Name = "Melons", ID = 16 },
            };

        }


        private bool EqualID(Student s)//测试延迟执行
        {
            Debug.WriteLine(s.ID);
            return s.ID > int.Parse(InputAge.Text);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var list1 = from s in Students
                        where EqualID(s)
                        select s;
            //var list2 = Students.Where(x => x.ID > int.Parse(InputAge.Text));
            foreach (var item in list1)
            {
                FilterStudents.Add(item);
            }

        }
    }
    public class Student
    {
        private string _Name;
        private int _ID;

        public string Name { get => _Name; set => _Name = value; }
        public int ID { get => _ID; set => _ID = value; }
    }
}
