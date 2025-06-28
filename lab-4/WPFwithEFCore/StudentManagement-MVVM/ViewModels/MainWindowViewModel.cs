using SMSLibrary.Model;
using StudentManagement_MVVM.Command;
using StudentManagement_MVVM.DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement_MVVM.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Course _selectedCourse = null;


        private ObservableCollection<Course> _courses;

        public ObservableCollection<Course> Courses
        {
            get { return _courses; }
            set { SetProperty(ref _courses, value); }
        }

        public Course SelectedCourse
        {
            get => _selectedCourse;
            set
            {
                if (_selectedCourse != value)
                {
                    _selectedCourse = value;
                    RaisePropertyChanged();

                    RaisePropertyChanged(nameof(HasCourseSelected));
                    DeleteCourseCommand.RaiseCanExecuteChanged();
                    EditCourseCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public DelegateCommand EditCourseCommand { get; private set; }
        public DelegateCommand DeleteCourseCommand { get; private set; }

        public MainWindowViewModel()
        {
            EditCourseCommand = new DelegateCommand(EditCourse, () => HasCourseSelected);
            DeleteCourseCommand = new DelegateCommand(DeleteCourse, () => HasCourseSelected);
            Courses = dbmanager.GetCourses();
        }

        void EditCourse()
        {
            //_courseDataProvider.UpdateCourse(SelectedCourse)

            //SelectedCourse = null;
        }


        public void DeleteCourse()
        {

            dbmanager.DeleteCourse(SelectedCourse);
           
            Courses.Remove(SelectedCourse); //delete from DataGrid

            SelectedCourse = null;
        }



        public bool HasCourseSelected => SelectedCourse != null;
    }
}
