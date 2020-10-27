using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.ViewModels
{
    public class NewCustomerFormViewModels
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer customer;
    }
}