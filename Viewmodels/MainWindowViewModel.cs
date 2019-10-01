using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace HelloWPF.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            HelloWPFCmd = new HelloWPFCommand();

            Message = "";
        }

        private string message;
        public string Message { 
            get => message; 
            set => SetPropertyAndRaiseChangedEvent(ref message, value); 
        }
        
        public ICommand HelloWPFCmd { get; }
        public void SetPropertyAndRaiseChangedEvent<T>
            (ref T backingField, 
                T value, 
                [CallerMemberName] string property = "") {

                backingField = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public class HelloWPFCommand : ICommand
        {
            public HelloWPFCommand()
            {
            }
            public event EventHandler CanExecuteChanged;
            public bool CanExecute(object parameter) => true;
            

            public void Execute(object parameter)
            {
                MessageBox.Show((string)parameter);
            }
        }
    }
}