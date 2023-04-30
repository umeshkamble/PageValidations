using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace PageValidations.Validations
{
    public class Validator : INotifyPropertyChanged
    {
        readonly ObservableObject entityToValidate;
        readonly IDictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

        public static readonly List<string> EmptyErrorsCollection = new List<string>();

        public IDictionary<string, List<string>> Errors
        {
            get { return errors; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public List<string> this[string propertyName]
        {
            get
            {
                return errors.ContainsKey(propertyName) ? errors[propertyName] : EmptyErrorsCollection;
            }
        }
      
        public bool IsValidationEnabled { get; set; }

        public Validator(ObservableObject toValidate)
        {
            if (toValidate == null)
            {
                throw new ArgumentException("entityToValidate");
            }

            entityToValidate = toValidate;
            IsValidationEnabled = true;
        }

        public Dictionary<string, List<string>> GetAllErrors()
        {
            return new Dictionary<string, List<string>>(errors);
        }

        public void SetAllErrors(IDictionary<string, List<string>> entityErrors)
        {
            if (entityErrors == null)
            {
                throw new ArgumentException("entityErrors");
            }

            errors.Clear();
            foreach (var item in entityErrors)
            {
                SetPropertyErrors(item.Key, item.Value);
            }

            OnPropertyChanged("Item[]");
            OnErrorsChanged(string.Empty);
        }

        public bool ValidateProperty(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }

            var propertyInfo = entityToValidate.GetType().GetRuntimeProperty(propertyName);
            if (propertyInfo == null)
            {
                throw new ArgumentException("The entity does not contain a property with that name.", propertyName);
            }

            var propertyErrors = new List<string>();
            bool isValid = TryValidateProperty(propertyInfo, propertyErrors);
            bool errorsChanged = SetPropertyErrors(propertyInfo.Name, propertyErrors);

            if (errorsChanged)
            {
                OnErrorsChanged(propertyName);
                OnPropertyChanged(string.Format(CultureInfo.CurrentCulture, "Item[{0}]", propertyName));
            }

            return isValid;
        }

        public bool ValidateProperties()
        {
            try
            {
                var propertiesWithChangedErrors = new List<string>();
                var propertiesToValidate = entityToValidate.GetType()
                                                           .GetRuntimeProperties()
                                                           .Where(c => c.GetCustomAttributes(typeof(ValidationAttribute)).Any());

                foreach (PropertyInfo propertyInfo in propertiesToValidate)
                {
                    var propertyErrors = new List<string>();
                    TryValidateProperty(propertyInfo, propertyErrors);

                    bool errorsChanged = SetPropertyErrors(propertyInfo.Name, propertyErrors);
                    if (errorsChanged && !propertiesWithChangedErrors.Contains(propertyInfo.Name))
                    {
                        propertiesWithChangedErrors.Add(propertyInfo.Name);
                    }
                    else
                    {
                        OnErrorsChanged(propertyInfo.Name);
                        OnPropertyChanged(string.Format(CultureInfo.CurrentCulture, "Item[{0}]", propertyInfo.Name));
                    }
                }

                foreach (string propertyName in propertiesWithChangedErrors)
                {
                    OnErrorsChanged(propertyName);
                    OnPropertyChanged(string.Format(CultureInfo.CurrentCulture, "Item[{0}]", propertyName));
                }

                bool hasAttachmentErrors = false;

                return errors.Values.Count == 0 && !hasAttachmentErrors;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                return false;
            }
        }

        bool TryValidateProperty(PropertyInfo propertyInfo, List<string> propertyErrors)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(entityToValidate) { MemberName = propertyInfo.Name };
            var propertyValue = propertyInfo.GetValue(entityToValidate);

            bool isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateProperty(propertyValue, context, results);
            if (results.Any())
            {
                propertyErrors.AddRange(results.Select(c => c.ErrorMessage));
            }

            return isValid;
        }

        bool SetPropertyErrors(string propertyName, IList<string> propertyNewErrors)
        {
            bool errorsChanged = false;

            if (!errors.ContainsKey(propertyName))
            {
                if (propertyNewErrors.Any())
                {
                    errors.Add(propertyName, new List<string>(propertyNewErrors));
                    errorsChanged = true;
                }
            }
            else
            {
                if (propertyNewErrors.Count != errors[propertyName].Count || errors[propertyName].Intersect(propertyNewErrors).Count() != propertyNewErrors.Count)
                {
                    if (propertyNewErrors.Any())
                    {
                        errors[propertyName] = new List<string>(propertyNewErrors);
                    }
                    else
                    {
                        errors.Remove(propertyName);
                    }

                    errorsChanged = true;
                }
            }
            return errorsChanged;
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
