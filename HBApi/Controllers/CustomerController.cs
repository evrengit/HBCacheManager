using HBApi.Common;
using HBApi.Entity;
using HBApi.Persistance;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HBApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController(ICacheManager cacheManager, IRepositoryBase<Customer> customerRepository) : ControllerBase
    {
        private readonly ICacheManager cacheManager = cacheManager;
        private readonly IRepositoryBase<Customer> customerRepository = customerRepository;

        [HttpGet]
        public async Task<ActionResult> Get(int customerId)
        {
            var customer = GetCustomerFromCache(customerId);

            if (customer is null)
            {
                customer = await customerRepository.GetById(customerId);

                UpdateCustomerCacheValue(customer);
            }

            return Ok(customer);
        }

        [HttpPut("{customerId}")]
        public async Task<ActionResult> UpdateCustomerName(int customerId, [FromBody] string newCustomerName)
        {
            var customerToUpdate = await customerRepository.GetById(customerId);

            customerToUpdate.UpdateCustomerName(newCustomerName);

            await customerRepository.Update(customerToUpdate);

            UpdateCustomerCacheValue(customerToUpdate);

            return Ok(customerToUpdate);
        }

        private Customer? GetCustomerFromCache(int customerId)
        {
            var serializedCustomer = cacheManager.Get(GetCustomerCacheKey(customerId));

            if (string.IsNullOrWhiteSpace(serializedCustomer))
            {
                return null;
            }

            return JsonSerializer.Deserialize<Customer>(serializedCustomer);
        }

        private void UpdateCustomerCacheValue(Customer customer)
        {
            var serializedCustomer = JsonSerializer.Serialize(customer);

            cacheManager.Set(GetCustomerCacheKey(customer.Id), serializedCustomer);
        }

        private static string GetCustomerCacheKey(int customerId) => $"{typeof(Customer).Name}_{customerId}";
    }
}