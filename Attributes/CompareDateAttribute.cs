using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;

using HolyAngels.Extensions;

namespace HolyAngels.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CompareDateAttribute : DataTypeAttribute //, IClientValidatable
	{
		public string OtherProperty
		{
			get;
			private set;
		}
        public CompareDateAttribute(string otherProperty) 
            : base(DataType.Date)
		{
			if (otherProperty == null)
			{
				throw new ArgumentNullException("otherProperty");
			}
			this.OtherProperty = otherProperty;
		}
		public override string FormatErrorMessage(string name)
		{
			return string.Format(CultureInfo.CurrentCulture, base.ErrorMessageString, new object[]
			{
				name, 
				this.OtherProperty
			});
		}

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo property = validationContext.ObjectType.GetProperty(this.OtherProperty);
            if (property == null)
            {
                return new ValidationResult(string.Format(CultureInfo.CurrentCulture, "{0} is an unknown property", new object[]
				{
					this.OtherProperty
				}));
            }

            string value2 = property.GetValue(validationContext.ObjectInstance, null) as string;
            if (string.IsNullOrEmpty(value2))
            {
                return new ValidationResult(string.Format(CultureInfo.CurrentCulture, "{0} not a validate date format.", new object[]
				{
					this.OtherProperty
				}));
            }

            DateTime startDate = Convert.ToDateTime(value2);
            if (startDate == null)
            {
                return new ValidationResult(string.Format(CultureInfo.CurrentCulture, "{0} not a validate date format.", new object[]
				{
					this.OtherProperty
				}));
            }
            string value1 = value as string;
            if (string.IsNullOrEmpty(value1))
            {
                return new ValidationResult(string.Format(CultureInfo.CurrentCulture, "Current date value is invalid"));
            }

            DateTime endDate = Convert.ToDateTime(value1);
            if (endDate == null)
            {
                return new ValidationResult(string.Format(CultureInfo.CurrentCulture, "Current date value is invalid"));
            }
            if (startDate.StartOfDay() > endDate.StartOfDay())
            {
                return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
            }
            return null;
        }
		
        public static string FormatPropertyForClientValidation(string property)
		{
			if (property == null)
			{
				throw new ArgumentException("Propert can not be null or empty", "property");
			}
			return "*." + property;
		}
		/*public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
		{
			yield return new ModelClientValidationEqualToRule(this.FormatErrorMessage(metadata.GetDisplayName()), CompareAttribute.FormatPropertyForClientValidation(this.OtherProperty));
			yield break;
		}*/
	}
}
