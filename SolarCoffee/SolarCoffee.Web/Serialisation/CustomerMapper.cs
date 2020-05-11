using SolarCoffee.Data.Models;
using SolarCoffee.Web.ViewModels;

namespace SolarCoffee.Web.Serialisation
{
    public static class CustomerMapper
    {
        /// <summary>
        /// Maps a customer data model to a customer view model
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static CustomerModel SerialiseCustomer(Customer customer)
        {
            return new CustomerModel
            {
                Id = customer.Id,
                CreatedOn = customer.CreatedOn,
                UpdatedOn = customer.UpdatedOn,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PrimaryAddress = MapCustomerAddress(customer.PrimaryAddress)
            };
        }

        /// <summary>
        /// Maps a customer view model to a customer data model
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static Customer SerialiseCustomer(CustomerModel customer)
        {
            return new Customer
            {
                CreatedOn = customer.CreatedOn,
                UpdatedOn = customer.UpdatedOn,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PrimaryAddress = MapCustomerAddress(customer.PrimaryAddress)
            };
        }
        
        /// <summary>
        /// Maps a customer address data model to a customer address view model
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static CustomerAddressModel MapCustomerAddress(CustomerAddress address)
        {
            return new CustomerAddressModel
            {
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                City = address.City,
                Country = address.Country,
                CreatedOn = address.CreatedOn,
                PostalCode = address.PostalCode,
                State = address.State,
                UpdatedOn = address.UpdatedOn,
                Id = address.Id
            };
        }
        
        /// <summary>
        /// Maps a customer address view model to a customer address data model
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static CustomerAddress MapCustomerAddress(CustomerAddressModel address)
        {
            return new CustomerAddress
            {
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                City = address.City,
                Country = address.Country,
                CreatedOn = address.CreatedOn,
                PostalCode = address.PostalCode,
                State = address.State,
                UpdatedOn = address.UpdatedOn
            };
        }
    }
}