using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using Microsoft.Extensions.Logging;
using ModelLayer.Model;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
namespace BusinessLayer.Service
{
    public class GreetingBL : IGreetingBL
    {
        private readonly ILogger<GreetingBL> _logger;
        private readonly IGreetingRL _greetingRL;
        public GreetingBL(ILogger<GreetingBL> logger, IGreetingRL greetingRL)
        {
            _greetingRL = greetingRL ?? throw new ArgumentNullException(nameof(greetingRL));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public string SimpleGreeting()
        {
            _logger.LogInformation("Executing Simple Greeting Function in GreetingBL");
            string result = "Hello World";
            _logger.LogInformation($"SimpleGreeting Executed Successfully in GreetingBL with result: {result}");
            return result;
        }
        //
        public string GetGreeting(string? firstName, string? lastName)
        {
            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
            {
                _logger.LogInformation($"GetGreeting Method executing : {firstName} {lastName}");
                string result = $"Hello, {firstName} {lastName}!";
                _logger.LogInformation($"GetGreeting Method executed successfully");
                return result;
            }
            else if (!string.IsNullOrWhiteSpace(firstName))
            {
                _logger.LogInformation($"GetGreeting Method executing : {firstName}");
                string result = $"Hello, {firstName}!";
                _logger.LogInformation($"GetGreeting Method executed successfully");
                return result;
            }
            else if (!string.IsNullOrWhiteSpace(lastName))
            {
                _logger.LogInformation($"GetGreeting Method executing : {lastName}");
                string result = $"Hello, {lastName}!";
                _logger.LogInformation($"GetGreeting Method executed successfully");
                return result;
            }
            else
            {
                return "Hello, World!";
            }
        }
        public string CreateGreeting(GreetingModel greeting)
        {
            bool result = _greetingRL.Add(greeting);
            if (result)
            {
                return "Greeting Added Successfully";
            }
            else
            {
                return "Greeting Not Added";
            }
        }
    }
}
