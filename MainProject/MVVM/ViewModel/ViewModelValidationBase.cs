    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;
    using MainProject.MVVM.ViewModel;

    namespace TestingWPF.MVVM.View_Model
    {
        public class ViewModelValidationBase : ViewModelBase, INotifyDataErrorInfo
        {
            
            protected readonly Dictionary<string, List<string>> _propertyErrors = new Dictionary<string, List<string>>();

            public bool HasErrors => _propertyErrors.Any();

            public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

            public IEnumerable GetErrors(string? propertyName)
            {
                return _propertyErrors.GetValueOrDefault(propertyName, null);
            }

            public void AddError(string propertyName, string errorMessage)
            {
                if (!_propertyErrors.ContainsKey(propertyName))
                {
                    _propertyErrors.Add(propertyName, new List<string>());
                }

                _propertyErrors[propertyName].Add(errorMessage);
                OnErrorChanged(propertyName);
            }

            protected void OnErrorChanged(string propertyName)
            {
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
                OnPropertyChanged(nameof(HasErrors)); // Notify that HasErrors property has changed
            }

            protected void ClearErrors(string propertyName)
            {
                _propertyErrors.Remove(propertyName);
                OnErrorChanged(propertyName);
            }

            protected static bool IsEmail(string input)
            {
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                return Regex.IsMatch(input, pattern);
            }
            public static bool IsDate(string input)
            {
                if (DateTime.TryParseExact(input, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out _))
                {
                    return true; 
                }
                else
                {
                    return false; 
                }
            }
        }
    }
