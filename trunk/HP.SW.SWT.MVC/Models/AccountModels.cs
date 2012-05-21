using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HP.SW.SWT.MVC.Models
{

    #region Models
    [PropertiesMustMatch("NewPassword", "ConfirmPassword", ErrorMessage = "La clave y su confirmación no coinciden.")]
    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Clave Actual")]
        public string OldPassword { get; set; }

        [Required]
        [ValidatePasswordLength]
        [DataType(DataType.Password)]
        [DisplayName("Nueva Clave")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Confirme su nueva clave")]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Required]
        [DisplayName("Usuario")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Clave")]
        public string Password { get; set; }

        [DisplayName("Recordarme en esta máquina")]
        public bool RememberMe { get; set; }
    }

    [PropertiesMustMatch("Password", "ConfirmPassword", ErrorMessage = "La clave y su confirmación no coinciden.")]
    public class RegisterModel
    {
        [Required]
        [DisplayName("Usuario")]
        public string UserName { get; set; }

        [Required]
        [ValidatePasswordLength]
        [DataType(DataType.Password)]
        [DisplayName("Clave")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Confirme su clave")]
        public string ConfirmPassword { get; set; }
    }
    #endregion

    #region Services
    // The FormsAuthentication type is sealed and contains static members, so it is difficult to
    // unit test code that calls its members. The interface and helper class below demonstrate
    // how to create an abstract wrapper around such a type in order to make the AccountController
    // code unit testable.

    public interface IMembershipService
    {
        int MinPasswordLength { get; }

        bool ValidateUser(string userName, string password);
        MembershipCreateStatus CreateUser(string userName, string password, string email);
        bool ChangePassword(string userName, string oldPassword, string newPassword);
    }

    public class AccountMembershipService : IMembershipService
    {
        private readonly MembershipProvider _provider;

        public AccountMembershipService()
            : this(null)
        {
        }

        public AccountMembershipService(MembershipProvider provider)
        {
            _provider = provider ?? Membership.Provider;
        }

        public int MinPasswordLength
        {
            get
            {
                return _provider.MinRequiredPasswordLength;
            }
        }

        public bool ValidateUser(string userName, string password)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("El campo es obligatorio.", "Usuario");
            if (String.IsNullOrEmpty(password)) throw new ArgumentException("El campo es obligatorio.", "Clave");

            return _provider.ValidateUser(userName, password);
        }

        public MembershipCreateStatus CreateUser(string userName, string password, string email)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("El campo es obligatorio.", "Usuario");
            if (String.IsNullOrEmpty(password)) throw new ArgumentException("El campo es obligatorio.", "Clave");

            MembershipCreateStatus status;
            _provider.CreateUser(userName, password, email, null, null, true, null, out status);
            return status;
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("El campo es obligatorio.", "Usuario");
            if (String.IsNullOrEmpty(oldPassword)) throw new ArgumentException("El campo es obligatorio.", "Clave Actual");
            if (String.IsNullOrEmpty(newPassword)) throw new ArgumentException("El campo es obligatorio.", "Nueva Clave");

            // The underlying ChangePassword() will throw an exception rather
            // than return false in certain failure scenarios.
            try
            {
                MembershipUser currentUser = _provider.GetUser(userName, true /* userIsOnline */);
                return currentUser.ChangePassword(oldPassword, newPassword);
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (MembershipPasswordException)
            {
                return false;
            }
        }
    }

    public interface IFormsAuthenticationService
    {
        void SignIn(string userName, bool createPersistentCookie);
        void SignOut();
    }

    public class FormsAuthenticationService : IFormsAuthenticationService
    {
        public void SignIn(string userName, bool createPersistentCookie)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("El campo es obligatorio.", "Usuario");

            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
    #endregion

    #region Validation
    public static class AccountValidation
    {
        public static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "El usuario ya existe.";

                case MembershipCreateStatus.InvalidPassword:
                    return "La clave ingresada es inválida.";

                case MembershipCreateStatus.InvalidUserName:
                    return "El usuario es inválido.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "La creación del usuario falló. Por favor verifique los datos y vuelva a intentarlo. Si el problema persiste, por favor contacte al administrador del sistema.";

                default:
                    return "Ocurrió un error inesperado. Please verify your entry and try again. Por favor verifique los datos y vuelva a intentarlo. Si el problema persiste, por favor contacte al administrador del sistema.";
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public sealed class PropertiesMustMatchAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = "'{0}' y '{1}' no coinciden.";
        private readonly object _typeId = new object();

        public PropertiesMustMatchAttribute(string originalProperty, string confirmProperty)
            : base(_defaultErrorMessage)
        {
            OriginalProperty = originalProperty;
            ConfirmProperty = confirmProperty;
        }

        public string ConfirmProperty { get; private set; }
        public string OriginalProperty { get; private set; }

        public override object TypeId
        {
            get
            {
                return _typeId;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString,
                OriginalProperty, ConfirmProperty);
        }

        public override bool IsValid(object value)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);
            object originalValue = properties.Find(OriginalProperty, true /* ignoreCase */).GetValue(value);
            object confirmValue = properties.Find(ConfirmProperty, true /* ignoreCase */).GetValue(value);
            return Object.Equals(originalValue, confirmValue);
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ValidatePasswordLengthAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = "'{0}' tiene que tener por lo menos {1} caracteres.";
        private readonly int _minCharacters = Membership.Provider.MinRequiredPasswordLength;

        public ValidatePasswordLengthAttribute()
            : base(_defaultErrorMessage)
        {
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString,
                name, _minCharacters);
        }

        public override bool IsValid(object value)
        {
            string valueAsString = value as string;
            return (valueAsString != null && valueAsString.Length >= _minCharacters);
        }
    }
    #endregion

}
