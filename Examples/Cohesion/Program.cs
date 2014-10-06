using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Examples.Cohesion
{
    public enum ActivationState
    {
        Active,
        Disabled,
        Deleted
    }

    public class CustomerAccount
    {
        private ActivationState activationState;
                
        private IList<decimal> deposits = new List<decimal>();
        private IList<decimal> withdrawals = new List<decimal>();

        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerPhoneNumber { get; set; }

        public bool IsValidAddress()
        {
            return !string.IsNullOrEmpty(CustomerFirstName) &&
                !string.IsNullOrEmpty(CustomerLastName) &&
                !string.IsNullOrEmpty(CustomerAddress) &&
                !string.IsNullOrEmpty(CustomerCity) && CustomerCity.Length > 5 &&
                !string.IsNullOrEmpty(CustomerCountry) && IsValidPhoneNumber();
        }

        public bool IsValidPhoneNumber()
        {
            return new Regex(@"^(?=^.{10,11}$)0\d*-?\d*$").IsMatch(CustomerPhoneNumber);
        }

        public void Deposit(decimal amount)
        {
            deposits.Add(amount);
        }

        public void Withdraw(decimal amount)
        {
            withdrawals.Add(amount);
        }

        public decimal GetBalance()
        {
            return deposits.Sum() - withdrawals.Sum();
        }

        public void Disable()
        {
            activationState = ActivationState.Disabled;
        }

        public void Activate()
        {
            activationState = ActivationState.Active;
        }

        public void Delete()
        {
            activationState = ActivationState.Deleted;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var account = new CustomerAccount();
            account.Deposit(90);
            account.Deposit(11);
            account.Withdraw(4.3m);

            Console.WriteLine("Current balance: " + account.GetBalance());
            Console.ReadKey();
        }
    }
}

