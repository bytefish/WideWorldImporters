// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.OData.Client;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WideWorldImportersService;
using Container = WideWorldImportersService.Container;

namespace WideWorldImporters.Wpf.ViewModels
{
    /// <summary>
    /// The ViewModel for a <see cref="Customer"/>, which exposes the properties a DataGrid 
    /// binds to. The DataGrid requires us to also implement the <see cref="IEditableObject"/>, 
    /// so we get notified when changes should be rolled back.
    /// </summary>
    public class CustomerViewModel : ObservableValidator, IEditableObject
    {
        /// <summary>
        /// Action, that will be executed when the Entity has been modified.
        /// </summary>
        public Action<Customer> OnModified;

        /// <summary>
        /// Initializes a new instance of the CustomerViewModel class that wraps a Customer object.
        /// </summary>
        public CustomerViewModel(Customer model, Action<Customer> onModified)
        {
            Model = model;
            OnModified = onModified;
        }

        /// <summary>
        /// The underlying model.
        /// </summary>
        private Customer _model = null!;

        /// <summary>
        /// Gets or sets the underlying Customer object.
        /// </summary>
        public Customer Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged(string.Empty);
            }
        }

        private bool _isModified;

        /// <summary>
        /// Gets or the customer's valid.
        /// </summary>
        public bool IsModified
        {
            get => _isModified;
            set => SetProperty(ref _isModified, value);
        }

        private bool _isValid = true;

        /// <summary>
        /// Gets or the customer's valid.
        /// </summary>
        public bool IsValid
        {
            get => _isValid;
            set => SetProperty(ref _isValid, value);
        }

        private string? _errorMessage;

        /// <summary>
        /// Gets or the customer's valid.
        /// </summary>
        public string? ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }


        /// <summary>
        /// Gets or the customer's id.
        /// </summary>
        public int CustomerId
        {
            get => Model.CustomerId;
        }

        /// <summary>
        /// Gets or sets the customer's name.
        /// </summary>
        [Required]
        public string CustomerName
        {
            get => Model.CustomerName;
            set
            {
                if (value != Model.CustomerName)
                {
                    Model.CustomerName = value;
                    SetModified();
                    OnPropertyChanged(nameof(CustomerName));
                }
            }
        }

        /// <summary>
        /// Gets or sets the customer's phone number.
        /// </summary>
        [Required]
        public string PhoneNumber
        {
            get => Model.PhoneNumber;
            set
            {
                if (value != Model.PhoneNumber)
                {
                    Model.PhoneNumber = value;
                    SetModified();
                    OnPropertyChanged(nameof(PhoneNumber));
                }
            }
        }

        /// <summary>
        /// Gets or sets the customer's company.
        /// </summary>
        [Required]
        public string FaxNumber
        {
            get => Model.FaxNumber;
            set
            {
                if (value != Model.FaxNumber)
                {
                    Model.FaxNumber = value;
                    SetModified();
                    OnPropertyChanged(nameof(FaxNumber));
                }
            }
        }

        /// <summary>
        /// Gets or sets the customer's company.
        /// </summary>
        public string LastEditedBy
        {
            get => Model.LastEditedByNavigation.PreferredName;
        }

        /// <summary>
        /// Sets the Entity as Modified.
        /// </summary>
        public void SetModified()
        {
            IsModified = true;

            OnModified(_model);
        }

        /// <summary>
        /// Clears all existing errors in the <see cref="INotifyDataErrorInfo"/> implementation and 
        /// validates all properties.
        /// </summary>
        public void Validate()
        {
            ClearErrors();
            ValidateAllProperties();

            IsValid = !HasErrors;
           
            ErrorMessage = string.Join(", ", GetErrors().Select(x => x.ErrorMessage));
        }

        /// <summary>
        /// Called when a bound DataGrid control causes the customer to enter edit mode.
        /// </summary>
        public void BeginEdit()
        {
            // Not used yet
        }

        /// <summary>
        /// Called when a bound DataGrid control cancels the edits that have been made to a customer.
        /// </summary>
        public void CancelEdit()
        {
            // Not used yet
        }

        /// <summary>
        /// Called when a bound DataGrid control commits the edits that have been made to a customer.
        /// </summary>
        public void EndEdit()
        {
            // Not used yet
        }
    }
}