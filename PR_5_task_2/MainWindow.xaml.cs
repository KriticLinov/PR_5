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
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace PR_5_task_2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }

    public class MainViewModel : INotifyPropertyChanged
    {
        private int _number;
        private int _sum;
        private int _count;
        private double _average;
        public ICommand AddNumberCommand { get; }

        public MainViewModel()
        {
            Numbers = new ObservableCollection<int>();
            AddNumberCommand = new RelayCommand(AddNumber);
        }

        public int Number
        {
            get { return _number; }
            set { _number = value; OnPropertyChanged(nameof(Number)); }
        }

        public ObservableCollection<int> Numbers { get; }

        public double Average
        {
            get { return _average; }
            set { _average = value; OnPropertyChanged(nameof(Average)); }
        }

        private void AddNumber()
        {
            if (Number == 0)
            {
                CalculateAverage();
                return;
            }

            Numbers.Add(Number);
            if (Number % 8 == 0)
            {
                _sum += Number;
                _count++;
            }

            Number = 0;
        }

        private void CalculateAverage()
        {
            if (_count > 0)
                Average = (double)_sum / _count;
            else
                Average = double.NaN;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _action;

        public RelayCommand(Action action)
        {
            _action = action;
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}