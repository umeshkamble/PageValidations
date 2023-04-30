using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageValidations.Validations
{
    public static class Validation
    {
        public static readonly BindableProperty ErrorsProperty =
          BindableProperty.CreateAttached(
              "Errors",
              typeof(List<string>),
              typeof(Validation),
              Validator.EmptyErrorsCollection,
              propertyChanged: OnPropertyErrorsChanged);

        public static List<string> GetErrors(BindableObject element)
        {
            return (List<string>)element.GetValue(ErrorsProperty);
        }

        public static void SetErrors(BindableObject element, List<string> value)
        {
            element.SetValue(ErrorsProperty, value);
        }

        static void OnPropertyErrorsChanged(BindableObject element, object oldValue, object newValue)
        {
            var view = element as View;
            if (view == null | oldValue == null || newValue == null)
            {
                return;
            }

            var propertyErrors = (List<string>)newValue;
            if (propertyErrors.Any())
            {
                //view.Effects.Add(new BorderEffect());
            }
            else
            {
                //var effectToRemove = view.Effects.FirstOrDefault(e => e is BorderEffect);
                //if (effectToRemove != null)
                //{
                //    view.Effects.Remove(effectToRemove);
                //}
            }
        }

    }
}