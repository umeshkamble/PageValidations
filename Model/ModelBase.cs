using PageValidations.Validations;

namespace PageValidations.Model
{
    public class ModelBase : ObservableValidator
    {
        Validator validator;
        public ModelBase() => validator = new Validator(this);

        public Validator Validator => validator;
    }
}
