using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Insurance.Entity;
using Insurance.BuisnessLayer;

namespace MainModule
{
    public class Program
    {
        static void Main(string[] args)
        {
            IInsuranceService insuranceService = new InsuranceRepository();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nPolicy Management System");
                Console.WriteLine("1. Create Policy");
                Console.WriteLine("2. Retrieve Policy");
                Console.WriteLine("3. Update Policy");
                Console.WriteLine("4. Delete Policy");
                Console.WriteLine("5. List All Policies");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option (1-6): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Create Policy
                        Policy newPolicy = new Policy();
                        Console.Write("Enter Policy ID: ");
                        newPolicy.PolicyId = Console.ReadLine();
                        Console.Write("Enter Policy Name: ");
                        newPolicy.PolicyName = Console.ReadLine();
                        Console.Write("Enter Premium Amount: ");
                        try
                        {
                            newPolicy.PremiumAmount = double.Parse(Console.ReadLine());
                            insuranceService.CreatePolicy(newPolicy);
                            Console.WriteLine("Policy created successfully.");
                        }
                        catch (PolicyAlreadyExistException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input for premium amount. Please enter a valid number.");
                        }
                        break;

                    case "2":
                        // Retrieve Policy
                        Console.Write("Enter Policy ID to retrieve: ");
                        string retrieveId = Console.ReadLine();
                        try
                        {
                            Policy retrievedPolicy = insuranceService.GetPolicy(retrieveId);
                            Console.WriteLine($"Retrieved Policy: {retrievedPolicy.PolicyName} with Premium: {retrievedPolicy.PremiumAmount}");
                        }
                        catch (PolicyNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "3":
                        // Update Policy
                        Policy updatedPolicy = new Policy();
                        Console.Write("Enter Policy ID to update: ");
                        updatedPolicy.PolicyId = Console.ReadLine();
                        Console.Write("Enter New Policy Name: ");
                        updatedPolicy.PolicyName = Console.ReadLine();
                        Console.Write("Enter New Premium Amount: ");
                        try
                        {
                            updatedPolicy.PremiumAmount = double.Parse(Console.ReadLine());
                            insuranceService.UpdatePolicy(updatedPolicy);
                            Console.WriteLine("Policy updated successfully.");
                        }
                        catch (PolicyNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input for premium amount. Please enter a valid number.");
                        }
                        break;

                    case "4":
                        // Delete Policy
                        Console.Write("Enter Policy ID to delete: ");
                        string deleteId = Console.ReadLine();
                        try
                        {
                            insuranceService.DeletePolicy(deleteId);
                            Console.WriteLine("Policy deleted successfully.");
                        }
                        catch (PolicyNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "5":
                        // List All Policies
                        var allPolicies = insuranceService.GetAllPolicies();
                        Console.WriteLine("All Policies:");
                        foreach (var policy in allPolicies)
                        {
                            Console.WriteLine($"- {policy.PolicyName} (ID: {policy.PolicyId})");
                        }
                        break;

                    case "6":
                        // Exit
                        running = false;
                        Console.WriteLine("Exiting the program.");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            Console.ReadKey();
;        }
    }
    
}
