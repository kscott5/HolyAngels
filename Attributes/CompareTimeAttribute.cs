using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;

namespace HolyAngels.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CompareTimeAttribute : DataTypeAttribute //, IClientValidatable
	{
		public string OtherProperty
		{
			get;
			private set;
		}
        public CompareTimeAttribute(string otherProperty)
            : base(DataType.Time)
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
                return new ValidationResult(string.Format(CultureInfo.CurrentCulture, "{0} not a validate time format.", new object[]
				{
					this.OtherProperty
				}));
            }

            DateTime startTime;
            try { startTime = Convert.ToDateTime(string.Format("1/1/2012 {0}", value2)); }
            catch
            {
                return new ValidationResult(string.Format(CultureInfo.CurrentCulture, "{0} not a validate time format.", new object[]
				{
					this.OtherProperty
				}));
             
            }

            string value1 = value as string;
            if (string.IsNullOrEmpty(value1))
            {
                return new ValidationResult(string.Format(CultureInfo.CurrentCulture, "Current time value is invalid"));
            }

            DateTime endTime;
            try { endTime = Convert.ToDateTime(string.Format("1/1/2012 {0}", value1)); }
            catch
            {
                return new ValidationResult(string.Format(CultureInfo.CurrentCulture, "Current time value is invalid"));
            }
        
            if (startTime > endTime)
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
