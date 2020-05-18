using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfAppForTask5.Helpers;

namespace WpfAppForTask5
{
    public class MainWindowViewModel: Observable
    {
        private StudentListServise.MyWebService myWebService = new StudentListServise.MyWebService();

        private ICommand graterClickCommand;
        private ICommand lowerClickCommand;
        private ICommand inRangeClickCommand;

        private string getStudentsGraterThanInput = "0";
        private string getStudentsLowerThanInput = "5";
        private string getStudentsInRangeMin = "0";
        private string getStudentsInRangeMax = "5";

        public ObservableCollection<StudentListServise.Student> GraterStudents { get; } = new ObservableCollection<StudentListServise.Student>();
        public ObservableCollection<StudentListServise.Student> LowerStudents { get; } = new ObservableCollection<StudentListServise.Student>();
        public ObservableCollection<StudentListServise.Student> InRangeStudents { get; } = new ObservableCollection<StudentListServise.Student>();
       
        public string GetStudentsGraterThanInput
        {
            get { return getStudentsGraterThanInput; }
            set { Set(ref getStudentsGraterThanInput, value); }
        }

        public string GetStudentsLowerThanInput
        {
            get { return getStudentsLowerThanInput; }
            set { Set(ref getStudentsLowerThanInput, value); }
        }
        public string GetStudentsInRangeMin
        {
            get { return getStudentsInRangeMin; }
            set { Set(ref getStudentsInRangeMin, value); }
        }
        public string GetStudentsInRangeMax
        {
            get { return getStudentsInRangeMax; }
            set { Set(ref getStudentsInRangeMax, value); }
        }

        public ICommand GraterClickCommand => graterClickCommand ?? (graterClickCommand = new RelayCommand(GraterSubmitClick));

        public ICommand LowerClickCommand => lowerClickCommand ?? (lowerClickCommand = new RelayCommand(LowerSubmitClick));

        public ICommand InRangeClickCommand => inRangeClickCommand ?? (inRangeClickCommand = new RelayCommand(InRangeSubmitClick));



        private void GraterSubmitClick()
        {
            float mark;
            if (Single.TryParse(GetStudentsGraterThanInput, out mark))
            {
                var temp = myWebService.GetStudentsGraterThan(mark);
                GraterStudents.Clear();
                foreach (var item in temp)
                {
                    GraterStudents.Add(item);
                }
            }
        }

        private void LowerSubmitClick()
        {
            float mark;
            if (Single.TryParse(GetStudentsLowerThanInput, out mark))
            {
                var temp = myWebService.GetStudentsLowerThan(mark);
                LowerStudents.Clear();
                foreach (var item in temp)
                {
                    LowerStudents.Add(item);
                }
            }
        }

        private void InRangeSubmitClick()
        {
            float markMin;
            float markMax;
            if (Single.TryParse(GetStudentsInRangeMin, out markMin) && Single.TryParse(GetStudentsInRangeMax, out markMax))
            {
                var temp = myWebService.GetStudentsInRange(markMin, markMax);
                InRangeStudents.Clear();
                foreach (var item in temp)
                {
                    InRangeStudents.Add(item);
                }
            }
        }


    }
}
