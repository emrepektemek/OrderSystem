using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages 
    {
        public static string ProductAdded = "Product added";
        public static string ProductNameInvalid = "Product name is invalid";
        public static string MaintenanceTime = "System is under maintenance";
        public static string ProductsListed = "Products listed";
        public static string ProductCountOfCategoryError = "A category can have a maximum of 10 products";
        public static string ProductnameAlreadtExists = "A product with this name already exists";
        public static string CategoryLimitExceded = "New product cannot be added due to category limit exceeded";
        public static string? AuthorizationDenied = "You do not have access to this authorization area";
        public static string UserRegistered = "Successfully registered";
        public static string UserNotRegistered = "Registration failed";
        public static string UserNotFound = "User not found";
        public static string PasswordError = "Incorrect password";
        public static string SuccessfulLogin = "Login successful";
        public static string UserAlreadyExists = "This email is already registered in the system";
        public static string CustomerAlreadyExists = "This email is already registered as a customer";
        public static string AccessTokenCreated = "Logged in";
        public static string CreatedUserOperationClaim = "Role assigned to the user";
        public static string UpdatedUserOperationClaim = "User's role updated";
        public static string DeleteddUserOperationClaim = "User's role deleted";
        public static string CreatedCustomer = "Customer created";
        public static string CategoryNotExist = "Category does not exist";
        public static string userClaimIdNotUser = "The account is not a user";
        public static string OrderCreated = "Order created";
        public static string OrderNotExist = "Order does not exist";
        public static string OrderIsApprovedRejected = "Order rejected";
        public static string OrderIsApprovedAccept = "Order accepted";
        public static string SelectWarehouseId = "Warehouse is required";
        public static string WarehouseNotExist = "Warehouse does not exist";
        public static string IventoryNotExist = "Iventory does not exist";
        public static string IventoryNotReduced = "inventory could not be reduced";
        public static string IventoryZeroProduct = "No product left";
        public static string IventoryNotEnoughProduct = "Don't have enough product";
    }
}
