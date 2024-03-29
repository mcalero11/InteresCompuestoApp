﻿using InteresCompuestoApp.Forms.ViewModels.Base;
using System.Collections.Generic;
using System.Linq;

namespace InteresCompuestoApp.Forms.Validations.Base
{
    public class ValidatableObject<T> : ExtendedBindableObject, IValidity
    {
        #region Commands

        #endregion
        #region Fields
        private bool _isValid;
        private readonly List<IValidationRule<T>> _validations;
        private List<string> _errors;
        private T _value;
        #endregion
        #region Properties
        public bool IsValid
        {
            get
            {
                return _isValid;
            }
            set
            {
                _isValid = value;
                RaisePropertyChanged(() => IsValid);
            }
        }
        public List<IValidationRule<T>> Validations
        {
            get { return _validations; }
        }
        public List<string> Errors
        {
            get
            {
                return _errors;
            }
            set
            {
                _errors = value;
                RaisePropertyChanged(() => Errors);
            }
        }
        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                RaisePropertyChanged(() => Value);
            }
        }
        #endregion
        #region Constructors
        public ValidatableObject()
        {
            _isValid = true;
            _errors = new List<string>();
            _validations = new List<IValidationRule<T>>();
        }
        #endregion
        #region Methods
        public bool Validate()
        {
            Errors.Clear();

            IEnumerable<string> errors = _validations.Where(v => !v.Check(Value))
                .Select(v => v.ValidationMessage);

            Errors = errors.ToList();
            IsValid = !Errors.Any();

            return this.IsValid;
        }
        #endregion


    }
}
