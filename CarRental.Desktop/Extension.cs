using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Desktop
{
    public static class Extensions
    {
        public static void AddBinding<TControl, TSourse>(
            this TControl target,
            Expression<Func<TControl, object>> targetProperty,
            TSourse sourse,
            Expression<Func<TSourse, object>> sourseProperty,
            ErrorProvider? errorProvider = null)
            where TControl : Control
            where TSourse : class
            
        {
            var targetName = GetPropertyname(targetProperty);
            var sourseName = GetPropertyname(sourseProperty);
            target.DataBindings.Add(new Binding(targetName, sourse, sourseName, false, DataSourceUpdateMode.OnPropertyChanged));

            if (errorProvider != null)
            {
                target.Validating += (_, _) =>
                {
                    var context = new ValidationContext(sourse);
                    var result = new List<ValidationResult>();
                    errorProvider.SetError(target, "");
                    if (!Validator.TryValidateObject(sourse, context, result, true))
                    {
                        foreach (var error in result.Where(x => x.MemberNames.Contains(sourseName)))
                        {
                            errorProvider.SetError(target, error.ErrorMessage);
                        }
                    }
                };
            }
        }

        private static string GetPropertyname<TItem, TMember>(Expression<Func<TItem, TMember>> targetMember)
        {
            if (targetMember.Body is MemberExpression memberExpresion)
            {
                return memberExpresion.Member.Name;
            }
            if (targetMember.Body is UnaryExpression unaryExpression)
            {
                var operand = unaryExpression.Operand as MemberExpression;
                if (operand != null) 
                {  
                    return operand.Member.Name; 
                }
            }
            throw new InvalidOperationException("Неизвестный тип выражения. Принимаются только - MemberExpression и ");
        }
    }
}
