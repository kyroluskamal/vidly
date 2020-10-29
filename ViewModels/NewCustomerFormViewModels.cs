using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.Provider;
using vidly.Models;

namespace vidly.ViewModels
{
    public class NewCustomerFormViewModels
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer customer;
        public readonly string custidAtt = "Customer.Id";
        public string Formtitle(){
            return (customer != null) ? "Edit Customer : " + customer.name : "And new customer";
        }
        public int memId {
            get {
                return (customer == null) ? 0 : customer.MembershipTypeId;
            }
        }
    }
}